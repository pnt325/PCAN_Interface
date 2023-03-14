using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAN_Interface.Core
{
    public class FillSend
    {
        public uint SendID { get; set; }
        public  uint RespID { get; set; }
        public byte[] SendData { get; set; } = new byte[8];
        public byte[] RespData { get; set; } = new byte[8];
        public bool[] SelResponeDatas { get; set; } = new bool[8];

        public FillSend Clone()
        {
            FillSend fillSend = new FillSend();
            fillSend.RespID = RespID;
            fillSend.SendID = SendID;
            for (int i = 0; i < 8; i++)
            {
                fillSend.SendData[i] = SendData[i];
                fillSend.RespData[i] = RespData[i];
                fillSend.SelResponeDatas[i] = SelResponeDatas[i];
            }
            
            return fillSend;
        }
    }
}
