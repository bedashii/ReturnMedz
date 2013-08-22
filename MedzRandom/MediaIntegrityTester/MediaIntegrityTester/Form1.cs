using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaIntegrityTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BackgroundWorker backgroundWorkerMKVScan;

        private void buttonScan_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBoxPath.Text))
            {
                FileInfo fi = new FileInfo(textBoxPath.Text);
                if (fi.Extension == ".mkv")
                {
                    if (backgroundWorkerMKVScan == null)
                    {
                        backgroundWorkerMKVScan = new BackgroundWorker();
                        backgroundWorkerMKVScan.DoWork += delegate
                        {
                            Process read = new Process();
                            read.StartInfo.FileName = "mkvmerge.exe";
                            read.StartInfo.RedirectStandardOutput = true;
                            read.StartInfo.RedirectStandardInput = true;
                            read.StartInfo.UseShellExecute = false;
                            read.StartInfo.CreateNoWindow = true;
                            read.StartInfo.Arguments = String.Format(" -o NUL \"{0}\"", textBoxPath.Text);

                            read.Start();

                            StreamReader myStreamReader = read.StandardOutput;

                            int progress = 0;

                            string line = myStreamReader.ReadLine();

                            while (line != null)
                            {
                                if (textBoxConsole.InvokeRequired)
                                {
                                    textBoxConsole.Invoke((MethodInvoker)delegate
                                    {
                                        progress = UpdateProgress(progress, line);
                                    });
                                }
                                else
                                {
                                    progress = UpdateProgress(progress, line);
                                }
                                line = myStreamReader.ReadLine();
                            }
                        };

                        backgroundWorkerMKVScan.RunWorkerCompleted += delegate
                        {
                            if (textBoxConsole.InvokeRequired)
                            {
                                textBoxConsole.Invoke((MethodInvoker)delegate { textBoxConsole.Text += Environment.NewLine + "DONE!"; });
                            }
                            else
                            {
                                textBoxConsole.Text += Environment.NewLine + "DONE!";
                            }
                        };
                    }
                    backgroundWorkerMKVScan.RunWorkerAsync();
                }
            }


        }

        private int UpdateProgress(int progress, string line)
        {
            if (line.StartsWith("Progress"))
            {
                progress = int.Parse(line.Substring(10, line.Length - 11));
                if (progress % 10 == 0)
                {
                    if (textBoxConsole.Text == "")
                        textBoxConsole.Text += line;
                    else
                        textBoxConsole.Text += Environment.NewLine + line;
                }
            }
            else
            {
                if (textBoxConsole.Text == "")
                    textBoxConsole.Text += line;
                else
                    textBoxConsole.Text += Environment.NewLine + line;
            }
            return progress;
        }
    }
}
