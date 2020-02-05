namespace LainsDecryptor
{
    partial class MainForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.completedFriendshipGuideModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ButtonOpenFile = new System.Windows.Forms.Button();
            this.TBoxFilePath = new System.Windows.Forms.TextBox();
            this.PanelFlowGuides = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.completedFriendshipGuideModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.completedFriendshipGuideModelBindingSource;
            this.listBox1.DisplayMember = "Person";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 54);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 160);
            this.listBox1.TabIndex = 0;
            this.listBox1.ValueMember = "Person";
            // 
            // completedFriendshipGuideModelBindingSource
            // 
            this.completedFriendshipGuideModelBindingSource.DataSource = typeof(LainsDecryptor.Models.CompletedFriendshipGuideModel);
            // 
            // ButtonOpenFile
            // 
            this.ButtonOpenFile.Location = new System.Drawing.Point(12, 12);
            this.ButtonOpenFile.Name = "ButtonOpenFile";
            this.ButtonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpenFile.TabIndex = 1;
            this.ButtonOpenFile.Text = "&Open";
            this.ButtonOpenFile.UseVisualStyleBackColor = true;
            this.ButtonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // TBoxFilePath
            // 
            this.TBoxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBoxFilePath.Location = new System.Drawing.Point(93, 14);
            this.TBoxFilePath.Name = "TBoxFilePath";
            this.TBoxFilePath.Size = new System.Drawing.Size(854, 20);
            this.TBoxFilePath.TabIndex = 2;
            // 
            // PanelFlowGuides
            // 
            this.PanelFlowGuides.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelFlowGuides.AutoScroll = true;
            this.PanelFlowGuides.Location = new System.Drawing.Point(138, 54);
            this.PanelFlowGuides.Name = "PanelFlowGuides";
            this.PanelFlowGuides.Size = new System.Drawing.Size(809, 538);
            this.PanelFlowGuides.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 604);
            this.Controls.Add(this.PanelFlowGuides);
            this.Controls.Add(this.TBoxFilePath);
            this.Controls.Add(this.ButtonOpenFile);
            this.Controls.Add(this.listBox1);
            this.Name = "MainForm";
            this.Text = "Lain\'s Decryptor";
            ((System.ComponentModel.ISupportInitialize)(this.completedFriendshipGuideModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button ButtonOpenFile;
        private System.Windows.Forms.TextBox TBoxFilePath;
        private System.Windows.Forms.BindingSource completedFriendshipGuideModelBindingSource;
        private System.Windows.Forms.FlowLayoutPanel PanelFlowGuides;
    }
}

