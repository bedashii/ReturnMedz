namespace ChattersApp.Controls
{
    partial class SystemInfoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.splitContainerMenues = new System.Windows.Forms.SplitContainer();
            this.dataGridViewSystemInfo = new System.Windows.Forms.DataGridView();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelValue = new System.Windows.Forms.Label();
            this.labelKey = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.sIKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.systemInfoListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenues)).BeginInit();
            this.splitContainerMenues.Panel1.SuspendLayout();
            this.splitContainerMenues.Panel2.SuspendLayout();
            this.splitContainerMenues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSystemInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemInfoListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.HeaderText = "";
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.ReadOnly = true;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Width = 5;
            // 
            // splitContainerMenues
            // 
            this.splitContainerMenues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMenues.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMenues.Name = "splitContainerMenues";
            this.splitContainerMenues.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMenues.Panel1
            // 
            this.splitContainerMenues.Panel1.Controls.Add(this.dataGridViewSystemInfo);
            // 
            // splitContainerMenues.Panel2
            // 
            this.splitContainerMenues.Panel2.Controls.Add(this.buttonNew);
            this.splitContainerMenues.Panel2.Controls.Add(this.buttonSave);
            this.splitContainerMenues.Panel2.Controls.Add(this.labelValue);
            this.splitContainerMenues.Panel2.Controls.Add(this.labelKey);
            this.splitContainerMenues.Panel2.Controls.Add(this.textBoxDescription);
            this.splitContainerMenues.Panel2.Controls.Add(this.textBoxTitle);
            this.splitContainerMenues.Size = new System.Drawing.Size(480, 416);
            this.splitContainerMenues.SplitterDistance = 205;
            this.splitContainerMenues.TabIndex = 1;
            // 
            // dataGridViewSystemInfo
            // 
            this.dataGridViewSystemInfo.AllowUserToAddRows = false;
            this.dataGridViewSystemInfo.AllowUserToDeleteRows = false;
            this.dataGridViewSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSystemInfo.AutoGenerateColumns = false;
            this.dataGridViewSystemInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSystemInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSystemInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sIKeyDataGridViewTextBoxColumn,
            this.sIValueDataGridViewTextBoxColumn,
            this.buttonDelete});
            this.dataGridViewSystemInfo.DataSource = this.systemInfoListBindingSource;
            this.dataGridViewSystemInfo.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSystemInfo.Name = "dataGridViewSystemInfo";
            this.dataGridViewSystemInfo.ReadOnly = true;
            this.dataGridViewSystemInfo.Size = new System.Drawing.Size(474, 199);
            this.dataGridViewSystemInfo.TabIndex = 0;
            this.dataGridViewSystemInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSystemInfo_CellContentClick);
            // 
            // buttonNew
            // 
            this.buttonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNew.Location = new System.Drawing.Point(321, 181);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 9;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(402, 181);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(3, 32);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(34, 13);
            this.labelValue.TabIndex = 3;
            this.labelValue.Text = "Value";
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(3, 6);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(25, 13);
            this.labelKey.TabIndex = 2;
            this.labelKey.Text = "Key";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.systemInfoListBindingSource, "SIValue", true));
            this.textBoxDescription.Location = new System.Drawing.Point(69, 29);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(408, 146);
            this.textBoxDescription.TabIndex = 1;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.systemInfoListBindingSource, "SIKey", true));
            this.textBoxTitle.Location = new System.Drawing.Point(69, 3);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(408, 20);
            this.textBoxTitle.TabIndex = 0;
            // 
            // sIKeyDataGridViewTextBoxColumn
            // 
            this.sIKeyDataGridViewTextBoxColumn.DataPropertyName = "SIKey";
            this.sIKeyDataGridViewTextBoxColumn.HeaderText = "Key";
            this.sIKeyDataGridViewTextBoxColumn.Name = "sIKeyDataGridViewTextBoxColumn";
            this.sIKeyDataGridViewTextBoxColumn.ReadOnly = true;
            this.sIKeyDataGridViewTextBoxColumn.Width = 50;
            // 
            // sIValueDataGridViewTextBoxColumn
            // 
            this.sIValueDataGridViewTextBoxColumn.DataPropertyName = "SIValue";
            this.sIValueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.sIValueDataGridViewTextBoxColumn.Name = "sIValueDataGridViewTextBoxColumn";
            this.sIValueDataGridViewTextBoxColumn.ReadOnly = true;
            this.sIValueDataGridViewTextBoxColumn.Width = 59;
            // 
            // systemInfoListBindingSource
            // 
            this.systemInfoListBindingSource.DataSource = typeof(ChattersLib.ChattersDBLists.SystemInfoList);
            // 
            // SystemInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMenues);
            this.Name = "SystemInfoControl";
            this.Size = new System.Drawing.Size(486, 422);
            this.splitContainerMenues.Panel1.ResumeLayout(false);
            this.splitContainerMenues.Panel2.ResumeLayout(false);
            this.splitContainerMenues.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenues)).EndInit();
            this.splitContainerMenues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSystemInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemInfoListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMenues;
        private System.Windows.Forms.DataGridView dataGridViewSystemInfo;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource systemInfoListBindingSource;
        private System.Windows.Forms.DataGridViewButtonColumn buttonDelete;
    }
}
