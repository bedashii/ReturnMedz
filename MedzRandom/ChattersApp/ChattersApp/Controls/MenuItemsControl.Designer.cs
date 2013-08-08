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
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.recordsExistsDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.anyPropertyChangedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.menuItemListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelPicture = new System.Windows.Forms.Label();
            this.comboBoxMenu = new System.Windows.Forms.ComboBox();
            this.menuListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelMenu = new System.Windows.Forms.Label();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelFilterByMenu = new System.Windows.Forms.Label();
            this.comboBoxMenuListFilter = new System.Windows.Forms.ComboBox();
            this.menuListBindingSourceFilter = new System.Windows.Forms.BindingSource(this.components);
            this.buttonBullet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenuItems)).BeginInit();
            this.splitContainerMenuItems.Panel1.SuspendLayout();
            this.splitContainerMenuItems.Panel2.SuspendLayout();
            this.splitContainerMenuItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenuItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuListBindingSourceFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMenuItems
            // 
            this.splitContainerMenuItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMenuItems.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMenuItems.Location = new System.Drawing.Point(3, 58);
            this.splitContainerMenuItems.Name = "splitContainerMenuItems";
            this.splitContainerMenuItems.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMenuItems.Panel1
            // 
            this.splitContainerMenuItems.Panel1.Controls.Add(this.dataGridViewMenuItems);
            // 
            // splitContainerMenuItems.Panel2
            // 
            this.splitContainerMenuItems.Panel2.Controls.Add(this.buttonBullet);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.comboBox1);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.labelPicture);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.comboBoxMenu);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.labelMenu);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.buttonNew);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.buttonSave);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.labelPrice);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.labelDescription);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.labelTitle);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.textBoxPrice);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.textBoxDescription);
            this.splitContainerMenuItems.Panel2.Controls.Add(this.textBoxTitle);
            this.splitContainerMenuItems.Size = new System.Drawing.Size(662, 541);
            this.splitContainerMenuItems.SplitterDistance = 234;
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
            this.dataGridViewMenuItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMenuItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMenuItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.Price,
            this.MenuTitle,
            this.buttonDelete,
            this.recordsExistsDataGridViewCheckBoxColumn,
            this.anyPropertyChangedDataGridViewCheckBoxColumn});
            this.dataGridViewMenuItems.DataSource = this.menuItemListBindingSource;
            this.dataGridViewMenuItems.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewMenuItems.Name = "dataGridViewMenuItems";
            this.dataGridViewMenuItems.ReadOnly = true;
            this.dataGridViewMenuItems.Size = new System.Drawing.Size(656, 228);
            this.dataGridViewMenuItems.TabIndex = 0;
            this.dataGridViewMenuItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMenuItems_CellContentClick);
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
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 56;
            // 
            // MenuTitle
            // 
            this.MenuTitle.DataPropertyName = "MenuTitle";
            this.MenuTitle.HeaderText = "Menu";
            this.MenuTitle.Name = "MenuTitle";
            this.MenuTitle.ReadOnly = true;
            this.MenuTitle.Width = 59;
            // 
            // buttonDelete
            // 
            this.buttonDelete.HeaderText = "";
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.ReadOnly = true;
            this.buttonDelete.Width = 5;
            // 
            // recordsExistsDataGridViewCheckBoxColumn
            // 
            this.recordsExistsDataGridViewCheckBoxColumn.DataPropertyName = "RecordsExists";
            this.recordsExistsDataGridViewCheckBoxColumn.HeaderText = "RecordsExists";
            this.recordsExistsDataGridViewCheckBoxColumn.Name = "recordsExistsDataGridViewCheckBoxColumn";
            this.recordsExistsDataGridViewCheckBoxColumn.ReadOnly = true;
            this.recordsExistsDataGridViewCheckBoxColumn.Visible = false;
            this.recordsExistsDataGridViewCheckBoxColumn.Width = 80;
            // 
            // anyPropertyChangedDataGridViewCheckBoxColumn
            // 
            this.anyPropertyChangedDataGridViewCheckBoxColumn.DataPropertyName = "AnyPropertyChanged";
            this.anyPropertyChangedDataGridViewCheckBoxColumn.HeaderText = "AnyPropertyChanged";
            this.anyPropertyChangedDataGridViewCheckBoxColumn.Name = "anyPropertyChangedDataGridViewCheckBoxColumn";
            this.anyPropertyChangedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.anyPropertyChangedDataGridViewCheckBoxColumn.Visible = false;
            this.anyPropertyChangedDataGridViewCheckBoxColumn.Width = 113;
            // 
            // menuItemListBindingSource
            // 
            this.menuItemListBindingSource.DataSource = typeof(ChattersLib.ChattersDBLists.MenuItemList);
            this.menuItemListBindingSource.CurrentChanged += new System.EventHandler(this.menuItemListBindingSource_CurrentChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(69, 201);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(590, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // labelPicture
            // 
            this.labelPicture.AutoSize = true;
            this.labelPicture.Location = new System.Drawing.Point(3, 204);
            this.labelPicture.Name = "labelPicture";
            this.labelPicture.Size = new System.Drawing.Size(40, 13);
            this.labelPicture.TabIndex = 14;
            this.labelPicture.Text = "Picture";
            // 
            // comboBoxMenu
            // 
            this.comboBoxMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMenu.DataSource = this.menuListBindingSource;
            this.comboBoxMenu.DisplayMember = "Title";
            this.comboBoxMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMenu.FormattingEnabled = true;
            this.comboBoxMenu.Location = new System.Drawing.Point(69, 3);
            this.comboBoxMenu.Name = "comboBoxMenu";
            this.comboBoxMenu.Size = new System.Drawing.Size(590, 21);
            this.comboBoxMenu.TabIndex = 0;
            this.comboBoxMenu.ValueMember = "ID";
            this.comboBoxMenu.SelectedValueChanged += new System.EventHandler(this.comboBoxMenu_SelectedValueChanged);
            // 
            // menuListBindingSource
            // 
            this.menuListBindingSource.DataSource = typeof(ChattersLib.ChattersDBLists.MenuList);
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Location = new System.Drawing.Point(3, 6);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(34, 13);
            this.labelMenu.TabIndex = 12;
            this.labelMenu.Text = "Menu";
            // 
            // buttonNew
            // 
            this.buttonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNew.Location = new System.Drawing.Point(503, 277);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 6;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(584, 277);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(3, 178);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(31, 13);
            this.labelPrice.TabIndex = 5;
            this.labelPrice.Text = "Price";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(3, 92);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Description";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(3, 33);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(27, 13);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Title";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemListBindingSource, "Price", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.textBoxPrice.Location = new System.Drawing.Point(69, 175);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(590, 20);
            this.textBoxPrice.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemListBindingSource, "Description", true));
            this.textBoxDescription.Location = new System.Drawing.Point(69, 85);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(590, 84);
            this.textBoxDescription.TabIndex = 2;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuItemListBindingSource, "Title", true));
            this.textBoxTitle.Location = new System.Drawing.Point(69, 30);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(590, 20);
            this.textBoxTitle.TabIndex = 1;
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
            this.textBoxSearch.Location = new System.Drawing.Point(82, 5);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(502, 20);
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
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelFilterByMenu
            // 
            this.labelFilterByMenu.AutoSize = true;
            this.labelFilterByMenu.Location = new System.Drawing.Point(3, 34);
            this.labelFilterByMenu.Name = "labelFilterByMenu";
            this.labelFilterByMenu.Size = new System.Drawing.Size(73, 13);
            this.labelFilterByMenu.TabIndex = 4;
            this.labelFilterByMenu.Text = "Filter by Menu";
            // 
            // comboBoxMenuListFilter
            // 
            this.comboBoxMenuListFilter.DataSource = this.menuListBindingSourceFilter;
            this.comboBoxMenuListFilter.DisplayMember = "Title";
            this.comboBoxMenuListFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMenuListFilter.FormattingEnabled = true;
            this.comboBoxMenuListFilter.Location = new System.Drawing.Point(82, 31);
            this.comboBoxMenuListFilter.Name = "comboBoxMenuListFilter";
            this.comboBoxMenuListFilter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMenuListFilter.TabIndex = 5;
            this.comboBoxMenuListFilter.ValueMember = "Title";
            this.comboBoxMenuListFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxMenuListFilter_SelectedIndexChanged);
            // 
            // menuListBindingSourceFilter
            // 
            this.menuListBindingSourceFilter.DataSource = typeof(ChattersLib.ChattersDBLists.MenuList);
            // 
            // buttonBullet
            // 
            this.buttonBullet.Location = new System.Drawing.Point(69, 56);
            this.buttonBullet.Name = "buttonBullet";
            this.buttonBullet.Size = new System.Drawing.Size(23, 23);
            this.buttonBullet.TabIndex = 15;
            this.buttonBullet.Text = "•";
            this.buttonBullet.UseVisualStyleBackColor = true;
            this.buttonBullet.Click += new System.EventHandler(this.buttonBullet_Click);
            // 
            // MenuItemsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxMenuListFilter);
            this.Controls.Add(this.labelFilterByMenu);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.splitContainerMenuItems);
            this.Name = "MenuItemsControl";
            this.Size = new System.Drawing.Size(668, 602);
            this.Load += new System.EventHandler(this.MenuItemsControl_Load);
            this.splitContainerMenuItems.Panel1.ResumeLayout(false);
            this.splitContainerMenuItems.Panel2.ResumeLayout(false);
            this.splitContainerMenuItems.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMenuItems)).EndInit();
            this.splitContainerMenuItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenuItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuListBindingSourceFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMenuItems;
        private System.Windows.Forms.DataGridView dataGridViewMenuItems;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.BindingSource menuItemListBindingSource;
        private System.Windows.Forms.ComboBox comboBoxMenu;
        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.BindingSource menuListBindingSource;
        private System.Windows.Forms.Label labelFilterByMenu;
        private System.Windows.Forms.ComboBox comboBoxMenuListFilter;
        private System.Windows.Forms.BindingSource menuListBindingSourceFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuTitle;
        private System.Windows.Forms.DataGridViewButtonColumn buttonDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn recordsExistsDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn anyPropertyChangedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelPicture;
        private System.Windows.Forms.Button buttonBullet;
    }
}
