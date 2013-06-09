using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DownloadSorter
{
    public partial class Main : Form
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

        List<CustomFile> _files;
        private List<CustomFile> Files
        {
            get
            {
                if (_files == null)
                    _files = new List<CustomFile>();
                return _files;
            }
            set
            {
                _files = value;
            }
        }

        List<CustomFile> _filesToHandel;
        private List<CustomFile> FilesToHandel
        {
            get
            {
                if (_filesToHandel == null)
                    _filesToHandel = new List<CustomFile>();
                return _filesToHandel;
            }
            set
            {
                _filesToHandel = value;
            }
        }

        public Main()
        {
            InitializeComponent();
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            loadTree();
        }

        private void loadTree()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Shit, something went wrong, most likely you're using the fucking file!" + Environment.NewLine + ex.Message + Environment.NewLine + ex.ToString());
            }
        }

        private void getAllFiles(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.GetFiles(path).ToList().ForEach(x =>
                    {
                        Files.Add(new CustomFile(x));
                    });

                Directory.GetDirectories(path).ToList().ForEach(x =>
                    {
                        getAllFiles(x);
                    });
            }
        }

        private void getCheckedFiles()
        {
            FilesToHandel.Clear();
            //if (Directory.Exists(textBoxDestination.Text))
            {
                TreeNodeCollection nodes = this.treeView1.Nodes;
                foreach (TreeNode n in nodes)
                {
                    GetNodeRecursive(n);
                }
            }
            //else
            //{
            //    MessageBox.Show("Invalid Destination");
            //}
        }

        private void GetNodeRecursive(TreeNode treeNode)
        {
            if (treeNode.Checked == true)
            {
                string path = "";
                if (textBoxPath.Text.LastIndexOf('\\') + 1 != textBoxPath.Text.Length)
                    path = textBoxPath.Text.Substring(0, textBoxPath.Text.LastIndexOf('\\'));
                else
                    path = textBoxPath.Text;
                //path = path.Substring(0, path.Contains('\\') ? path.LastIndexOf('\\') : path.Length);
                if (path[path.Length - 1] != '\\')
                    path += "\\";
                //path += treeNode.FullPath.ToString().Substring(treeNode.FullPath.ToString().IndexOf('\\') + 1);
                path += treeNode.FullPath.ToString();

                FilesToHandel.Add(new CustomFile(path));
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

                string path = x.FullPath;
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
                        path = x.FullPath;

                }

                if (File.Exists(destinationRoot + path.Substring(x.FullPath.LastIndexOf('\\'))))
                {
                    dr = MessageBox.Show(destinationRoot + path.Substring(x.FullPath.LastIndexOf('\\')) + " already exists." + Environment.NewLine + "Do you want to overwrite this file?", "Overwrite?", MessageBoxButtons.YesNo);
                }

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    File.Copy(x.FullPath, destinationRoot + path.Substring(x.FullPath.LastIndexOf('\\')), true);
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
            bool moveWithParentName = false;
            moveWithParentName = checkBoxUseFolderName.Checked;
            if (checkBoxUseFolderName.InvokeRequired)
                checkBoxUseFolderName.Invoke((MethodInvoker)delegate { moveWithParentName = checkBoxUseFolderName.Checked; });

            if (moveWithParentName)
            {
                List<CustomFile> filesToRemove = new List<CustomFile>();
                FilesToHandel.ForEach(x =>
                    {
                        if (FilesToHandel.FindAll(y => x.ParentName == y.ParentName && y.Extention == x.Extention).Count > 1)
                            filesToRemove.Add(x);
                    });
                filesToRemove.ForEach(x =>
                    {
                        FilesToHandel.RemoveAll(y => y.ParentName == x.ParentName && y.Extention == x.Extention);
                    });

                if (filesToRemove.Count > 0)
                {
                    string message = "The following Files could not be moved because they would have the same name.";
                    filesToRemove.ForEach(x =>
                        {
                            message += Environment.NewLine + x.FullPath;
                        });
                    MessageBox.Show(message);
                }
            }

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
                    if (!File.Exists(destinationRoot + x.FullPath.Substring(x.FullPath.LastIndexOf('\\'))))
                    {
                        string path = x.FullPath;
                        if (moveWithParentName)
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
                                path = x.FullPath;
                        }

                        if (!File.Exists(destinationRoot + path.Substring(path.LastIndexOf('\\'))))
                            File.Move(x.FullPath, destinationRoot + path.Substring(path.LastIndexOf('\\')));
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
                if (treeView1.SelectedNode.ToString().LastIndexOf('.') != -1)
                {
                    string extention = treeView1.SelectedNode.ToString().Substring(treeView1.SelectedNode.ToString().LastIndexOf('.'));
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
                else
                {
                    MessageBox.Show("Can't find extention type in " + treeView1.SelectedNode.ToString());
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

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getCheckedFiles();

            DeleteConfirmationForm dcf = new DeleteConfirmationForm();
            // POSSIBLE CRASH!!!
            dcf.Width = Convert.ToInt32(this.Width * 0.8);
            dcf.Height = Convert.ToInt32(this.Height * 0.8);
            dcf.CustomFileBindingSource.DataSource = FilesToHandel;

            if (dcf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FilesToHandel.ForEach(x =>
                {
                    if (File.Exists(x.FullPath))
                    {
                        File.Delete(x.FullPath);
                    }
                });
                loadTree();
            }
        }

        private void deleteAllEmptyFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteEmptyFolders(textBoxPath.Text);
        }

        private void deleteEmptyFolders(string path)
        {
            if (Directory.Exists(path))
            {
                if (Directory.GetDirectories(path).Length + Directory.GetFiles(path).Length == 0)
                    try
                    {
                        Directory.Delete(path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine + "Debug Info:" + Environment.NewLine + ex.StackTrace);
                    }
                else
                    Directory.GetDirectories(path).ToList().ForEach(x =>
                        {
                            deleteEmptyFolders(x);
                        });
                loadTree();
            }
        }

        private void clearAnnoyancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> annoyanceList = new List<string>();
            annoyanceList.AddRange(new string[] { "nfo", "nzb", "srs", "sfv", "srr", "srt" });

            foreach (TreeNode n in treeView1.Nodes)
            {
                annoyanceList.ForEach(x => checkAllOfExtention("." + x, n));
            }

            getCheckedFiles();

            DeleteConfirmationForm dcf = new DeleteConfirmationForm();
            // POSSIBLE CRASH!!!
            dcf.Width = Convert.ToInt32(this.Width * 0.8);
            dcf.Height = Convert.ToInt32(this.Height * 0.8);
            dcf.CustomFileBindingSource.DataSource = FilesToHandel;

            if (dcf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FilesToHandel.ForEach(x =>
                {
                    if (File.Exists(x.FullPath))
                    {
                        File.Delete(x.FullPath);
                    }
                });
                loadTree();
            }
        }

        private void findSamplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TreeNode n in treeView1.Nodes)
            {
                checkAllContaining("sample", n);
            }

            getCheckedFiles();

            DeleteConfirmationForm dcf = new DeleteConfirmationForm();
            // POSSIBLE CRASH!!!
            dcf.Width = Convert.ToInt32(this.Width * 0.8);
            dcf.Height = Convert.ToInt32(this.Height * 0.8);
            dcf.CustomFileBindingSource.DataSource = FilesToHandel;

            if (dcf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FilesToHandel.ForEach(x =>
                {
                    if (File.Exists(x.FullPath))
                    {
                        File.Delete(x.FullPath);
                    }
                });
                loadTree();
            }
        }

        private void checkAllContaining(string filter, TreeNode treeNode)
        {
            filter = filter.ToLower();
            foreach (TreeNode n in treeNode.Nodes)
            {
                checkAllContaining(filter, n);
                if (n.ToString().ToLower().Contains(filter))
                {
                    n.Checked = true;
                }
            }
        }

        private void openFileDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = textBoxPath.Text.Substring(0, textBoxPath.Text.LastIndexOf('\\'));
            path = path.Substring(0, path.Contains('\\') ? path.LastIndexOf('\\') : path.Length) + "\\" + treeView1.SelectedNode.FullPath.ToString().Substring(0, treeView1.SelectedNode.FullPath.ToString().LastIndexOf('\\'));
            System.Diagnostics.Process.Start(path);
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clearAnnoyancesToolStripMenuItem_Click(null, null);
            findSamplesToolStripMenuItem_Click(null, null);

            List<string> extentions = new List<string>();
            extentions.AddRange(new string[] { "mkv", "avi", "mp4" });
            extentions.ForEach(ext =>
                {
                    foreach (TreeNode n in treeView1.Nodes)
                    {
                        checkAllOfExtention(ext, n);
                        if (n.ToString().Contains('.'))
                        {
                            if (n.ToString().Substring(n.ToString().LastIndexOf('.')) == ext)
                            {
                                n.Checked = true;
                            }
                        }
                    }
                });

            deleteAllEmptyFoldersToolStripMenuItem_Click(null, null);
        }

        private void renameToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameTool rt = new RenameTool();
            rt.Width = Convert.ToInt32(this.Width * 0.8);
            rt.Height = Convert.ToInt32(this.Height * 0.8);

            Files.Clear();
            getAllFiles(textBoxPath.Text);

            rt.CustomFiles = Files;

            if (rt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Renamed
            }
            else
            {
                // Cancelled
            }
        }

        private void removeRarFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TreeNode n in treeView1.Nodes)
            {
                checkAllRarFiles(n);
            }
        }

        private void checkAllRarFiles(TreeNode treeNode)
        {
            foreach (TreeNode n in treeNode.Nodes)
            {
                checkAllRarFiles(n);
                if (n.ToString().LastIndexOf('.') != -1)
                {
                    string ext = n.ToString().ToLower().Substring(n.ToString().LastIndexOf('.') + 1);
                    if (ext.Length > 0 && (ext[0] == 'r' || ext[0] == 's'))
                    {
                        int intValue = 0;
                        if (ext == "rar" || Int32.TryParse(ext.Substring(1), out intValue))
                        {
                            n.Checked = true;
                        }
                    }
                }
            }
        }

        private void checkAllNumFiles(TreeNode treeNode)
        {
            foreach (TreeNode n in treeNode.Nodes)
            {
                checkAllNumFiles(n);
                if (n.ToString().LastIndexOf('.') != -1)
                {
                    string ext = n.ToString().ToLower().Substring(n.ToString().LastIndexOf('.') + 1);
                    if (ext.Length > 0)
                    {
                        int intValue = 0;
                        if (Int32.TryParse(ext, out intValue))
                        {
                            n.Checked = true;
                        }
                    }
                }
            }
        }

        private void selectNumericFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TreeNode n in treeView1.Nodes)
            {
                checkAllNumFiles(n);
            }
        }
    }
}