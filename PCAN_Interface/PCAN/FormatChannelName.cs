using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peak.Can.Basic;

namespace PCAN_Interface.PCAN
{
    public class FormatChannelName
    {
        public static string GetString(UInt16 handle, bool isFD)
        {
            TPCANDevice devDevice;
            byte byChannel;

            // Gets the owner device and channel for a 
            // PCAN-Basic handle
            //
            if (handle < 0x100)
            {
                devDevice = (TPCANDevice)(handle >> 4);
                byChannel = (byte)(handle & 0xF);
            }
            else
            {
                devDevice = (TPCANDevice)(handle >> 8);
                byChannel = (byte)(handle & 0xFF);
            }

            // Constructs the PCAN-Basic Channel name and return it
            //
            if (isFD)
            {
                return string.Format("{0}:FD {1} ({2:X2}h)", devDevice, byChannel, handle);
            }
            else
            {
                return string.Format("{0} {1} ({2:X2}h)", devDevice, byChannel, handle);
            }
        }
    }
}
