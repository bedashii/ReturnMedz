namespace HSPlayer
{
    partial class DecksForm
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
            this.DataGridViewDecks = new System.Windows.Forms.DataGridView();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardAttackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardDurationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardMinAdditionalDamageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardMaxAdditionalDamageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardAdditionalCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardMemberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deckMemberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deckDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BindingSourceDeckCardsList = new System.Windows.Forms.BindingSource(this.components);
            this.ListBoxDecks = new System.Windows.Forms.ListBox();
            this.BindingSourceDecksList = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDeckCardsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDecksList)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewDecks
            // 
            this.DataGridViewDecks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewDecks.AutoGenerateColumns = false;
            this.DataGridViewDecks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewDecks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewDecks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.quantityDataGridViewTextBoxColumn,
            this.Column1,
            this.cardCostDataGridViewTextBoxColumn,
            this.cardAttackDataGridViewTextBoxColumn,
            this.cardDurationDataGridViewTextBoxColumn,
            this.cardMinAdditionalDamageDataGridViewTextBoxColumn,
            this.cardMaxAdditionalDamageDataGridViewTextBoxColumn,
            this.cardAdditionalCostDataGridViewTextBoxColumn,
            this.cardMemberDataGridViewTextBoxColumn,
            this.deckMemberDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn,
            this.deckDataGridViewTextBoxColumn,
            this.cardDataGridViewTextBoxColumn});
            this.DataGridViewDecks.DataSource = this.BindingSourceDeckCardsList;
            this.DataGridViewDecks.Location = new System.Drawing.Point(12, 12);
            this.DataGridViewDecks.Name = "DataGridViewDecks";
            this.DataGridViewDecks.RowHeadersVisible = false;
            this.DataGridViewDecks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewDecks.Size = new System.Drawing.Size(433, 376);
            this.DataGridViewDecks.TabIndex = 0;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.FillWeight = 10F;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CardName";
            this.Column1.FillWeight = 30F;
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // cardCostDataGridViewTextBoxColumn
            // 
            this.cardCostDataGridViewTextBoxColumn.DataPropertyName = "CardCost";
            this.cardCostDataGridViewTextBoxColumn.FillWeight = 10F;
            this.cardCostDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.cardCostDataGridViewTextBoxColumn.Name = "cardCostDataGridViewTextBoxColumn";
            this.cardCostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardAttackDataGridViewTextBoxColumn
            // 
            this.cardAttackDataGridViewTextBoxColumn.DataPropertyName = "CardAttack";
            this.cardAttackDataGridViewTextBoxColumn.FillWeight = 10F;
            this.cardAttackDataGridViewTextBoxColumn.HeaderText = "Att";
            this.cardAttackDataGridViewTextBoxColumn.Name = "cardAttackDataGridViewTextBoxColumn";
            this.cardAttackDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardDurationDataGridViewTextBoxColumn
            // 
            this.cardDurationDataGridViewTextBoxColumn.DataPropertyName = "CardDuration";
            this.cardDurationDataGridViewTextBoxColumn.FillWeight = 10F;
            this.cardDurationDataGridViewTextBoxColumn.HeaderText = "Dur";
            this.cardDurationDataGridViewTextBoxColumn.Name = "cardDurationDataGridViewTextBoxColumn";
            this.cardDurationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardMinAdditionalDamageDataGridViewTextBoxColumn
            // 
            this.cardMinAdditionalDamageDataGridViewTextBoxColumn.DataPropertyName = "CardMinAdditionalDamage";
            this.cardMinAdditionalDamageDataGridViewTextBoxColumn.FillWeight = 10F;
            this.cardMinAdditionalDamageDataGridViewTextBoxColumn.HeaderText = "0Dmg+";
            this.cardMinAdditionalDamageDataGridViewTextBoxColumn.Name = "cardMinAdditionalDamageDataGridViewTextBoxColumn";
            this.cardMinAdditionalDamageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardMaxAdditionalDamageDataGridViewTextBoxColumn
            // 
            this.cardMaxAdditionalDamageDataGridViewTextBoxColumn.DataPropertyName = "CardMaxAdditionalDamage";
            this.cardMaxAdditionalDamageDataGridViewTextBoxColumn.FillWeight = 10F;
            this.cardMaxAdditionalDamageDataGridViewTextBoxColumn.HeaderText = "9Dmg+";
            this.cardMaxAdditionalDamageDataGridViewTextBoxColumn.Name = "cardMaxAdditionalDamageDataGridViewTextBoxColumn";
            this.cardMaxAdditionalDamageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardAdditionalCostDataGridViewTextBoxColumn
            // 
            this.cardAdditionalCostDataGridViewTextBoxColumn.DataPropertyName = "CardAdditionalCost";
            this.cardAdditionalCostDataGridViewTextBoxColumn.FillWeight = 10F;
            this.cardAdditionalCostDataGridViewTextBoxColumn.HeaderText = "Cost+";
            this.cardAdditionalCostDataGridViewTextBoxColumn.Name = "cardAdditionalCostDataGridViewTextBoxColumn";
            this.cardAdditionalCostDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cardMemberDataGridViewTextBoxColumn
            // 
            this.cardMemberDataGridViewTextBoxColumn.DataPropertyName = "CardMember";
            this.cardMemberDataGridViewTextBoxColumn.HeaderText = "CardMember";
            this.cardMemberDataGridViewTextBoxColumn.Name = "cardMemberDataGridViewTextBoxColumn";
            this.cardMemberDataGridViewTextBoxColumn.Visible = false;
            // 
            // deckMemberDataGridViewTextBoxColumn
            // 
            this.deckMemberDataGridViewTextBoxColumn.DataPropertyName = "DeckMember";
            this.deckMemberDataGridViewTextBoxColumn.HeaderText = "DeckMember";
            this.deckMemberDataGridViewTextBoxColumn.Name = "deckMemberDataGridViewTextBoxColumn";
            this.deckMemberDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // deckDataGridViewTextBoxColumn
            // 
            this.deckDataGridViewTextBoxColumn.DataPropertyName = "Deck";
            this.deckDataGridViewTextBoxColumn.HeaderText = "Deck";
            this.deckDataGridViewTextBoxColumn.Name = "deckDataGridViewTextBoxColumn";
            this.deckDataGridViewTextBoxColumn.Visible = false;
            // 
            // cardDataGridViewTextBoxColumn
            // 
            this.cardDataGridViewTextBoxColumn.DataPropertyName = "Card";
            this.cardDataGridViewTextBoxColumn.HeaderText = "Card";
            this.cardDataGridViewTextBoxColumn.Name = "cardDataGridViewTextBoxColumn";
            this.cardDataGridViewTextBoxColumn.Visible = false;
            // 
            // BindingSourceDeckCardsList
            // 
            this.BindingSourceDeckCardsList.DataSource = typeof(TempDataGenLib.Business.DeckCards);
            // 
            // ListBoxDecks
            // 
            this.ListBoxDecks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxDecks.DataSource = this.BindingSourceDecksList;
            this.ListBoxDecks.DisplayMember = "Name";
            this.ListBoxDecks.FormattingEnabled = true;
            this.ListBoxDecks.Location = new System.Drawing.Point(451, 12);
            this.ListBoxDecks.Name = "ListBoxDecks";
            this.ListBoxDecks.Size = new System.Drawing.Size(177, 173);
            this.ListBoxDecks.TabIndex = 1;
            this.ListBoxDecks.ValueMember = "ID";
            this.ListBoxDecks.SelectedValueChanged += new System.EventHandler(this.ListBoxDecks_SelectedValueChanged);
            // 
            // BindingSourceDecksList
            // 
            this.BindingSourceDecksList.DataSource = typeof(TempDataGenLib.Lists.DecksList);
            // 
            // DecksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 400);
            this.Controls.Add(this.ListBoxDecks);
            this.Controls.Add(this.DataGridViewDecks);
            this.Name = "DecksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Decks";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDeckCardsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceDecksList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewDecks;
        private System.Windows.Forms.BindingSource BindingSourceDeckCardsList;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardAttackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardDurationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardMinAdditionalDamageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardMaxAdditionalDamageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardAdditionalCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardMemberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deckMemberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deckDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardDataGridViewTextBoxColumn;
        private System.Windows.Forms.ListBox ListBoxDecks;
        private System.Windows.Forms.BindingSource BindingSourceDecksList;
    }
}