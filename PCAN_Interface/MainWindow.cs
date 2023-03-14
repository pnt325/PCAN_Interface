using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peak.Can.Basic;
using PCAN_Interface.PCAN;
using PCAN_Interface.Core;
using System.Runtime.InteropServices;
using System.Threading;
using System.Runtime.CompilerServices;
using System.IO.IsolatedStorage;
using System.Diagnostics;

namespace PCAN_Interface
{
    public partial class MainWindow : Form
    {
        const string STR_START = "Start";
        const string STR_STOP = "Stop";

        bool isScanDevice = false;
        Thread thScanDevice;
        List<PCAN.CanData> canDatas = new List<PCAN.CanData>();

        public MainWindow()
        {
            InitializeComponent();

            chbSendMonitor.Hide();

            this.Shown += MainWindow_Shown;
            this.FormClosing += MainWindow_FormClosing;
            LstDevices.SelectedIndexChanged += LstDevices_SelectedIndexChanged;
            LstBaudRate.SelectedIndexChanged += LstBaudRate_SelectedIndexChanged;
            ButStartStop.Click += ButStartStop_Click;
            ButClear.Click += ButClear_Click;
            ButStartStop.Text = STR_START;
            chbSendMonitor.Enabled = false;
            btnSendMsg.Enabled = false;
            InitListBaudrate();

            MsgLog.SetTextBox(rtbLog);
            SysLog.LogEvent += Log_LogEvent;
            PCAN.Communication.CanReceivedMsg += Communication_CanReceivedMsg;

            btnShowResponseData.Click += BtnShowResponseData_Click;
        }

        private void ButClear_Click(object sender, EventArgs e)
        {
            // TODO Clear data  on log terminal
            txbSystemMsg.Clear();
        }

        private void BtnShowResponseData_Click(object sender, EventArgs e)
        {
            using(FrmResponeData frm = new FrmResponeData())
            {
                frm.StartPosition = FormStartPosition.Manual;
                frm.Top = this.Top + (this.Height - frm.Height) / 2;
                frm.Left = this.Left + (this.Width - frm.Width) / 2;
                frm.ShowDialog();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            PCAN.Connect.Stop();
        }

        private void Communication_CanReceivedMsg(PCAN.CanData data)
        {
            Debug.WriteLine($"Received ID: {data.Id.ToString("X")}, Data: {BitConverter.ToString(data.Data)}", "APP");

            if(isSendMsg)
            {
                //TODO Must be check data length before send

                fillSend = Core.FillSendData.GetItemByResponseId(data);
                if (fillSend != null)
                {
                    // Update received message.
                    Core.CanMsg canMsg = new CanMsg();
                    canMsg.MsgID = data.Id;
                    canMsg.Data[0] = data.Data[0];
                    canMsg.Data[1] = data.Data[1];
                    canMsg.Data[2] = data.Data[2];
                    canMsg.Data[3] = data.Data[3];
                    canMsg.Data[4] = data.Data[4];
                    canMsg.Data[5] = data.Data[5];
                    canMsg.Data[6] = data.Data[6];
                    canMsg.Data[7] = data.Data[7];
                    Core.CanResponseData.Add(canMsg);

                    MsgLog.WriteRx(data);
                    sendResponseEvent.Set();
                }
                isSendMsg = false;
            }

            // MsgLog.WriteRx(data);
            if(startSendAndMonitor)
            {
                if(data.Id == 0x7e8)
                {
                    responseData = data.Data[2];
                    sendResponseEvent.Set();
                }
            }

            if (canDatas.Count == 0)
            {
                // Add new data
                canDatas.Add(data);
                ListViewDataAdd(data);
            }
            else
            {
                bool exist = false;
                ulong period = 0;
                for (int i = 0; i < canDatas.Count; i++)
                {
                    if (canDatas[i].Id == data.Id)
                    {
                        canDatas[i].Id = data.Id;
                        canDatas[i].Data = data.Data;
                        canDatas[i].Len = data.Len;
                        period = (data.TimeStamp - canDatas[i].TimeStamp);
                        canDatas[i].TimeStamp = data.TimeStamp;
                        exist = true;
                    }
                }

                if (exist)
                {
                    ListViewDataUpdate(data, period);
                }
                else
                {
                    // Add new data
                    canDatas.Add(data);
                    ListViewDataAdd(data);
                }
            }
        }

        private void ListViewDataAdd(PCAN.CanData data)
        {
            ListViewItem item = new ListViewItem(data.Id.ToString("X"));
            item.SubItems.Add(BitConverter.ToString(data.Data));
            item.SubItems.Add("0");
            lsvMessage.Invoke((MethodInvoker)delegate
            {
                lsvMessage.Items.Add(item);
            });
        }

        private void ListViewDataUpdate(PCAN.CanData data, ulong period)
        {
            string strId = data.Id.ToString("X");
            lsvMessage.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < lsvMessage.Items.Count; i++)
                {
                    if (lsvMessage.Items[i].SubItems[0].Text == strId)
                    {
                        lsvMessage.Items[i].SubItems[1].Text = BitConverter.ToString(data.Data);
                        lsvMessage.Items[i].SubItems[2].Text = (period/1000).ToString();
                        break;
                    }
                }
            });
        }

        private void Log_LogEvent(string msg)
        {
            txbSystemMsg.Invoke((MethodInvoker)delegate
            {
                txbSystemMsg.AppendText(msg);
            });
        }

        private void StartScanDevice()
        {
            if(isScanDevice)
            {
                return;
            }

            isScanDevice = true;
            thScanDevice = new Thread(() =>
            {
                while(isScanDevice)
                {
                    var devChannels = PCAN.Scan.Start();
                    LstDevices.BeginInvoke((MethodInvoker)delegate
                    {
                        UpdateDeviceList(devChannels);
                    });
                    Thread.Sleep(500);
                }
            });
            thScanDevice.IsBackground = true;
            thScanDevice.Start();
        }
        private void StopScanDevice()
        {
            isScanDevice = false;
            try
            {
                thScanDevice.Abort();
            }
            catch (Exception)
            {
            }
        }

        private void ButStartStop_Click(object sender, EventArgs e)
        {
            if (ButStartStop.Text == STR_START)
            {
                // Stop scan device first
                StopScanDevice();

                ScanDevice scanDevice = (ScanDevice)LstDevices.SelectedItem;
                TPCANBaudrate bitRate = PCAN.Baudrates.GetBaudrates()[(string)LstBaudRate.SelectedItem];
                if (Connect.Start(scanDevice, "", bitRate))
                {
                    if(Communication.StartReceive())
                    {
                        ButStartStop.Text = STR_STOP;
                        chbSendMonitor.Enabled = true;
                        btnSendMsg.Enabled = true;
                    }
                    else
                    {
                        Connect.Stop();
                        StartScanDevice();
                    }
                }
                else
                {
                    StartScanDevice();
                }
            }
            else
            {
                Connect.Stop();
                ButStartStop.Text = STR_START;
                StartScanDevice();
                startSendAndMonitor = false;

                chbChangeIgnore = true;
                chbSendMonitor.Checked = false;
                btnSendMsg.Enabled = false;
            }
        }

        private void LstBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lstBox = (ListBox)sender;
            ButStartStop.Enabled = true;
            LblBaudRate.Text = $"Select Baud Rate: {lstBox.SelectedItem}";
        }

        private void LstDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrpInitialize.Enabled = true;
            LstBaudRate.Enabled = true;
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            // Scan device channel
            ButStartStop.Enabled = false;
            StartScanDevice();
        }

        private void UpdateDeviceList(List<PCAN.ScanDevice> devs)
        {
            if (devs == null || devs.Count == 0)
            {
                LstDevices.Items.Clear();
                goto update_event;
            }

            // Check remove device.
            List<PCAN.ScanDevice> addDev = new List<PCAN.ScanDevice>();
            List<string> rmDev = new List<string>();

            foreach (var dev in devs)
            {
                bool isAdd = true;
                foreach(ScanDevice item in LstDevices.Items)
                {
                    if(item.Name == dev.Name)
                    {
                        isAdd = false;
                        break;  
                    }
                }

                if(isAdd)
                {
                    addDev.Add(dev);
                }
            }

            foreach(var item in LstDevices.Items)
            {
                var ret = devs.Where(e => e.Name == (string)item);
                if(ret ==null)
                {
                    rmDev.Remove((string)item);
                }
            }

            // Remove
            foreach(var rm in rmDev)
            {
                LstDevices.Items.Remove(rm);
            }

            // add
            foreach(var add in addDev)
            {
                LstDevices.Items.Add(add);
            }

            update_event:
            if(LstDevices.Items.Count == 0)
            {
                GrpInitialize.Enabled = false;
                LstBaudRate.Enabled = false;
                ButStartStop.Enabled = false;
            }
        }

        private void InitListBaudrate()
        {
            // LstBaudRate.Items.Add()
            LstBaudRate.Items.Clear();
            var items = Baudrates.GetBaudrates();
            foreach(var item in items)
            {
                LstBaudRate.Items.Add(item.Key);
            }
        }

        bool startSendAndMonitor = false;
        bool chbChangeIgnore = false;
        byte sendData = 0x01;
        byte responseData = 0x01;
        AutoResetEvent sendResponseEvent = new AutoResetEvent(false);
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(chbChangeIgnore)
            {
                chbChangeIgnore = false;
                return;
            }

            CheckBox checkBox = (CheckBox)sender;

            if(checkBox.Checked)
            {
                startSendAndMonitor = true;
                Thread th = new Thread(() =>
                {
                    while (startSendAndMonitor)
                    {
                        bool ret = false;
                        if (sendData == 0x01)
                        {
                            ret = Communication.Write(0x7e0, new byte[] { 0x02, 0x10, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 });
                            if(ret == false)
                            {
                                goto exit_thread;
                            }
                        }
                        else if(sendData == 0x03)
                        {
                            ret = Communication.Write(0x7e0, new byte[] { 0x02, 0x10, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00 });
                            if (ret == false)
                            {
                                goto exit_thread;
                            }
                        }

                        if (sendResponseEvent.WaitOne(1000))
                        {
                            if(sendData == 0x01 && responseData == 0x01)
                            {
                                sendData = 0x03;
                            }
                            else if(sendData == 0x03 && responseData == 0x03)
                            {
                                sendData = 0x03;
                            }
                            Thread.Sleep(500);  // sleep 500ms for next message
                            sendResponseEvent = new AutoResetEvent(false);
                        }
                        else
                        {
                            if(sendData == 0x03)
                            {
                                sendData = 0x01;
                            }
                            else
                            {
                                sendData = 0x01;
                            }
                        }
                        continue;
                    exit_thread:
                        SysLog.Write("APP", "Write fail, exit send and monitor");
                        startSendAndMonitor = false;
                        chbChangeIgnore = true;
                        chbSendMonitor.Invoke((MethodInvoker)delegate
                        {
                            chbSendMonitor.Checked = false;
                        });
                    }
                });
                th.IsBackground = true;
                th.Start();

                SysLog.Write("APP", "Start Test: Send and monitor");
            }
            else
            {
                startSendAndMonitor = false;
                SysLog.Write("APP", "Stop Test: Send and monitor");
            }
        }


        bool isSendMsg = false;
        bool[] enResponseData = new bool[8];
        byte[] responseDataValue = new byte[8];
        bool responseAutoFill = false;
        FillSend fillSend = new FillSend();
        private void send_msg_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;

            //pseudo code
            /*
             * RX,7E0,8,02 10 01 00 00 00 00 00,
             * TX,7E8,8,02 50 "01" 55 55 55 55 55, in "" is the third byte in the response 
             * 
             * We need to be able to save all the bytes in the response so they can be used.
             * for example byte0 = response byte[0], byte1 = response byte[1]...byte7 = response byte[7] and these get updated as new response comes in.
             * 
             * in the following logic I can use the saved bytes
             * if (byte[2] = 0x00) "this is the third byte in the response "
             * {
             * Communication.Write(0x7e0, new byte[] { 0x02, 0x10, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 });
             * }
             * else if byte[2] = 0x01
             * {
             * Communication.Write(0x7e0, new byte[] { 0x02, 0x10, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00 });
             * 
             * Message box.show("succesful")
             * }
            */
            // Communication.Write(0x7e0, new byte[] { 0x02, 0x10, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 });

            string[] datas = new string[] {txbSendData0.Text,
                                            txbSendData1.Text,
                                            txbSendData2.Text,
                                            txbSendData3.Text,
                                            txbSendData4.Text,
                                            txbSendData5.Text,
                                            txbSendData6.Text,
                                            txbSendData7.Text};

            var canData = Communication.GetCanData(txbId.Text, datas);
            if(canData == null)
            {
                btn.Enabled = true;
                return;
            }

            responseAutoFill = chbEnableAutoFill.Checked;
            if (Communication.Write(canData))
            {
                sendResponseEvent = new AutoResetEvent(false);
                isSendMsg = true;
                MsgLog.WriteTx(canData);
                Task.Run(() =>
                {
                if (sendResponseEvent.WaitOne(500) == false)
                {
                    MsgLog.WriteTimeout();
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        txbId.Text = fillSend.SendID.ToString("X3");
                        txbSendData0.Text = fillSend.SendData[0].ToString("X2");
                        txbSendData1.Text = fillSend.SendData[1].ToString("X2");
                        txbSendData2.Text = fillSend.SendData[2].ToString("X2");
                        txbSendData3.Text = fillSend.SendData[3].ToString("X2");
                        txbSendData4.Text = fillSend.SendData[4].ToString("X2");
                        txbSendData5.Text = fillSend.SendData[5].ToString("X2");
                        txbSendData6.Text = fillSend.SendData[6].ToString("X2");
                        txbSendData7.Text = fillSend.SendData[7].ToString("X2");
                    });
                    }
                    isSendMsg = false;
                    btn.Invoke((MethodInvoker)delegate
                    {
                        btn.Enabled = true;
                    });
                });
            }
            else
            {
                btn.Enabled = true;
            }
        }

        private void chbEnableAutoFill_CheckedChanged(object sender, EventArgs e)
        {
            if(chbEnableAutoFill.Checked)
            {
                using(FrmAutoFillConfigure frm =new FrmAutoFillConfigure())
                {
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.Top = this.Top + (this.Height - frm.Height) / 2;
                    frm.Left = this.Left + (this.Width - frm.Width) / 2;

                    this.Enabled = false;
                    frm.ShowDialog();
                    this.Enabled = true;
                }
            }
        }
    }
}
