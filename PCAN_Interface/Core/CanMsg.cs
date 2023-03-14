using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAN_Interface.Core
{
    public class CanMsg
    {
        public uint MsgID { get; set; }
        public byte[] Data { get; set; } = new byte[8];
    }
}
