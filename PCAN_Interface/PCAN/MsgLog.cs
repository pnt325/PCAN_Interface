using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PCAN_Interface.PCAN
{
    public delegate void MsgLogEventHandle(string msg);
    public class MsgLog
    {
        const string fontName = "Consolas";
        const int fontSize = 9;

        private static RichTextBox textBox;
        private static Font defaultFont = new Font(fontName, fontSize, FontStyle.Regular);
        private static Font fontBold = new Font(fontName, fontSize, FontStyle.Bold);
        private static Color rxColor = Color.Blue;
        private static Color txColor = Color.Red;
        private static Color defaultColor = Color.Black;
        private static Mutex sendMutex = new Mutex();

        public static void SetTextBox(RichTextBox rtb)
        {
            textBox = rtb;
        }

        public static void WriteTx(CanData canData)
        {
            sendMutex.WaitOne();
            textBox.Invoke((MethodInvoker)delegate
            {
                if(textBox.TextLength > 0)
                {
                    SetNewLine();
                }
                SetTime();
                SetText("TX", txColor, defaultFont);
                SetText(",", defaultColor, defaultFont);
                SetText(canData.Id.ToString("X3"), txColor, defaultFont);
                SetText(",", defaultColor, defaultFont);
                SetText(canData.Len.ToString(), defaultColor, defaultFont);
                SetText(",", defaultColor, defaultFont);
                SetText(BytesToString(canData.Data), txColor, fontBold);
                ClearTextSlection();
            });
            sendMutex.ReleaseMutex();
        }

        public static void WriteTimeout()
        {
            sendMutex.WaitOne();
            textBox.Invoke((MethodInvoker)delegate
            {
                if (textBox.TextLength > 0)
                {
                    SetNewLine();
                }
                SetTime();
                SetText("RX", rxColor, defaultFont);
                SetText(":Timeout", defaultColor, defaultFont);
                ClearTextSlection();
            });
            sendMutex.ReleaseMutex();
        }

        public static void WriteRx(CanData canData)
        {
            sendMutex.WaitOne();
            textBox.Invoke((MethodInvoker)delegate
            {
                if (textBox.TextLength > 0)
                {
                    SetNewLine();
                }
                SetTime();
                SetText("RX", rxColor, defaultFont);
                SetText(",", defaultColor, defaultFont);
                SetText(canData.Id.ToString("X3"), rxColor, defaultFont);
                SetText(",", defaultColor, defaultFont);
                SetText(canData.Len.ToString(), defaultColor, defaultFont);
                SetText(",", defaultColor, defaultFont);
                SetText(BytesToString(canData.Data), rxColor, fontBold);
                ClearTextSlection();
            });
            sendMutex.ReleaseMutex();
        }

        private static void SetTime()
        {
            string text = $"[{DateTime.Now.Hour.ToString("D2")}:{DateTime.Now.Minute.ToString("D2")}:{DateTime.Now.Second.ToString("D2")}:{DateTime.Now.Millisecond.ToString("D3")}]";
            int curLen = textBox.TextLength;
            textBox.AppendText(text);
            textBox.Select(curLen, curLen + text.Length);
            textBox.SelectionFont = defaultFont;
            textBox.SelectionColor = defaultColor;
        }

        private static void SetText(string text, Color color, Font font)
        {
            int curLen = textBox.TextLength;
            textBox.AppendText(text);
            textBox.Select(curLen, curLen + text.Length);
            textBox.SelectionFont = font;
            textBox.SelectionColor = color;
        }

        private static void SetNewLine()
        {
            textBox.AppendText(Environment.NewLine);
        }

        private static void ClearTextSlection()
        {
            textBox.SelectionStart = textBox.TextLength;
        }

        private static string BytesToString(byte[] data)
        {
            string str = "";
            if(data == null)
            {
                return str;
            }

            for (int i = 0; i < data.Length; i++)
            {
                if(i + 1 < data.Length)
                {
                    str += $"{data[i].ToString("X2")} ";
                }
                else
                {
                    str += $"{data[i].ToString("X2")}";
                }
            }

            return str;
        }
    }
}
