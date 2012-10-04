using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DownloadSorter
{
    public partial class Form1 : Form
    {
        private string destinationRoot
        {
            get
            {
                string path = "";
                if (textBoxDestination.InvokeRequired)
                    textBoxDestination.Invoke((MethodInvoker)delegate { path = textBoxDestination.Text; });
                else path = textBoxDestination.Text;
                return path;
            }
        }

        private ProgressBar _progressBar;
        ProgressBar ProgressBar
        {
            get
            {
                if (_progressBar == null)
                {
                    _progressBar = new ProgressBar();
                    _progressBar.Step = 1;
                    _progressBar.Dock = DockStyle.Bottom;
                }

                return _progressBar;
            }
            set
            {
                _progressBar = value;
            }
        }

        BackgroundWorker _bgCopy;
        BackgroundWorker BGCopy
        {
            get
            {
                if (_bgCopy == null)
                    _bgCopy = new BackgroundWorker();
                return _bgCopy;
            }
            set
            {
                _bgCopy = value;
            }
        }

        BackgroundWorker _bgMove;
        BackgroundWorker BGMove
        {
            get
            {
                if (_bgMove == null)
                    _bgMove = new BackgroundWorker();
                return _bgMove;
            }
            set
            {
                _bgMove = value;
            }
        }

        List<string> _files;
        private List<string> Files
        {
            get
            {
                if (_files == null)
                    _files = new List<string>();
                return _files;
            }
            set
            {
                _files = value;
            }
        }

        List<string> _filesToHandel;
        private List<string> FilesToHandel
        {
            get
            {
                if (_filesToHandel == null)
                    _filesToHandel = new List<string>();
                return _filesToHandel;
            }
            set
            {
                _filesToHandel = value;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            loadTree();
        }

        private void loadTree()
        {
            if (Directory.Exists(textBoxPath.Text))
            {
                treeView1.Nodes.Clear();

                var stack = new Stack<TreeNode>();
                var rootDirectory = new DirectoryInfo(textBoxPath.Text);
                var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
                stack.Push(node);

                while (stack.Count > 0)
                {
                    var currentNode = stack.Pop();
                    var directoryInfo = (DirectoryInfo)currentNode.Tag;
                    foreach (var directory in directoryInfo.GetDirectories())
                    {
                        var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                        currentNode.Nodes.Add(childDirectoryNode);
                        stack.Push(childDirectoryNode);
                    }
                    foreach (var file in directoryInfo.GetFiles())
                        currentNode.Nodes.Add(new TreeNode(file.Name));
                }

                treeView1.Nodes.Add(node);
                treeView1.ExpandAll();
            }
            else
                MessageBox.Show("Invalid Directory!");
        }

        private void getAllFiles(string path)
        {
            Files.AddRange(Directory.GetFiles(path).ToList());
            Directory.GetDirectories(path).ToList().ForEach(x =>
                {
                    getAllFiles(x);
                });
        }

        private void getCheckedFiles()
        {
            FilesToHandel.Clear();
            if (Directory.Exists(textBoxDestination.Text))
            {
                TreeNodeCollection nodes = this.treeView1.Nodes;
                foreach (TreeNode n in nodes)
                {
                    GetNodeRecursive(n);
                }
            }
            else
            {
                MessageBox.Show("Invalid Destination");
            }
        }

        private void GetNodeRecursive(TreeNode treeNode)
        {
            if (treeNode.Checked == true)
            {
                string path = textBoxPath.Text.Substring(0, textBoxPath.Text.LastIndexOf('\\'));
                path = path.Substring(0, path.LastIndexOf('\\')) + "\\" + treeNode.FullPath.ToString();

                FilesToHandel.Add(path);
            }
            foreach (TreeNode tn in treeNode.Nodes)
            {
                GetNodeRecursive(tn);
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            getCheckedFiles();
            copyFiles();
        }

        private void copyFiles()
        {
            ProgressBar.Value = 0;
            ProgressBar.Maximum = FilesToHandel.Count;

            this.Controls.Add(ProgressBar);
            ProgressBar.BringToFront();

            BGCopy.DoWork += new DoWorkEventHandler(bgCopy_DoWork);
            BGCopy.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgCopy_RunWorkerCompleted);
            BGCopy.RunWorkerAsync();
        }

        void bgCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            FilesToHandel.ForEach(x =>
            {
                DialogResult dr = System.Windows.Forms.DialogResult.Yes;

                string path = x;
                if (checkBoxUseFolderName.Checked)
                {
                    string originalPath = "";

                    textBoxPath.Invoke((MethodInvoker)delegate { originalPath = textBoxPath.Text; });

                    if (originalPath.EndsWith("\\"))
                        originalPath = originalPath.Substring(0, originalPath.Length - 1);
                    originalPath = originalPath.Substring(originalPath.LastIndexOf('\\') + 1);

                    var splitPath = path.Split('\\');
                    if (splitPath[splitPath.Length - 2] != originalPath)
                    {
                        string ext = path.Substring(path.LastIndexOf('.'));

                        splitPath[splitPath.Length - 1] = splitPath[splitPath.Length - 2];

                        //Rebuild path
                        path = "";
                        foreach (string s in splitPath)
                        {
                            if (path == "")
                                path += s;
                            else
                                path += "\\" + s;
                        }
                        path += ext;
                    }
                    else
                        path = x;

                }

                if (File.Exists(destinationRoot + path.Substring(x.LastIndexOf('\\'))))
                {
                    dr = MessageBox.Show(destinationRoot + path.Substring(x.LastIndexOf('\\')) + " already exists." + Environment.NewLine + "Do you want to overwrite this file?", "Overwrite?", MessageBoxButtons.YesNo);
                }

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    File.Copy(x, destinationRoot + path.Substring(x.LastIndexOf('\\')), true);
                }

                if (ProgressBar.InvokeRequired)
                    ProgressBar.Invoke((MethodInvoker)delegate { ProgressBar.PerformStep(); });
                else
                    ProgressBar.PerformStep();
            });
        }

        void bgCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Copy Complete");

            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { this.Controls.Remove(ProgressBar); });
            else
                this.Controls.Remove(ProgressBar);
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            getCheckedFiles();
            moveFiles();
        }

        private void moveFiles()
        {
            ProgressBar.Value = 0;
            ProgressBar.Maximum = FilesToHandel.Count;

            this.Controls.Add(ProgressBar);
            ProgressBar.BringToFront();

            BGMove.DoWork += new DoWorkEventHandler(BGMove_DoWork);
            BGMove.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGMove_RunWorkerCompleted);
            BGMove.RunWorkerAsync();
        }

        void BGMove_DoWork(object sender, DoWorkEventArgs e)
        {
            FilesToHandel.ForEach(x =>
            {
                // MOVE FUNCTION FAULTY,  FILESTOHANDEL RUNS TWICE... ?
                DialogResult dr = System.Windows.Forms.DialogResult.No;

                //if (File.Exists(destinationRoot + x.Substring(x.LastIndexOf('\\'))))
                //{
                //    dr = MessageBox.Show(destinationRoot + x.Substring(x.LastIndexOf('\\')) + " already exists." + Environment.NewLine + "Do you want to overwrite this file?", "Overwrite?", MessageBoxButtons.YesNo);
                //}

                //if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    //if (File.Exists(destinationRoot + x.Substring(x.LastIndexOf('\\'))))
                    //    File.Delete(destinationRoot + x.Substring(x.LastIndexOf('\\')));
                    if (!File.Exists(destinationRoot + x.Substring(x.LastIndexOf('\\'))))
                    {
                        string path = x;
                        if (checkBoxUseFolderName.Checked)
                        {
                            string originalPath = "";

                            textBoxPath.Invoke((MethodInvoker)delegate { originalPath = textBoxPath.Text; });

                            if (originalPath.EndsWith("\\"))
                                originalPath = originalPath.Substring(0, originalPath.Length - 1);
                            originalPath = originalPath.Substring(originalPath.LastIndexOf('\\')+1);

                            var splitPath = path.Split('\\');
                            if (splitPath[splitPath.Length - 2] != originalPath)
                            {
                                string ext = path.Substring(path.LastIndexOf('.'));

                                splitPath[splitPath.Length - 1] = splitPath[splitPath.Length - 2];

                                //Rebuild path
                                path = "";
                                foreach (string s in splitPath)
                                {
                                    if (path == "")
                                        path += s;
                                    else
                                        path += "\\" + s;
                                }
                                path += ext;
                            }
                            else
                                path = x;
                            
                        }

                        File.Move(x, destinationRoot + path.Substring(x.LastIndexOf('\\')));
                    }
                }

                if (ProgressBar.InvokeRequired)
                    ProgressBar.Invoke((MethodInvoker)delegate { ProgressBar.PerformStep(); });
                else
                    ProgressBar.PerformStep();
            });
        }

        void BGMove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Move Complete");

            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate { this.Controls.Remove(ProgressBar); });
            else
                this.Controls.Remove(ProgressBar);

            loadTree();
        }

        private void selectAllOfThisTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                string extention = treeView1.SelectedNode.ToString().Substring(treeView1.SelectedNode.ToString().LastIndexOf('.'));
                if (MessageBox.Show("Select all files of " + extention + " extension type?", "Extensions", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (TreeNode n in treeView1.Nodes)
                    {
                        checkAllOfExtention(extention, n);
                        if (n.ToString().Contains('.'))
                        {
                            if (n.ToString().Substring(n.ToString().LastIndexOf('.')) == extention)
                            {
                                n.Checked = true;
                            }
                        }
                    }
                }
            }
        }

        private void checkAllOfExtention(string extention, TreeNode treeNode)
        {
            foreach (TreeNode n in treeNode.Nodes)
            {
                checkAllOfExtention(extention, n);
                if (n.ToString().Contains('.'))
                {
                    if (n.ToString().Substring(n.ToString().LastIndexOf('.')) == extention)
                    {
                        n.Checked = true;
                    }
                }
            }
        }
    }
}
