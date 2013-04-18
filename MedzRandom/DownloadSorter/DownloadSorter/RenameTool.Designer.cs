namespace DownloadSorter
{
    partial class RenameTool
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonRename = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkedListBoxRemovalWords = new System.Windows.Forms.CheckedListBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainerFilters = new System.Windows.Forms.SplitContainer();
            this.textBoxAddRemovalWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddRemovalWord = new System.Windows.Forms.Button();
            this.buttonInvertSelection = new System.Windows.Forms.Button();
            this.buttonDeselectAll = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.renameDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newFileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extentionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationFullPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceCustomFile = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxShowOnlyFilesToBeRenamed = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilters)).BeginInit();
            this.splitContainerFilters.Panel1.SuspendLayout();
            this.splitContainerFilters.Panel2.SuspendLayout();
            this.splitContainerFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomFile)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.renameDataGridViewCheckBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.newFileNameDataGridViewTextBoxColumn,
            this.extentionDataGridViewTextBoxColumn,
            this.fullPathDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.destinationFullPathDataGridViewTextBoxColumn,
            this.parentNameDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.bindingSourceCustomFile;
            this.dataGridView.Location = new System.Drawing.Point(0, 32);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(581, 163);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonRename
            // 
            this.buttonRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRename.Location = new System.Drawing.Point(518, 416);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(75, 23);
            this.buttonRename.TabIndex = 1;
            this.buttonRename.Text = "Rename";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(437, 416);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkedListBoxRemovalWords
            // 
            this.checkedListBoxRemovalWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxRemovalWords.FormattingEnabled = true;
            this.checkedListBoxRemovalWords.Location = new System.Drawing.Point(6, 29);
            this.checkedListBoxRemovalWords.Name = "checkedListBoxRemovalWords";
            this.checkedListBoxRemovalWords.Size = new System.Drawing.Size(281, 154);
            this.checkedListBoxRemovalWords.TabIndex = 3;
            this.checkedListBoxRemovalWords.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxRemovalWords_ItemCheck);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 12);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainerFilters);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.buttonInvertSelection);
            this.splitContainer.Panel2.Controls.Add(this.buttonDeselectAll);
            this.splitContainer.Panel2.Controls.Add(this.buttonSelectAll);
            this.splitContainer.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer.Size = new System.Drawing.Size(581, 398);
            this.splitContainer.SplitterDistance = 199;
            this.splitContainer.TabIndex = 4;
            // 
            // splitContainerFilters
            // 
            this.splitContainerFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFilters.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFilters.Name = "splitContainerFilters";
            // 
            // splitContainerFilters.Panel1
            // 
            this.splitContainerFilters.Panel1.Controls.Add(this.textBoxAddRemovalWord);
            this.splitContainerFilters.Panel1.Controls.Add(this.checkedListBoxRemovalWords);
            this.splitContainerFilters.Panel1.Controls.Add(this.label1);
            this.splitContainerFilters.Panel1.Controls.Add(this.buttonAddRemovalWord);
            // 
            // splitContainerFilters.Panel2
            // 
            this.splitContainerFilters.Panel2.Controls.Add(this.checkBoxShowOnlyFilesToBeRenamed);
            this.splitContainerFilters.Size = new System.Drawing.Size(581, 199);
            this.splitContainerFilters.SplitterDistance = 290;
            this.splitContainerFilters.TabIndex = 7;
            // 
            // textBoxAddRemovalWord
            // 
            this.textBoxAddRemovalWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddRemovalWord.Location = new System.Drawing.Point(109, 3);
            this.textBoxAddRemovalWord.Name = "textBoxAddRemovalWord";
            this.textBoxAddRemovalWord.Size = new System.Drawing.Size(143, 20);
            this.textBoxAddRemovalWord.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add Removal Word";
            // 
            // buttonAddRemovalWord
            // 
            this.buttonAddRemovalWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddRemovalWord.Location = new System.Drawing.Point(258, 1);
            this.buttonAddRemovalWord.Name = "buttonAddRemovalWord";
            this.buttonAddRemovalWord.Size = new System.Drawing.Size(29, 23);
            this.buttonAddRemovalWord.TabIndex = 6;
            this.buttonAddRemovalWord.Text = "+";
            this.buttonAddRemovalWord.UseVisualStyleBackColor = true;
            this.buttonAddRemovalWord.Click += new System.EventHandler(this.buttonAddRemovalWord_Click);
            // 
            // buttonInvertSelection
            // 
            this.buttonInvertSelection.Location = new System.Drawing.Point(165, 3);
            this.buttonInvertSelection.Name = "buttonInvertSelection";
            this.buttonInvertSelection.Size = new System.Drawing.Size(98, 23);
            this.buttonInvertSelection.TabIndex = 3;
            this.buttonInvertSelection.Text = "Invert Selection";
            this.buttonInvertSelection.UseVisualStyleBackColor = true;
            this.buttonInvertSelection.Click += new System.EventHandler(this.buttonInvertSelection_Click);
            // 
            // buttonDeselectAll
            // 
            this.buttonDeselectAll.Location = new System.Drawing.Point(84, 3);
            this.buttonDeselectAll.Name = "buttonDeselectAll";
            this.buttonDeselectAll.Size = new System.Drawing.Size(75, 23);
            this.buttonDeselectAll.TabIndex = 2;
            this.buttonDeselectAll.Text = "Deselect All";
            this.buttonDeselectAll.UseVisualStyleBackColor = true;
            this.buttonDeselectAll.Click += new System.EventHandler(this.buttonDeselectAll_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Location = new System.Drawing.Point(3, 3);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectAll.TabIndex = 1;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // renameDataGridViewCheckBoxColumn
            // 
            this.renameDataGridViewCheckBoxColumn.DataPropertyName = "Rename";
            this.renameDataGridViewCheckBoxColumn.HeaderText = "Rename";
            this.renameDataGridViewCheckBoxColumn.Name = "renameDataGridViewCheckBoxColumn";
            this.renameDataGridViewCheckBoxColumn.Width = 53;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNameDataGridViewTextBoxColumn.Width = 76;
            // 
            // newFileNameDataGridViewTextBoxColumn
            // 
            this.newFileNameDataGridViewTextBoxColumn.DataPropertyName = "NewFileName";
            this.newFileNameDataGridViewTextBoxColumn.HeaderText = "NewFileName";
            this.newFileNameDataGridViewTextBoxColumn.Name = "newFileNameDataGridViewTextBoxColumn";
            this.newFileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.newFileNameDataGridViewTextBoxColumn.Width = 98;
            // 
            // extentionDataGridViewTextBoxColumn
            // 
            this.extentionDataGridViewTextBoxColumn.DataPropertyName = "Extention";
            this.extentionDataGridViewTextBoxColumn.HeaderText = "Extention";
            this.extentionDataGridViewTextBoxColumn.Name = "extentionDataGridViewTextBoxColumn";
            this.extentionDataGridViewTextBoxColumn.Visible = false;
            this.extentionDataGridViewTextBoxColumn.Width = 76;
            // 
            // fullPathDataGridViewTextBoxColumn
            // 
            this.fullPathDataGridViewTextBoxColumn.DataPropertyName = "FullPath";
            this.fullPathDataGridViewTextBoxColumn.HeaderText = "FullPath";
            this.fullPathDataGridViewTextBoxColumn.Name = "fullPathDataGridViewTextBoxColumn";
            this.fullPathDataGridViewTextBoxColumn.Visible = false;
            this.fullPathDataGridViewTextBoxColumn.Width = 70;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            this.sizeDataGridViewTextBoxColumn.Visible = false;
            this.sizeDataGridViewTextBoxColumn.Width = 52;
            // 
            // destinationFullPathDataGridViewTextBoxColumn
            // 
            this.destinationFullPathDataGridViewTextBoxColumn.DataPropertyName = "DestinationFullPath";
            this.destinationFullPathDataGridViewTextBoxColumn.HeaderText = "DestinationFullPath";
            this.destinationFullPathDataGridViewTextBoxColumn.Name = "destinationFullPathDataGridViewTextBoxColumn";
            this.destinationFullPathDataGridViewTextBoxColumn.Visible = false;
            this.destinationFullPathDataGridViewTextBoxColumn.Width = 123;
            // 
            // parentNameDataGridViewTextBoxColumn
            // 
            this.parentNameDataGridViewTextBoxColumn.DataPropertyName = "ParentName";
            this.parentNameDataGridViewTextBoxColumn.HeaderText = "ParentName";
            this.parentNameDataGridViewTextBoxColumn.Name = "parentNameDataGridViewTextBoxColumn";
            this.parentNameDataGridViewTextBoxColumn.Visible = false;
            this.parentNameDataGridViewTextBoxColumn.Width = 91;
            // 
            // bindingSourceCustomFile
            // 
            this.bindingSourceCustomFile.DataSource = typeof(DownloadSorter.CustomFile);
            // 
            // checkBoxShowOnlyFilesToBeRenamed
            // 
            this.checkBoxShowOnlyFilesToBeRenamed.AutoSize = true;
            this.checkBoxShowOnlyFilesToBeRenamed.Checked = true;
            this.checkBoxShowOnlyFilesToBeRenamed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowOnlyFilesToBeRenamed.Location = new System.Drawing.Point(3, 7);
            this.checkBoxShowOnlyFilesToBeRenamed.Name = "checkBoxShowOnlyFilesToBeRenamed";
            this.checkBoxShowOnlyFilesToBeRenamed.Size = new System.Drawing.Size(182, 17);
            this.checkBoxShowOnlyFilesToBeRenamed.TabIndex = 0;
            this.checkBoxShowOnlyFilesToBeRenamed.Text = "Only Show Files To Be Renamed";
            this.checkBoxShowOnlyFilesToBeRenamed.UseVisualStyleBackColor = true;
            this.checkBoxShowOnlyFilesToBeRenamed.CheckedChanged += new System.EventHandler(this.checkBoxShowOnlyFilesToBeRenamed_CheckedChanged);
            // 
            // RenameTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 451);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonRename);
            this.Name = "RenameTool";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rename Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainerFilters.Panel1.ResumeLayout(false);
            this.splitContainerFilters.Panel1.PerformLayout();
            this.splitContainerFilters.Panel2.ResumeLayout(false);
            this.splitContainerFilters.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilters)).EndInit();
            this.splitContainerFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource bindingSourceCustomFile;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn renameDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newFileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extentionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationFullPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckedListBox checkedListBoxRemovalWords;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button buttonAddRemovalWord;
        private System.Windows.Forms.TextBox textBoxAddRemovalWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainerFilters;
        private System.Windows.Forms.Button buttonInvertSelection;
        private System.Windows.Forms.Button buttonDeselectAll;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.CheckBox checkBoxShowOnlyFilesToBeRenamed;
    }
}