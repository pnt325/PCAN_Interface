using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PCAN_Interface.Core
{
    public class CanResponseData
    {
        private static List<CanMsg> items = new List<CanMsg>();
        
        public static void Add(CanMsg msg)
        {
            items.Add(msg);
        }

        public static List<CanMsg> Datas { get => items; }
    }
}
