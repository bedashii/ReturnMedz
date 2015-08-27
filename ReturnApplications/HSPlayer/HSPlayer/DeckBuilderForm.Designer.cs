namespace HSPlayer
{
    partial class DeckBuilderForm
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
            this.LabelSearch = new System.Windows.Forms.Label();
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.DataGridViewCardsList = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.additionalCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minAdditionalDamageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxExtraDamageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BindingSourceCardsList = new System.Windows.Forms.BindingSource(this.components);
            this.LabelClass = new System.Windows.Forms.Label();
            this.ComboBoxHeroesList = new System.Windows.Forms.ComboBox();
            this.BindingSourceHeroesList = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCardsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCardsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceHeroesList)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelSearch
            // 
            this.LabelSearch.AutoSize = true;
            this.LabelSearch.Location = new System.Drawing.Point(9, 15);
            this.LabelSearch.Name = "LabelSearch";
            this.LabelSearch.Size = new System.Drawing.Size(41, 13);
            this.LabelSearch.TabIndex = 2;
            this.LabelSearch.Text = "Search";
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.Location = new System.Drawing.Point(56, 11);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(371, 20);
            this.TextBoxSearch.TabIndex = 3;
            this.TextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearch_KeyDown);
            // 
            // DataGridViewCardsList
            // 
            this.DataGridViewCardsList.AllowUserToAddRows = false;
            this.DataGridViewCardsList.AllowUserToDeleteRows = false;
            this.DataGridViewCardsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewCardsList.AutoGenerateColumns = false;
            this.DataGridViewCardsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewCardsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewCardsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.Column1,
            this.nameDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.additionalCostDataGridViewTextBoxColumn,
            this.attackDataGridViewTextBoxColumn,
            this.minAdditionalDamageDataGridViewTextBoxColumn,
            this.maxExtraDamageDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn});
            this.DataGridViewCardsList.DataSource = this.BindingSourceCardsList;
            this.DataGridViewCardsList.Location = new System.Drawing.Point(12, 38);
            this.DataGridViewCardsList.Name = "DataGridViewCardsList";
            this.DataGridViewCardsList.RowHeadersVisible = false;
            this.DataGridViewCardsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewCardsList.Size = new System.Drawing.Size(616, 348);
            this.DataGridViewCardsList.TabIndex = 4;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Count";
            this.Column1.FillWeight = 10F;
            this.Column1.HeaderText = "Count";
            this.Column1.Name = "Column1";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 30F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.FillWeight = 10F;
            this.costDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            // 
            // additionalCostDataGridViewTextBoxColumn
            // 
            this.additionalCostDataGridViewTextBoxColumn.DataPropertyName = "AdditionalCost";
            this.additionalCostDataGridViewTextBoxColumn.FillWeight = 10F;
            this.additionalCostDataGridViewTextBoxColumn.HeaderText = "+Cost";
            this.additionalCostDataGridViewTextBoxColumn.Name = "additionalCostDataGridViewTextBoxColumn";
            // 
            // attackDataGridViewTextBoxColumn
            // 
            this.attackDataGridViewTextBoxColumn.DataPropertyName = "Attack";
            this.attackDataGridViewTextBoxColumn.FillWeight = 10F;
            this.attackDataGridViewTextBoxColumn.HeaderText = "Attack";
            this.attackDataGridViewTextBoxColumn.Name = "attackDataGridViewTextBoxColumn";
            // 
            // minAdditionalDamageDataGridViewTextBoxColumn
            // 
            this.minAdditionalDamageDataGridViewTextBoxColumn.DataPropertyName = "MinAdditionalDamage";
            this.minAdditionalDamageDataGridViewTextBoxColumn.FillWeight = 10F;
            this.minAdditionalDamageDataGridViewTextBoxColumn.HeaderText = "Min +Att";
            this.minAdditionalDamageDataGridViewTextBoxColumn.Name = "minAdditionalDamageDataGridViewTextBoxColumn";
            // 
            // maxExtraDamageDataGridViewTextBoxColumn
            // 
            this.maxExtraDamageDataGridViewTextBoxColumn.DataPropertyName = "MaxExtraDamage";
            this.maxExtraDamageDataGridViewTextBoxColumn.FillWeight = 10F;
            this.maxExtraDamageDataGridViewTextBoxColumn.HeaderText = "Max +Att";
            this.maxExtraDamageDataGridViewTextBoxColumn.Name = "maxExtraDamageDataGridViewTextBoxColumn";
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.FillWeight = 10F;
            this.durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            // 
            // BindingSourceCardsList
            // 
            this.BindingSourceCardsList.DataSource = typeof(TempDataGenLib.Lists.CardsList);
            // 
            // LabelClass
            // 
            this.LabelClass.AutoSize = true;
            this.LabelClass.Location = new System.Drawing.Point(457, 15);
            this.LabelClass.Name = "LabelClass";
            this.LabelClass.Size = new System.Drawing.Size(32, 13);
            this.LabelClass.TabIndex = 2;
            this.LabelClass.Text = "Class";
            // 
            // ComboBoxHeroesList
            // 
            this.ComboBoxHeroesList.DataSource = this.BindingSourceHeroesList;
            this.ComboBoxHeroesList.DisplayMember = "Class";
            this.ComboBoxHeroesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxHeroesList.FormattingEnabled = true;
            this.ComboBoxHeroesList.Location = new System.Drawing.Point(495, 11);
            this.ComboBoxHeroesList.Name = "ComboBoxHeroesList";
            this.ComboBoxHeroesList.Size = new System.Drawing.Size(133, 21);
            this.ComboBoxHeroesList.TabIndex = 5;
            this.ComboBoxHeroesList.ValueMember = "ID";
            this.ComboBoxHeroesList.SelectedValueChanged += new System.EventHandler(this.ComboBoxHeroesList_SelectedValueChanged);
            // 
            // BindingSourceHeroesList
            // 
            this.BindingSourceHeroesList.DataSource = typeof(TempDataGenLib.Lists.HeroesList);
            // 
            // DeckBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 398);
            this.Controls.Add(this.ComboBoxHeroesList);
            this.Controls.Add(this.DataGridViewCardsList);
            this.Controls.Add(this.TextBoxSearch);
            this.Controls.Add(this.LabelClass);
            this.Controls.Add(this.LabelSearch);
            this.Name = "DeckBuilderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deck Builder";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCardsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCardsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceHeroesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelSearch;
        private System.Windows.Forms.TextBox TextBoxSearch;
        private System.Windows.Forms.BindingSource BindingSourceCardsList;
        private System.Windows.Forms.DataGridView DataGridViewCardsList;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minAdditionalDamageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxExtraDamageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label LabelClass;
        private System.Windows.Forms.ComboBox ComboBoxHeroesList;
        private System.Windows.Forms.BindingSource BindingSourceHeroesList;
    }
}