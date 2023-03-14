using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAN_Interface.Core
{
    public delegate void LogEventHandle(string msg);
    public class SysLog
    {
        public static event LogEventHandle LogEvent;
        public static void Write(string tag, string msg)
        {
            string logStr = $"{DateTime.Now.ToLongTimeString()} ({tag}) {msg}" + Environment.NewLine;
            LogEvent?.Invoke(logStr);
        }
    }
}
