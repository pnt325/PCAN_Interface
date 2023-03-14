using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peak.Can.Basic;

namespace PCAN_Interface.PCAN
{
    public delegate void CanReceviedMsgEventHandle(CanData data);
    public class Communication
    {
        static Thread thRead;
        static bool isStart = false;

        public static event CanReceviedMsgEventHandle CanReceivedMsg;

        public static bool Write(uint id, byte[] data)
        {
            if (Connect.IsConnected == false || data == null || data.Length < 8)
            {
                Debug.WriteLine("Arg invalid", nameof(Communication));
                Core.SysLog.Write(nameof(Communication), "Write fail: input arg invalid");
                return false;
            }

            var msg = new TPCANMsg();
            msg.DATA = new byte[8];
            msg.ID = id;
            msg.LEN = Convert.ToByte(8);
            msg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            for (int i = 0; i < data.Length; i++)
            {
                msg.DATA[i] = data[i];
            }

            var ret = PCANBasic.Write(Connect.PCANHandle, ref msg);
            if (ret == TPCANStatus.PCAN_ERROR_OK)
            {
                return true;
            }
            return false;
        }

        public static bool Write(CanData canData)
        {
            return Write(canData.Id, canData.Data);
        }

        public static bool Write(string id, string hexData)
        {
            if(id == null || hexData == null)
            {
                return false;
            }

            uint idVal;
            byte[] payload = new byte[8];
            try
            {
                idVal = uint.Parse(id, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception ex)
            {
                Core.SysLog.Write(nameof(Communication), $"Parse ID fail: {ex.Message}");
                return false;
            }

            try
            {
                string[] hexVal = hexData.Split(' ');
                if(hexVal.Length > 8)
                {
                    Core.SysLog.Write(nameof(Communication), $"Hex data invalid");
                    return false;
                }

                payload[0] = byte.Parse(hexVal[0], System.Globalization.NumberStyles.HexNumber);
                payload[1] = byte.Parse(hexVal[1], System.Globalization.NumberStyles.HexNumber);
                payload[2] = byte.Parse(hexVal[2], System.Globalization.NumberStyles.HexNumber);
                payload[3] = byte.Parse(hexVal[3], System.Globalization.NumberStyles.HexNumber);
                payload[4] = byte.Parse(hexVal[4], System.Globalization.NumberStyles.HexNumber);
                payload[5] = byte.Parse(hexVal[5], System.Globalization.NumberStyles.HexNumber);
                payload[6] = byte.Parse(hexVal[6], System.Globalization.NumberStyles.HexNumber);
                payload[7] = byte.Parse(hexVal[7], System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception ex)
            {
                Core.SysLog.Write(nameof(Communication), $"Hex data invalid {ex.Message}");
                return false;
            }

            return Write(idVal, payload);
        }

        public static CanData GetCanData(string strId, string strData)
        {
            CanData canData = new CanData();
            if (strId == null || strData == null)
            {
                return null;
            }

            uint idVal;
            byte[] payload = new byte[8];
            try
            {
                idVal = uint.Parse(strId, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception ex)
            {
                Core.SysLog.Write(nameof(Communication), $"Parse ID fail: {ex.Message}");
                return null;
            }

            try
            {
                string[] hexVal = strData.Split(' ');
                if (hexVal.Length > 8)
                {
                    Core.SysLog.Write(nameof(Communication), $"Hex data invalid");
                    return null;
                }

                payload[0] = byte.Parse(hexVal[0], System.Globalization.NumberStyles.HexNumber);
                payload[1] = byte.Parse(hexVal[1], System.Globalization.NumberStyles.HexNumber);
                payload[2] = byte.Parse(hexVal[2], System.Globalization.NumberStyles.HexNumber);
                payload[3] = byte.Parse(hexVal[3], System.Globalization.NumberStyles.HexNumber);
                payload[4] = byte.Parse(hexVal[4], System.Globalization.NumberStyles.HexNumber);
                payload[5] = byte.Parse(hexVal[5], System.Globalization.NumberStyles.HexNumber);
                payload[6] = byte.Parse(hexVal[6], System.Globalization.NumberStyles.HexNumber);
                payload[7] = byte.Parse(hexVal[7], System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception ex)
            {
                Core.SysLog.Write(nameof(Communication), $"Hex data invalid {ex.Message}");
                return null;
            }

            canData.Len = 8;
            canData.Id = idVal;
            canData.Data = payload;
            canData.TimeStamp = 0;
            return canData;
        }

        public static CanData GetCanData(string strId,string[] datas)
        {
            CanData canData = new CanData();
            if (datas == null || datas.Length < 8)
            {
                return null;
            }

            try
            {
                canData.Data = new byte[8];
                canData.Id = uint.Parse(strId, System.Globalization.NumberStyles.HexNumber);
                canData.Data[0] = byte.Parse(datas[0], System.Globalization.NumberStyles.HexNumber);
                canData.Data[1] = byte.Parse(datas[1], System.Globalization.NumberStyles.HexNumber);
                canData.Data[2] = byte.Parse(datas[2], System.Globalization.NumberStyles.HexNumber);
                canData.Data[3] = byte.Parse(datas[3], System.Globalization.NumberStyles.HexNumber);
                canData.Data[4] = byte.Parse(datas[4], System.Globalization.NumberStyles.HexNumber);
                canData.Data[5] = byte.Parse(datas[5], System.Globalization.NumberStyles.HexNumber);
                canData.Data[6] = byte.Parse(datas[6], System.Globalization.NumberStyles.HexNumber);
                canData.Data[7] = byte.Parse(datas[7], System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception ex)
            {
                Core.SysLog.Write(nameof(Communication), $"Hex data invalid {ex.Message}");
                return null;
            }
            canData.Len = 8;
            canData.TimeStamp = 0;
            return canData;
        }

        public static bool StartReceive()
        {
            if(isStart)
            {
                return true;
            }

            if (Connect.IsConnected == false)
            {
                Core.SysLog.Write(nameof(Communication), "Connection is not connected");
                return false;
            }

            thRead = new Thread(new ThreadStart(() =>
            {

                AutoResetEvent recvEvent = new AutoResetEvent(false);
                UInt32 iBuffer = Convert.ToUInt32(recvEvent.SafeWaitHandle.DangerousGetHandle().ToInt32());

                var ret = PCANBasic.SetValue(Connect.PCANHandle, TPCANParameter.PCAN_RECEIVE_EVENT, ref iBuffer, sizeof(UInt32));
                if(ret != TPCANStatus.PCAN_ERROR_OK)
                {
                    goto th_exit;
                }

                while (true)
                {
                    if(recvEvent.WaitOne(50))
                    {
                        ReceiveMessage();
                    }

                    if(isStart == false)
                    {
                        break;
                    }

                    if(Connect.IsConnected == false)
                    {
                        Core.SysLog.Write(nameof(Communication), "Receive stop, err = Connect disconnected");
                        break;
                    }
                }
            th_exit:
                iBuffer = 0;
                ret = PCANBasic.SetValue(Connect.PCANHandle, TPCANParameter.PCAN_RECEIVE_EVENT, ref iBuffer, sizeof(UInt32));
                recvEvent.Dispose();
                isStart = false;

            }));
            thRead.IsBackground = true;
            thRead.Start();

            isStart = true;

            Core.SysLog.Write(nameof(Communication), "Start receiving");
            return true;
        }

        public static void StopReceive()
        {
            if(isStart)
            {
                Core.SysLog.Write(nameof(Communication), "Stop receiving");
            }
            isStart = false;
        }

        private static void ReceiveMessage()
        {
            TPCANStatus status;

            do
            {
                status = ReadMessage();
            } while ((!Convert.ToBoolean(status & TPCANStatus.PCAN_ERROR_QRCVEMPTY)));
        }

        private static TPCANStatus ReadMessage()
        {
            TPCANStatus status = PCANBasic.Read(Connect.PCANHandle, out TPCANMsg canMsg, out TPCANTimestamp canTimeStamp);
            if(status != TPCANStatus.PCAN_ERROR_QRCVEMPTY)
            {
                ProcessMessageCan(canMsg, canTimeStamp);
            }
            return status;
        }

        private static void ProcessMessageCan(TPCANMsg canMsg, TPCANTimestamp canTimeStamp)
        {
            ulong microsTimestamp = Convert.ToUInt64(canTimeStamp.micros + 1000 * canTimeStamp.millis + 0x100000000 * 1000 * canTimeStamp.millis_overflow);

            CanData canData = new CanData();
            canData.Id = canMsg.ID;
            canData.Data = new byte[canMsg.LEN];
            canData.Len = canMsg.LEN;
            for (int i = 0; i < canMsg.LEN; i++)
            {
                canData.Data[i] = canMsg.DATA[i];
            }
            canData.TimeStamp = microsTimestamp;
            CanReceivedMsg?.Invoke(canData);
        }
    }

    public class CanData
    {
        public uint Id { get; set; }
        public byte[] Data { get; set; }
        public int Len { get; set; }
        public UInt64 TimeStamp { get; set; }
    }
}
