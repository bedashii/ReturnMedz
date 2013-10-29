using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AutoClicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            simulateClick();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        private void simulateClick()
        {
            int interval = 200;
            if (textBox1.Text != "")
                interval = Convert.ToInt32(textBox1.Text);
            while (true)
            {
                POINT lpPoint;
                GetCursorPos(out lpPoint);

                //int x = 100;
                //int y = 100;
                mouse_event(MOUSEEVENTF_LEFTDOWN, lpPoint.X, lpPoint.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, lpPoint.X, lpPoint.Y, 0, 0);
                Thread.Sleep(interval);
            }

        }
    }
}
