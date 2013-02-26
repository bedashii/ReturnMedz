namespace DownloadSorter
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllOfThisTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.buttonMove = new System.Windows.Forms.Button();
            this.checkBoxUseFolderName = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllEmptyFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAnnoyancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findSamplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.Location = new System.Drawing.Point(55, 27);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(662, 20);
            this.textBoxPath.TabIndex = 2;
            this.textBoxPath.Text = "C:\\Users\\Medz\\Documents\\Downloads\\complete\\Series\\";
            // 
            // buttonScan
            // 
            this.buttonScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonScan.Location = new System.Drawing.Point(723, 27);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(75, 23);
            this.buttonScan.TabIndex = 3;
            this.buttonScan.Text = "Scan";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopy.Enabled = false;
            this.buttonCopy.Location = new System.Drawing.Point(723, 454);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 4;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Visible = false;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.CheckBoxes = true;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Location = new System.Drawing.Point(12, 56);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(786, 392);
            this.treeView1.TabIndex = 5;
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllOfThisTypeToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem,
            this.openFileDirectoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 70);
            // 
            // selectAllOfThisTypeToolStripMenuItem
            // 
            this.selectAllOfThisTypeToolStripMenuItem.Name = "selectAllOfThisTypeToolStripMenuItem";
            this.selectAllOfThisTypeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.selectAllOfThisTypeToolStripMenuItem.Text = "Select all of this Type";
            this.selectAllOfThisTypeToolStripMenuItem.Click += new System.EventHandler(this.selectAllOfThisTypeToolStripMenuItem_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Delete Selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // openFileDirectoryToolStripMenuItem
            // 
            this.openFileDirectoryToolStripMenuItem.Name = "openFileDirectoryToolStripMenuItem";
            this.openFileDirectoryToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openFileDirectoryToolStripMenuItem.Text = "Open File Directory";
            this.openFileDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openFileDirectoryToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Destination";
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestination.Location = new System.Drawing.Point(78, 456);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(447, 20);
            this.textBoxDestination.TabIndex = 7;
            this.textBoxDestination.Text = "C:\\Users\\Medz\\Documents\\Downloads\\complete\\Project\\";
            // 
            // buttonMove
            // 
            this.buttonMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMove.Location = new System.Drawing.Point(642, 454);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(75, 23);
            this.buttonMove.TabIndex = 8;
            this.buttonMove.Text = "Move";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // checkBoxUseFolderName
            // 
            this.checkBoxUseFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxUseFolderName.AutoSize = true;
            this.checkBoxUseFolderName.Checked = true;
            this.checkBoxUseFolderName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseFolderName.Location = new System.Drawing.Point(531, 458);
            this.checkBoxUseFolderName.Name = "checkBoxUseFolderName";
            this.checkBoxUseFolderName.Size = new System.Drawing.Size(105, 17);
            this.checkBoxUseFolderName.TabIndex = 9;
            this.checkBoxUseFolderName.Text = "Use FolderName";
            this.checkBoxUseFolderName.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(810, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.deleteAllEmptyFoldersToolStripMenuItem,
            this.clearAnnoyancesToolStripMenuItem,
            this.findSamplesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // deleteAllEmptyFoldersToolStripMenuItem
            // 
            this.deleteAllEmptyFoldersToolStripMenuItem.Name = "deleteAllEmptyFoldersToolStripMenuItem";
            this.deleteAllEmptyFoldersToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.deleteAllEmptyFoldersToolStripMenuItem.Text = "Delete all empty folders";
            this.deleteAllEmptyFoldersToolStripMenuItem.Click += new System.EventHandler(this.deleteAllEmptyFoldersToolStripMenuItem_Click);
            // 
            // clearAnnoyancesToolStripMenuItem
            // 
            this.clearAnnoyancesToolStripMenuItem.Name = "clearAnnoyancesToolStripMenuItem";
            this.clearAnnoyancesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.clearAnnoyancesToolStripMenuItem.Text = "Clear Annoyances";
            this.clearAnnoyancesToolStripMenuItem.Click += new System.EventHandler(this.clearAnnoyancesToolStripMenuItem_Click);
            // 
            // findSamplesToolStripMenuItem
            // 
            this.findSamplesToolStripMenuItem.Name = "findSamplesToolStripMenuItem";
            this.findSamplesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.findSamplesToolStripMenuItem.Text = "Find Samples";
            this.findSamplesToolStripMenuItem.Click += new System.EventHandler(this.findSamplesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItem1.Text = "Auto";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 489);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.checkBoxUseFolderName);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.textBoxDestination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "NZB Helper";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectAllOfThisTypeToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxUseFolderName;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllEmptyFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAnnoyancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findSamplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

