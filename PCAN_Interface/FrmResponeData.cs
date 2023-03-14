using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCAN_Interface
{
    public partial class FrmResponeData : Form
    {
        public FrmResponeData()
        {
            InitializeComponent();
            this.Shown += FrmResponeData_Shown;
        }

        private void FrmResponeData_Shown(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var data = Core.CanResponseData.Datas;
                foreach (var d in data)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        string dtime = $"{DateTime.Now.Hour.ToString("D2")}:{DateTime.Now.Minute.ToString("D2")}:{DateTime.Now.Second.ToString("D2")}:{DateTime.Now.Millisecond.ToString("D3")}";
                        ListViewItem item = new ListViewItem(dtime);
                        item.SubItems.Add(d.MsgID.ToString("X3"));
                        item.SubItems.Add(BitConverter.ToString(d.Data));
                        lsvData.Items.Add(item);
                    });
                }
            });
            
        }
    }
}
