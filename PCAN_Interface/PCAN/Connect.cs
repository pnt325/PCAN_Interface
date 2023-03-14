using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Peak.Can.Basic;

namespace PCAN_Interface.PCAN
{
    public class Connect
    {
        public static bool IsConnected { get; private set; }
        static private UInt16 pcanHandle;
        public static bool Start(ScanDevice dev, string baudrate, TPCANBaudrate bitrate)
        {
            TPCANStatus status;

            if(dev.IsFD)
            {
                status = PCANBasic.InitializeFD(dev.Handle, baudrate);
            }
            else
            {
                status = PCANBasic.Initialize(dev.Handle, bitrate);
            }

            if(status == TPCANStatus.PCAN_ERROR_OK)
            {
                IsConnected = true;
                pcanHandle = dev.Handle;

                Core.SysLog.Write(nameof(Connect), "Connect start success");
                return true;
            }

            Core.SysLog.Write(nameof(Connect), "Connect start failure");
            return false;
        }

        public static bool Stop()
        {
            IsConnected = false;
            TPCANStatus status = PCANBasic.Uninitialize(pcanHandle);
            if (status == TPCANStatus.PCAN_ERROR_OK)
            {
                Core.SysLog.Write(nameof(Connect), "Connect stop success");
                return true;
            }
            Core.SysLog.Write(nameof(Connect), "Connect stop failure");

            return false;
        }

        public static UInt16 PCANHandle { get=>pcanHandle; }

    }
}
