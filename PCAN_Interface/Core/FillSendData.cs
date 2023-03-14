using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCAN_Interface.Core
{
    public class FillSendData
    {
        const string fileName = "fill_send.txt";
        private static List<FillSend> items = new List<FillSend>();
        public static List<FillSend> Items { get => items; }

        public static bool Update(FillSend data, int index)
        {
            if(index < 0 || index >= items.Count)
            {
                return false;
            }

            items[index] = data;

            return true;
        }

        public static FillSend GetItem(int index)
        {
            if(index < items.Count)
            {
                return items[index];
            }
            return null;
        }

        public static bool Add(FillSend data)
        {
            if(CheckAvailable(data))
            {
                throw new Exception("Item is existed");
            }

            items.Add(data);

            return true;
        }

        public static FillSend GetItemByResponseId(PCAN.CanData data)
        {
            if (items.Count == 0)
            {
                return null;
            }

            var ret = items.Where(e => e.RespID == data.Id);
            if (ret.Count() > 0)
            {
                var fillSend = ret.First();
                if(CompareData(fillSend, data.Data))
                {
                    return fillSend;
                }
            }
            return null;
        }

        private static bool CompareData(FillSend fillSend, byte[] data)
        {
            bool result = true;
            for (int i = 0; i < 8; i++)
            {
                if (fillSend.SelResponeDatas[i])
                {
                    if (fillSend.RespData[i] != data[i])
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        public static bool Remove(int index)
        {
            if(index < items.Count && index >= 0)
            {
                items.RemoveAt(index);
                return true;
            }
            return false;
        }
        public static int Remove(FillSend fillSend)
        {
            int index = -1;
            for (int i = 0; i < items.Count; i++)
            {
                if(fillSend.RespID == items[i].RespID)
                {
                    index = i;
                    break;
                }
            }

            if (Remove(index))
                return index;

            return -1;
        }

        public static bool CheckAvailable(uint sendID, uint resID)
        {
            if (items.Count > 0)
            {
                var ret = items.Where(e => e.RespID == resID);
                if (ret != null && ret.Count() > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool CheckAvailable(FillSend data)
        {
            return CheckAvailable(data.SendID, data.RespID);
        }

        public static void Load()
        {
            if(File.Exists(fileName) == false)
            {
                return;
            }
            else
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach(string line in lines)
                {
                    // respid, sendid, resdata, ressel, senddata
                    FillSend fillSend = new FillSend();
                    string[] datas = line.Split(',');

                    if(datas.Length != 5)
                    {
                        continue;
                    }

                    try
                    {
                        fillSend.RespID = uint.Parse(datas[0], System.Globalization.NumberStyles.HexNumber);
                        fillSend.SendID = uint.Parse(datas[1], System.Globalization.NumberStyles.HexNumber);

                        string[] resSels = datas[2].Split(';');
                        string[] resDatas = datas[3].Split(';');
                        string[] sendDatas = datas[4].Split(';');
                        if (resSels.Length != 8 || resDatas.Length != 8 || sendDatas.Length != 8)
                        {
                            continue;
                        }

                        for (int i = 0; i < 8; i++)
                        {
                            fillSend.SelResponeDatas[i] = int.Parse(resSels[i]) != 0 ? true : false;
                            fillSend.SendData[i] = byte.Parse(sendDatas[i], System.Globalization.NumberStyles.HexNumber);
                            fillSend.RespData[i] = byte.Parse(resDatas[i], System.Globalization.NumberStyles.HexNumber);
                        }

                        if(CheckAvailable(fillSend) == false)
                        {
                            Add(fillSend);
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }

        public static void Save()
        {
            string strDatas = "";
            if(items.Count == 0)
            {
                File.WriteAllText(fileName, strDatas);
                return;
            }

            foreach(FillSend item in items)
            {
                string sendId = item.SendID.ToString("X3");
                string resId = item.RespID.ToString("X3");
                string resSels = "";
                string sendDatas = "";
                string respDatas = "";
                for (int i = 0; i < 8; i++)
                {
                    if (i < 7)
                    {
                        resSels += item.SelResponeDatas[i] ? "1" : "0" + ";";
                        sendDatas += item.SendData[i].ToString("X2") + ";";
                        respDatas += item.RespData[i].ToString("X2") + ";";
                    }
                    else
                    {
                        resSels += item.SelResponeDatas[i] ? "1" : "0";
                        sendDatas += item.SendData[i].ToString("X2");
                        respDatas += item.RespData[i].ToString("X2");
                    }
                }
                strDatas += $"{resId},{sendId},{resSels},{respDatas},{sendDatas}" + Environment.NewLine;
            }

            File.WriteAllText(fileName, strDatas);
        }
    }
}
