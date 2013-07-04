namespace ChattersApp.Controls
{
    partial class MenusControl
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
            this.splitContainerMenues = new System.Windows.Forms.SplitContainer();
            this.dataGridViewMenus = new System.Windows.Forms.DataGridView();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenues)).BeginInit();
            this.splitContainerMenues.Panel1.SuspendLayout();
            this.splitContainerMenues.Panel2.SuspendLayout();
            this.splitContainerMenues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuListBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainerMenues.Panel1.Controls.Add(this.dataGridViewMenus);
            // 
            // splitContainerMenues.Panel2
            // 
            this.splitContainerMenues.Panel2.Controls.Add(this.buttonNew);
            this.splitContainerMenues.Panel2.Controls.Add(this.buttonSave);
            this.splitContainerMenues.Panel2.Controls.Add(this.labelDescription);
            this.splitContainerMenues.Panel2.Controls.Add(this.labelTitle);
            this.splitContainerMenues.Panel2.Controls.Add(this.textBoxDescription);
            this.splitContainerMenues.Panel2.Controls.Add(this.textBoxTitle);
            this.splitContainerMenues.Size = new System.Drawing.Size(410, 314);
            this.splitContainerMenues.SplitterDistance = 155;
            this.splitContainerMenues.TabIndex = 0;
            // 
            // dataGridViewMenus
            // 
            this.dataGridViewMenus.AllowUserToAddRows = false;
            this.dataGridViewMenus.AllowUserToDeleteRows = false;
            this.dataGridViewMenus.AutoGenerateColumns = false;
            this.dataGridViewMenus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMenus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMenus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.buttonDelete});
            this.dataGridViewMenus.DataSource = this.menuListBindingSource;
            this.dataGridViewMenus.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewMenus.Name = "dataGridViewMenus";
            this.dataGridViewMenus.ReadOnly = true;
            this.dataGridViewMenus.Size = new System.Drawing.Size(404, 149);
            this.dataGridViewMenus.TabIndex = 0;
            this.dataGridViewMenus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMenus_CellContentClick);
            // 
            // buttonNew
            // 
            this.buttonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNew.Location = new System.Drawing.Point(251, 129);
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
            this.buttonSave.Location = new System.Drawing.Point(332, 129);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(3, 32);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "Description";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(3, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(27, 13);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Title";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuListBindingSource, "Description", true));
            this.textBoxDescription.Location = new System.Drawing.Point(69, 29);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(338, 20);
            this.textBoxDescription.TabIndex = 1;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuListBindingSource, "Title", true));
            this.textBoxTitle.Location = new System.Drawing.Point(69, 3);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(338, 20);
            this.textBoxTitle.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.HeaderText = "";
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.ReadOnly = true;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Width = 5;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 43;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 52;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 85;
            // 
            // menuListBindingSource
            // 
            this.menuListBindingSource.DataSource = typeof(ChattersLib.ChattersDBLists.MenuList);
            // 
            // MenusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMenues);
            this.Name = "MenusControl";
            this.Size = new System.Drawing.Size(416, 320);
            this.splitContainerMenues.Panel1.ResumeLayout(false);
            this.splitContainerMenues.Panel2.ResumeLayout(false);
            this.splitContainerMenues.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenues)).EndInit();
            this.splitContainerMenues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMenues;
        private System.Windows.Forms.DataGridView dataGridViewMenus;
        private System.Windows.Forms.BindingSource menuListBindingSource;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn buttonDelete;
    }
}
