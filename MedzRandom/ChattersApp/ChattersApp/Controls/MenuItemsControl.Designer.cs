namespace ChattersApp.Controls
{
    partial class MenuItemsControl
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
            this.splitContainerMenuItems = new System.Windows.Forms.SplitContainer();
            this.dataGridViewMenuItems = new System.Windows.Forms.DataGridView();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.menuItemListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordsExistsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.anyPropertyChangedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenuItems)).BeginInit();
            this.splitContainerMenuItems.Panel1.SuspendLayout();
            this.splitContainerMenuItems.Panel2.SuspendLayout();
            this.splitContainerMenuItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenuItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMenuItems
            // 
            this.splitContainerMenuItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMenuItems.Location = new System.Drawing.Point(3, 32);
            this.splitContainerMenuItems.Name = "splitContainerMenuItems";
            this.splitContainerMenuItems.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMenuItems.Panel1
            // 
            this.splitContainerMenuItems.Panel1.Controls.Add(this.dataGridViewMenuItems);
            // 
            // splitContainerMenuItems.Panel2
            // 
            this.splitContainerMenuItems.Panel2.Controls.Add(this.buttonNew);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.buttonSave);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.labelPrice);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.labelDescription);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.labelTitle);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.textBox3);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.textBox2);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.textBox1);
            this.splitContainerMenuItems.Size = new System.Drawing.Size(662, 468);
            this.splitContainerMenuItems.SplitterDistance = 206;
            this.splitContainerMenuItems.TabIndex = 0;
            // 
            // dataGridViewMenuItems
            // 
            this.dataGridViewMenuItems.AllowUserToAddRows = false;
            this.dataGridViewMenuItems.AllowUserToDeleteRows = false;
            this.dataGridViewMenuItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMenuItems.AutoGenerateColumns = false;
            this.dataGridViewMenuItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMenuItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.recordsExistsDataGridViewCheckBoxColumn,
            this.anyPropertyChangedDataGridViewCheckBoxColumn});
            this.dataGridViewMenuItems.DataSource = this.menuItemListBindingSource;
            this.dataGridViewMenuItems.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewMenuItems.Name = "dataGridViewMenuItems";
            this.dataGridViewMenuItems.ReadOnly = true;
            this.dataGridViewMenuItems.Size = new System.Drawing.Size(656, 200);
            this.dataGridViewMenuItems.TabIndex = 0;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(3, 8);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(41, 13);
            this.labelSearch.TabIndex = 1;
            this.labelSearch.Text = "Search";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.Location = new System.Drawing.Point(50, 5);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(534, 20);
            this.textBoxSearch.TabIndex = 2;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(590, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(69, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(590, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(69, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(590, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(69, 55);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(590, 20);
            this.textBox3.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(3, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(27, 13);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Title";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(3, 32);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Description";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(3, 58);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(31, 13);
            this.labelPrice.TabIndex = 5;
            this.labelPrice.Text = "Price";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(584, 232);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNew.Location = new System.Drawing.Point(503, 232);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 7;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // menuItemListBindingSource
            // 
            this.menuItemListBindingSource.DataSource = typeof(ChattersLib.ChattersDBLists.MenuItemList);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // recordsExistsDataGridViewCheckBoxColumn
            // 
            this.recordsExistsDataGridViewCheckBoxColumn.DataPropertyName = "RecordsExists";
            this.recordsExistsDataGridViewCheckBoxColumn.HeaderText = "RecordsExists";
            this.recordsExistsDataGridViewCheckBoxColumn.Name = "recordsExistsDataGridViewCheckBoxColumn";
            this.recordsExistsDataGridViewCheckBoxColumn.ReadOnly = true;
            this.recordsExistsDataGridViewCheckBoxColumn.Visible = false;
            // 
            // anyPropertyChangedDataGridViewCheckBoxColumn
            // 
            this.anyPropertyChangedDataGridViewCheckBoxColumn.DataPropertyName = "AnyPropertyChanged";
            this.anyPropertyChangedDataGridViewCheckBoxColumn.HeaderText = "AnyPropertyChanged";
            this.anyPropertyChangedDataGridViewCheckBoxColumn.Name = "anyPropertyChangedDataGridViewCheckBoxColumn";
            this.anyPropertyChangedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.anyPropertyChangedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // MenuItemsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.splitContainerMenuItems);
            this.Name = "MenuItemsControl";
            this.Size = new System.Drawing.Size(668, 503);
            this.splitContainerMenuItems.Panel1.ResumeLayout(false);
            this.splitContainerMenuItems.Panel2.ResumeLayout(false);
            this.splitContainerMenuItems.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenuItems)).EndInit();
            this.splitContainerMenuItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenuItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMenuItems;
        private System.Windows.Forms.DataGridView dataGridViewMenuItems;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn recordsExistsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn anyPropertyChangedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource menuItemListBindingSource;
    }
}
