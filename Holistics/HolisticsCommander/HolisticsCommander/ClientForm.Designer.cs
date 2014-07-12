namespace HolisticsCommander
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.DataGridViewMain = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BindingSourceCommApplicationList = new System.Windows.Forms.BindingSource(this.components);
            this.LabelName = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.BindingSourceSelectedItem = new System.Windows.Forms.BindingSource(this.components);
            this.LabelPath = new System.Windows.Forms.Label();
            this.TextBoxPath = new System.Windows.Forms.TextBox();
            this.PanelSplitProperties = new System.Windows.Forms.SplitContainer();
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripCommands = new System.Windows.Forms.MenuStrip();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM2TextBoxApplication = new System.Windows.Forms.ToolStripTextBox();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelSplitMain = new System.Windows.Forms.SplitContainer();
            this.NotifyIconClient = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuStripServers = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCommApplicationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSelectedItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelSplitProperties)).BeginInit();
            this.PanelSplitProperties.Panel1.SuspendLayout();
            this.PanelSplitProperties.Panel2.SuspendLayout();
            this.PanelSplitProperties.SuspendLayout();
            this.MenuStripMain.SuspendLayout();
            this.MenuStripCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelSplitMain)).BeginInit();
            this.PanelSplitMain.Panel1.SuspendLayout();
            this.PanelSplitMain.Panel2.SuspendLayout();
            this.PanelSplitMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridViewMain
            // 
            this.DataGridViewMain.AllowUserToAddRows = false;
            this.DataGridViewMain.AllowUserToDeleteRows = false;
            this.DataGridViewMain.AutoGenerateColumns = false;
            this.DataGridViewMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.nameDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn});
            this.DataGridViewMain.DataSource = this.BindingSourceCommApplicationList;
            this.DataGridViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataGridViewMain.Location = new System.Drawing.Point(0, 0);
            this.DataGridViewMain.Name = "DataGridViewMain";
            this.DataGridViewMain.ReadOnly = true;
            this.DataGridViewMain.RowHeadersVisible = false;
            this.DataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewMain.Size = new System.Drawing.Size(756, 354);
            this.DataGridViewMain.TabIndex = 0;
            this.DataGridViewMain.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewMain_RowEnter);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 1F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 40F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.FillWeight = 60F;
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BindingSourceCommApplicationList
            // 
            this.BindingSourceCommApplicationList.DataSource = typeof(HolisticsCommander.Lib.List.CommApplicationList);
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(1, 6);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(35, 13);
            this.LabelName.TabIndex = 1;
            this.LabelName.Text = "Name";
            // 
            // TextBoxName
            // 
            this.TextBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSourceSelectedItem, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBoxName.Location = new System.Drawing.Point(42, 3);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.ReadOnly = true;
            this.TextBoxName.Size = new System.Drawing.Size(257, 20);
            this.TextBoxName.TabIndex = 2;
            // 
            // BindingSourceSelectedItem
            // 
            this.BindingSourceSelectedItem.DataSource = typeof(HolisticsCommander.Lib.Business.CommApplication);
            // 
            // LabelPath
            // 
            this.LabelPath.AutoSize = true;
            this.LabelPath.Location = new System.Drawing.Point(3, 6);
            this.LabelPath.Name = "LabelPath";
            this.LabelPath.Size = new System.Drawing.Size(29, 13);
            this.LabelPath.TabIndex = 1;
            this.LabelPath.Text = "Path";
            // 
            // TextBoxPath
            // 
            this.TextBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSourceSelectedItem, "Path", true));
            this.TextBoxPath.Location = new System.Drawing.Point(38, 3);
            this.TextBoxPath.Name = "TextBoxPath";
            this.TextBoxPath.ReadOnly = true;
            this.TextBoxPath.Size = new System.Drawing.Size(421, 20);
            this.TextBoxPath.TabIndex = 2;
            // 
            // PanelSplitProperties
            // 
            this.PanelSplitProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSplitProperties.Location = new System.Drawing.Point(0, 0);
            this.PanelSplitProperties.Name = "PanelSplitProperties";
            // 
            // PanelSplitProperties.Panel1
            // 
            this.PanelSplitProperties.Panel1.Controls.Add(this.TextBoxName);
            this.PanelSplitProperties.Panel1.Controls.Add(this.LabelName);
            // 
            // PanelSplitProperties.Panel2
            // 
            this.PanelSplitProperties.Panel2.Controls.Add(this.LabelPath);
            this.PanelSplitProperties.Panel2.Controls.Add(this.TextBoxPath);
            this.PanelSplitProperties.Size = new System.Drawing.Size(768, 26);
            this.PanelSplitProperties.SplitterDistance = 302;
            this.PanelSplitProperties.TabIndex = 3;
            // 
            // MenuStripMain
            // 
            this.MenuStripMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Size = new System.Drawing.Size(277, 24);
            this.MenuStripMain.TabIndex = 4;
            this.MenuStripMain.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.TSMI_EnterEditMode_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.TSMI_EnterEditMode_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.TSMI_ExitEditMode_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Enabled = false;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.cancelToolStripMenuItem.Text = "&Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.TSMI_ExitEditMode_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.TSMI_Delete_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.TSMI_ExitProgram_Click);
            // 
            // MenuStripCommands
            // 
            this.MenuStripCommands.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.BindingSourceSelectedItem, "Name", true));
            this.MenuStripCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MenuStripCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.TSM2TextBoxApplication,
            this.executeToolStripMenuItem,
            this.killToolStripMenuItem});
            this.MenuStripCommands.Location = new System.Drawing.Point(0, 430);
            this.MenuStripCommands.Name = "MenuStripCommands";
            this.MenuStripCommands.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MenuStripCommands.Size = new System.Drawing.Size(768, 27);
            this.MenuStripCommands.TabIndex = 5;
            this.MenuStripCommands.Text = "menuStrip1";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(55, 23);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.TSMI2_Restart_Click);
            // 
            // TSM2TextBoxApplication
            // 
            this.TSM2TextBoxApplication.Name = "TSM2TextBoxApplication";
            this.TSM2TextBoxApplication.ReadOnly = true;
            this.TSM2TextBoxApplication.Size = new System.Drawing.Size(200, 23);
            this.TSM2TextBoxApplication.Text = "Application";
            this.TSM2TextBoxApplication.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(59, 23);
            this.executeToolStripMenuItem.Text = "Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.TSMI2_Execute_Click);
            // 
            // killToolStripMenuItem
            // 
            this.killToolStripMenuItem.Name = "killToolStripMenuItem";
            this.killToolStripMenuItem.Size = new System.Drawing.Size(35, 23);
            this.killToolStripMenuItem.Text = "Kill";
            this.killToolStripMenuItem.Click += new System.EventHandler(this.TSMI2_Kill_Click);
            // 
            // PanelSplitMain
            // 
            this.PanelSplitMain.Location = new System.Drawing.Point(0, 76);
            this.PanelSplitMain.Name = "PanelSplitMain";
            this.PanelSplitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // PanelSplitMain.Panel1
            // 
            this.PanelSplitMain.Panel1.Controls.Add(this.PanelSplitProperties);
            this.PanelSplitMain.Panel1Collapsed = true;
            // 
            // PanelSplitMain.Panel2
            // 
            this.PanelSplitMain.Panel2.Controls.Add(this.DataGridViewMain);
            this.PanelSplitMain.Size = new System.Drawing.Size(756, 354);
            this.PanelSplitMain.SplitterDistance = 26;
            this.PanelSplitMain.TabIndex = 6;
            // 
            // NotifyIconClient
            // 
            this.NotifyIconClient.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIconClient.Icon")));
            this.NotifyIconClient.Text = "Holistics Commander";
            this.NotifyIconClient.DoubleClick += new System.EventHandler(this.NotifyIconClient_DoubleClick);
            // 
            // MenuStripServers
            // 
            this.MenuStripServers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuStripServers.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStripServers.Location = new System.Drawing.Point(656, 0);
            this.MenuStripServers.Name = "MenuStripServers";
            this.MenuStripServers.Size = new System.Drawing.Size(100, 24);
            this.MenuStripServers.TabIndex = 7;
            this.MenuStripServers.Text = "menuStrip1";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 457);
            this.Controls.Add(this.PanelSplitMain);
            this.Controls.Add(this.MenuStripMain);
            this.Controls.Add(this.MenuStripCommands);
            this.Controls.Add(this.MenuStripServers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStripMain;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Holistics Commander";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.ClientForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCommApplicationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceSelectedItem)).EndInit();
            this.PanelSplitProperties.Panel1.ResumeLayout(false);
            this.PanelSplitProperties.Panel1.PerformLayout();
            this.PanelSplitProperties.Panel2.ResumeLayout(false);
            this.PanelSplitProperties.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelSplitProperties)).EndInit();
            this.PanelSplitProperties.ResumeLayout(false);
            this.MenuStripMain.ResumeLayout(false);
            this.MenuStripMain.PerformLayout();
            this.MenuStripCommands.ResumeLayout(false);
            this.MenuStripCommands.PerformLayout();
            this.PanelSplitMain.Panel1.ResumeLayout(false);
            this.PanelSplitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelSplitMain)).EndInit();
            this.PanelSplitMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewMain;
        private System.Windows.Forms.BindingSource BindingSourceCommApplicationList;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label LabelPath;
        private System.Windows.Forms.TextBox TextBoxPath;
        private System.Windows.Forms.SplitContainer PanelSplitProperties;
        private System.Windows.Forms.MenuStrip MenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.BindingSource BindingSourceSelectedItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip MenuStripCommands;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox TSM2TextBoxApplication;
        private System.Windows.Forms.ToolStripMenuItem killToolStripMenuItem;
        private System.Windows.Forms.SplitContainer PanelSplitMain;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon NotifyIconClient;
        private System.Windows.Forms.MenuStrip MenuStripServers;
    }
}

