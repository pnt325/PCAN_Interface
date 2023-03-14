using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Peak.Can.Basic;

namespace PCAN_Interface.PCAN
{
    public class Scan
    {
        private static bool IsFd(uint feature, int flag)
        {
            return (feature & flag) == flag;
        }

        public static List<ScanDevice> Start()
        {
            List<ScanDevice> scanDevs = new List<ScanDevice>();
            try
            {
                uint channelCount = 0;
                var scanResult = PCANBasic.GetValue(PCANBasic.PCAN_NONEBUS,
                                                    TPCANParameter.PCAN_ATTACHED_CHANNELS_COUNT,
                                                    out channelCount,
                                                    sizeof(uint));
                if (scanResult != TPCANStatus.PCAN_ERROR_OK)
                {
                    return null;
                }

                TPCANChannelInformation[] info = new TPCANChannelInformation[channelCount];
                scanResult = PCANBasic.GetValue(PCANBasic.PCAN_NONEBUS,
                                                TPCANParameter.PCAN_ATTACHED_CHANNELS,
                                                info);
                if (scanResult != TPCANStatus.PCAN_ERROR_OK)
                {
                    return null;
                }

                foreach (var channel in info)
                {
                    if ((channel.channel_condition & PCANBasic.PCAN_CHANNEL_AVAILABLE) ==
                        PCANBasic.PCAN_CHANNEL_AVAILABLE)
                    {
                        bool fd = IsFd(channel.device_features, PCANBasic.FEATURE_FD_CAPABLE);
                        scanDevs.Add(new ScanDevice()
                        {
                            IsFD = fd,
                            Name = FormatChannelName.GetString(channel.channel_handle, fd),
                            Handle = channel.channel_handle
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, nameof(PCAN.Scan));
                return null;
            }

            return scanDevs;
        }
    }

    public class ScanDevice
    {
        public string Name;
        public UInt16 Handle;
        public bool IsFD;

        public override string ToString()
        {
            return Name;
        }
    }
}
