using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peak.Can.Basic;

namespace PCAN_Interface.PCAN
{
    public class Baudrates
    {
        public static Dictionary<string, TPCANBaudrate> GetBaudrates()
        {
            Dictionary<string, TPCANBaudrate> dis = new Dictionary<string, TPCANBaudrate>()
            {
                { "1 MBit/sec" , TPCANBaudrate.PCAN_BAUD_1M},
                { "800 kBit/sec" , TPCANBaudrate.PCAN_BAUD_800K},
                { "500 kBit/sec" , TPCANBaudrate.PCAN_BAUD_500K},
                { "250 kBit/sec" , TPCANBaudrate.PCAN_BAUD_250K},
                { "125 kBit/sec" , TPCANBaudrate.PCAN_BAUD_125K},
                { "100 kBit/sec" , TPCANBaudrate.PCAN_BAUD_100K},
                { "95,238 kBit/sec" , TPCANBaudrate.PCAN_BAUD_95K},
                { "83,333 kBit/sec" , TPCANBaudrate.PCAN_BAUD_83K},
                { "50 kBit/sec" , TPCANBaudrate.PCAN_BAUD_50K},
                { "47,619 kBit/sec" , TPCANBaudrate.PCAN_BAUD_47K},
                { "33,333 kBit/sec" , TPCANBaudrate.PCAN_BAUD_33K},
                { "20 kBit/sec" , TPCANBaudrate.PCAN_BAUD_20K},
                { "10 kBit/sec" , TPCANBaudrate.PCAN_BAUD_10K},
                { "5 kBit/sec" , TPCANBaudrate.PCAN_BAUD_5K},
            };
            return dis;
        }
    }
}
