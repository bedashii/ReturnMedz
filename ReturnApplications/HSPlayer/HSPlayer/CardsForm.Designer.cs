﻿namespace HSPlayer
{
    partial class CardsForm
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
            this.DataGridViewCardsList = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.additionalCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minAdditionalDamageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxExtraDamageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BindingSourceCardsList = new System.Windows.Forms.BindingSource(this.components);
            this.ListBoxHeroes = new System.Windows.Forms.ListBox();
            this.BindingSourceHeroesList = new System.Windows.Forms.BindingSource(this.components);
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.ButtonDecks = new System.Windows.Forms.Button();
            this.ButtonBuilder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCardsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCardsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceHeroesList)).BeginInit();
            this.SuspendLayout();
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
            this.nameDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.additionalCostDataGridViewTextBoxColumn,
            this.attackDataGridViewTextBoxColumn,
            this.minAdditionalDamageDataGridViewTextBoxColumn,
            this.maxExtraDamageDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn});
            this.DataGridViewCardsList.DataSource = this.BindingSourceCardsList;
            this.DataGridViewCardsList.Location = new System.Drawing.Point(12, 12);
            this.DataGridViewCardsList.Name = "DataGridViewCardsList";
            this.DataGridViewCardsList.RowHeadersVisible = false;
            this.DataGridViewCardsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewCardsList.Size = new System.Drawing.Size(527, 501);
            this.DataGridViewCardsList.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 40F;
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
            // ListBoxHeroes
            // 
            this.ListBoxHeroes.DataSource = this.BindingSourceHeroesList;
            this.ListBoxHeroes.DisplayMember = "Name";
            this.ListBoxHeroes.FormattingEnabled = true;
            this.ListBoxHeroes.Location = new System.Drawing.Point(545, 49);
            this.ListBoxHeroes.Name = "ListBoxHeroes";
            this.ListBoxHeroes.Size = new System.Drawing.Size(178, 251);
            this.ListBoxHeroes.TabIndex = 1;
            this.ListBoxHeroes.ValueMember = "ID";
            this.ListBoxHeroes.SelectedValueChanged += new System.EventHandler(this.ListBoxHeroes_SelectedValueChanged);
            // 
            // BindingSourceHeroesList
            // 
            this.BindingSourceHeroesList.DataSource = typeof(TempDataGenLib.Lists.HeroesList);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(648, 306);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 2;
            this.ButtonSave.Text = "&Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.Location = new System.Drawing.Point(545, 306);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(75, 23);
            this.ButtonRefresh.TabIndex = 2;
            this.ButtonRefresh.Text = "&Refresh";
            this.ButtonRefresh.UseVisualStyleBackColor = true;
            this.ButtonRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // ButtonDecks
            // 
            this.ButtonDecks.Location = new System.Drawing.Point(648, 20);
            this.ButtonDecks.Name = "ButtonDecks";
            this.ButtonDecks.Size = new System.Drawing.Size(75, 23);
            this.ButtonDecks.TabIndex = 3;
            this.ButtonDecks.Text = "Decks";
            this.ButtonDecks.UseVisualStyleBackColor = true;
            this.ButtonDecks.Click += new System.EventHandler(this.ButtonDecks_Click);
            // 
            // ButtonBuilder
            // 
            this.ButtonBuilder.Location = new System.Drawing.Point(545, 20);
            this.ButtonBuilder.Name = "ButtonBuilder";
            this.ButtonBuilder.Size = new System.Drawing.Size(75, 23);
            this.ButtonBuilder.TabIndex = 4;
            this.ButtonBuilder.Text = "Builder";
            this.ButtonBuilder.UseVisualStyleBackColor = true;
            this.ButtonBuilder.Click += new System.EventHandler(this.ButtonBuilder_Click);
            // 
            // CardsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 525);
            this.Controls.Add(this.ButtonBuilder);
            this.Controls.Add(this.ButtonDecks);
            this.Controls.Add(this.ButtonRefresh);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ListBoxHeroes);
            this.Controls.Add(this.DataGridViewCardsList);
            this.Name = "CardsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cards";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCardsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceCardsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceHeroesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewCardsList;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minAdditionalDamageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxExtraDamageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource BindingSourceCardsList;
        private System.Windows.Forms.ListBox ListBoxHeroes;
        private System.Windows.Forms.BindingSource BindingSourceHeroesList;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.Button ButtonDecks;
        private System.Windows.Forms.Button ButtonBuilder;
    }
}