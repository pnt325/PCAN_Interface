using PCAN_Interface.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCAN_Interface
{
    public partial class FrmAutoFillConfigure : Form
    {
        CheckBox[] chbEnableRespDatas = new CheckBox[8];
        TextBox[] txbRespDatas = new TextBox[8];
        TextBox[] txbSendDatas = new TextBox[8];

        public FrmAutoFillConfigure()
        {
            InitializeComponent();

            chbEnableRespDatas[0] = chbData0;
            chbEnableRespDatas[1] = chbData1;
            chbEnableRespDatas[2] = chbData2;
            chbEnableRespDatas[3] = chbData3;
            chbEnableRespDatas[4] = chbData4;
            chbEnableRespDatas[5] = chbData5;
            chbEnableRespDatas[6] = chbData6;
            chbEnableRespDatas[7] = chbData7;

            txbRespDatas[0] = txbRes0;
            txbRespDatas[1] = txbRes1;
            txbRespDatas[2] = txbRes2;
            txbRespDatas[3] = txbRes3;
            txbRespDatas[4] = txbRes4;
            txbRespDatas[5] = txbRes5;
            txbRespDatas[6] = txbRes6;
            txbRespDatas[7] = txbRes7;

            txbSendDatas[0] = txbSend0;
            txbSendDatas[1] = txbSend1;
            txbSendDatas[2] = txbSend2;
            txbSendDatas[3] = txbSend3;
            txbSendDatas[4] = txbSend4;
            txbSendDatas[5] = txbSend5;
            txbSendDatas[6] = txbSend6;
            txbSendDatas[7] = txbSend7;

            for (int i = 0; i < chbEnableRespDatas.Length; i++)
            {
                chbEnableRespDatas[i].CheckedChanged += FrmAutoFillConfigure_CheckedChanged;
            }

            lsvData.SelectedIndexChanged += LsvData_SelectedIndexChanged;
            lsvData.ItemCheck += LsvData_ItemCheck;
            lsvData.ItemChecked += LsvData_ItemChecked;

            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnRemoveSel.Click += BtnRemoveSel_Click;

            this.Shown += FrmAutoFillConfigure_Shown;
            this.FormClosing += FrmAutoFillConfigure_FormClosing;

            btnRemoveSel.Enabled = false;
            btnRemove.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void LsvData_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lsvData.CheckedItems.Count > 0)
            {
                btnRemoveSel.Enabled = true;
            }
            else
            {
                btnRemoveSel.Enabled = false;
            }
        }

        private void LsvData_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void FrmAutoFillConfigure_FormClosing(object sender, FormClosingEventArgs e)
        {
            Core.FillSendData.Save();
        }

        private void FrmAutoFillConfigure_Shown(object sender, EventArgs e)
        {
            Core.FillSendData.Load();
            foreach(FillSend item in FillSendData.Items)
            {
                AddListItem(item);
            }
        }

        private void BtnRemoveSel_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lsvData.CheckedItems)
            {
                if(Core.FillSendData.Remove(item.Index))
                {
                    lsvData.Items.Remove(item);
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            FillSend fillSend = GetFillSendData();
            if(fillSend == null)
            {
                MessageBox.Show("FillSend data invalid", "Error");
                return;
            }

            if(FillSendData.Update(fillSend, selectedIndex))
            {
                lsvData.Items[selectedIndex].SubItems[0].Text = fillSend.RespID.ToString("X3");
                lsvData.Items[selectedIndex].SubItems[1].Text = fillSend.SendID.ToString("X3");
                lsvData.Items[selectedIndex].SubItems[2].Text = BitConverter.ToString(fillSend.SendData);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            FillSend fillSend = GetFillSendData();
            if (fillSend == null)
            {
                MessageBox.Show("FillSend data invalid", "Error");
                return;
            }

            int index = FillSendData.Remove(fillSend);
            if (index >= 0)
            {
                lsvData.Items.RemoveAt(index);
            }
        }

    private void BtnAdd_Click(object sender, EventArgs e)
        {
            Core.FillSend fillSend = GetFillSendData();
            if(fillSend ==  null)
            {
                MessageBox.Show($"Input valud invalid", "Error");
                return;
            }

            if (Core.FillSendData.CheckAvailable(fillSend))
            {
                MessageBox.Show("Send/Resp ID is available, Please do update", "Error");
                return;
            }

            if (Core.FillSendData.Add(fillSend))
            {
                AddListItem(fillSend);
            }
        }

        int selectedIndex = -1;
        private void LsvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lsv = (ListView)sender;
            if (lsv.SelectedItems.Count == 0)
            {
                selectedIndex = -1;
                btnAdd.Enabled = false;
                btnRemove.Enabled = false;
                btnUpdate.Enabled = false;
                return;
            }

            // fill data to form
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;
            btnUpdate.Enabled = true;
            selectedIndex = lsvData.SelectedItems[0].Index;
            var fillSend = Core.FillSendData.GetItem(lsv.SelectedItems[0].Index);
            SetData(fillSend);
        }

        private void FrmAutoFillConfigure_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chb = (CheckBox)sender;
            for (int i = 0; i < chbEnableRespDatas.Length; i++)
            {
                if(chb == chbEnableRespDatas[i])
                {
                    txbRespDatas[i].Enabled = chb.Checked;
                }
            }
        }

        private FillSend GetFillSendData()
        {
            Core.FillSend fillSend = new Core.FillSend();

            try
            {
                fillSend.SendID = uint.Parse(txbSendID.Text, System.Globalization.NumberStyles.HexNumber);
                fillSend.RespID = uint.Parse(txbResId.Text, System.Globalization.NumberStyles.HexNumber);
                for (int i = 0; i < 8; i++)
                {
                    fillSend.SelResponeDatas[i] = chbEnableRespDatas[i].Checked;
                    fillSend.RespData[i] = byte.Parse(txbRespDatas[i].Text, System.Globalization.NumberStyles.HexNumber);
                    fillSend.SendData[i] = byte.Parse(txbSendDatas[i].Text, System.Globalization.NumberStyles.HexNumber);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Input valud invalid: {ex.Message}", "Error");
                return null;
            }
            return fillSend;
        }

        private void SetData(FillSend data)
        {
            txbSendID.Text = data.SendID.ToString("X3");
            txbResId.Text = data.RespID.ToString("X3");
            for (int i = 0; i < 8; i++)
            {
                chbEnableRespDatas[i].Checked = data.SelResponeDatas[i];
                txbSendDatas[i].Text = data.SendData[i].ToString("X2");
                txbRespDatas[i].Text = data.RespData[i].ToString("X2");
            }
        }

        private void AddListItem(FillSend fillSend)
        {
            ListViewItem item = new ListViewItem(fillSend.RespID.ToString("X3"));
            item.SubItems.Add(fillSend.SendID.ToString("X3"));
            item.SubItems.Add(BitConverter.ToString(fillSend.SendData));
            lsvData.Items.Add(item);
        }
    }
}
