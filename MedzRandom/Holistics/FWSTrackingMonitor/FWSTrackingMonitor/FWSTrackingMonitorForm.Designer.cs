namespace FWSTrackingMonitor
{
    partial class FWSTrackingMonitorForm
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
            this.checkBoxAutoRefresh = new System.Windows.Forms.CheckBox();
            this.dataGridViewFWSTracking = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sessionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchOwnerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.replyCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.replyMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fWSTrackingListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.timerAutoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFWSTracking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fWSTrackingListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoRefresh.AutoSize = true;
            this.checkBoxAutoRefresh.Location = new System.Drawing.Point(400, 12);
            this.checkBoxAutoRefresh.Name = "checkBoxAutoRefresh";
            this.checkBoxAutoRefresh.Size = new System.Drawing.Size(88, 17);
            this.checkBoxAutoRefresh.TabIndex = 0;
            this.checkBoxAutoRefresh.Text = "Auto Refresh";
            this.checkBoxAutoRefresh.UseVisualStyleBackColor = true;
            this.checkBoxAutoRefresh.CheckedChanged += new System.EventHandler(this.checkBoxAutoRefresh_CheckedChanged);
            // 
            // dataGridViewFWSTracking
            // 
            this.dataGridViewFWSTracking.AllowUserToAddRows = false;
            this.dataGridViewFWSTracking.AllowUserToDeleteRows = false;
            this.dataGridViewFWSTracking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFWSTracking.AutoGenerateColumns = false;
            this.dataGridViewFWSTracking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewFWSTracking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFWSTracking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.packageCodeDataGridViewTextBoxColumn,
            this.completeDataGridViewCheckBoxColumn,
            this.sessionDataGridViewTextBoxColumn,
            this.batchDataGridViewTextBoxColumn,
            this.batchOwnerDataGridViewTextBoxColumn,
            this.requestIDDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.replyCodeDataGridViewTextBoxColumn,
            this.replyMessageDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.dataGridViewFWSTracking.DataSource = this.fWSTrackingListBindingSource;
            this.dataGridViewFWSTracking.Location = new System.Drawing.Point(12, 35);
            this.dataGridViewFWSTracking.Name = "dataGridViewFWSTracking";
            this.dataGridViewFWSTracking.ReadOnly = true;
            this.dataGridViewFWSTracking.Size = new System.Drawing.Size(476, 300);
            this.dataGridViewFWSTracking.TabIndex = 1;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 43;
            // 
            // packageCodeDataGridViewTextBoxColumn
            // 
            this.packageCodeDataGridViewTextBoxColumn.DataPropertyName = "PackageCode";
            this.packageCodeDataGridViewTextBoxColumn.HeaderText = "PackageCode";
            this.packageCodeDataGridViewTextBoxColumn.Name = "packageCodeDataGridViewTextBoxColumn";
            this.packageCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // completeDataGridViewCheckBoxColumn
            // 
            this.completeDataGridViewCheckBoxColumn.DataPropertyName = "Complete";
            this.completeDataGridViewCheckBoxColumn.HeaderText = "Complete";
            this.completeDataGridViewCheckBoxColumn.Name = "completeDataGridViewCheckBoxColumn";
            this.completeDataGridViewCheckBoxColumn.ReadOnly = true;
            this.completeDataGridViewCheckBoxColumn.Width = 57;
            // 
            // sessionDataGridViewTextBoxColumn
            // 
            this.sessionDataGridViewTextBoxColumn.DataPropertyName = "Session";
            this.sessionDataGridViewTextBoxColumn.HeaderText = "Session";
            this.sessionDataGridViewTextBoxColumn.Name = "sessionDataGridViewTextBoxColumn";
            this.sessionDataGridViewTextBoxColumn.ReadOnly = true;
            this.sessionDataGridViewTextBoxColumn.Width = 69;
            // 
            // batchDataGridViewTextBoxColumn
            // 
            this.batchDataGridViewTextBoxColumn.DataPropertyName = "Batch";
            this.batchDataGridViewTextBoxColumn.HeaderText = "Batch";
            this.batchDataGridViewTextBoxColumn.Name = "batchDataGridViewTextBoxColumn";
            this.batchDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchDataGridViewTextBoxColumn.Width = 60;
            // 
            // batchOwnerDataGridViewTextBoxColumn
            // 
            this.batchOwnerDataGridViewTextBoxColumn.DataPropertyName = "BatchOwner";
            this.batchOwnerDataGridViewTextBoxColumn.HeaderText = "BatchOwner";
            this.batchOwnerDataGridViewTextBoxColumn.Name = "batchOwnerDataGridViewTextBoxColumn";
            this.batchOwnerDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchOwnerDataGridViewTextBoxColumn.Width = 91;
            // 
            // requestIDDataGridViewTextBoxColumn
            // 
            this.requestIDDataGridViewTextBoxColumn.DataPropertyName = "RequestID";
            this.requestIDDataGridViewTextBoxColumn.HeaderText = "RequestID";
            this.requestIDDataGridViewTextBoxColumn.Name = "requestIDDataGridViewTextBoxColumn";
            this.requestIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.requestIDDataGridViewTextBoxColumn.Width = 83;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 55;
            // 
            // replyCodeDataGridViewTextBoxColumn
            // 
            this.replyCodeDataGridViewTextBoxColumn.DataPropertyName = "ReplyCode";
            this.replyCodeDataGridViewTextBoxColumn.HeaderText = "ReplyCode";
            this.replyCodeDataGridViewTextBoxColumn.Name = "replyCodeDataGridViewTextBoxColumn";
            this.replyCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.replyCodeDataGridViewTextBoxColumn.Width = 84;
            // 
            // replyMessageDataGridViewTextBoxColumn
            // 
            this.replyMessageDataGridViewTextBoxColumn.DataPropertyName = "ReplyMessage";
            this.replyMessageDataGridViewTextBoxColumn.HeaderText = "ReplyMessage";
            this.replyMessageDataGridViewTextBoxColumn.Name = "replyMessageDataGridViewTextBoxColumn";
            this.replyMessageDataGridViewTextBoxColumn.ReadOnly = true;
            this.replyMessageDataGridViewTextBoxColumn.Width = 102;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 68;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 71;
            // 
            // fWSTrackingListBindingSource
            // 
            this.fWSTrackingListBindingSource.DataSource = typeof(ThirdPartyProcessingGenLib.Lists.FWSTrackingList);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(12, 8);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // timerAutoRefreshTimer
            // 
            this.timerAutoRefreshTimer.Interval = 10000;
            this.timerAutoRefreshTimer.Tick += new System.EventHandler(this.timerAutoRefreshTimer_Tick);
            // 
            // FWSTrackingMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 347);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.dataGridViewFWSTracking);
            this.Controls.Add(this.checkBoxAutoRefresh);
            this.Name = "FWSTrackingMonitorForm";
            this.Text = "FWSTracking Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFWSTracking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fWSTrackingListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAutoRefresh;
        private System.Windows.Forms.DataGridView dataGridViewFWSTracking;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn completeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sessionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchOwnerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn replyCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn replyMessageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource fWSTrackingListBindingSource;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Timer timerAutoRefreshTimer;
    }
}

