namespace PlusPlay.UIControls
{
    partial class UIPictureBox
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
            this.PictureBoxMain = new System.Windows.Forms.PictureBox();
            this.LabelNameDisplay = new System.Windows.Forms.Label();
            this.PanelMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).BeginInit();
            this.PanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBoxMain
            // 
            this.PictureBoxMain.Location = new System.Drawing.Point(5, 20);
            this.PictureBoxMain.Name = "PictureBoxMain";
            this.PictureBoxMain.Size = new System.Drawing.Size(150, 150);
            this.PictureBoxMain.TabIndex = 0;
            this.PictureBoxMain.TabStop = false;
            this.PictureBoxMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMain_MouseClick);
            // 
            // LabelNameDisplay
            // 
            this.LabelNameDisplay.AutoSize = true;
            this.LabelNameDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelNameDisplay.Location = new System.Drawing.Point(5, 2);
            this.LabelNameDisplay.Name = "LabelNameDisplay";
            this.LabelNameDisplay.Size = new System.Drawing.Size(21, 15);
            this.LabelNameDisplay.TabIndex = 1;
            this.LabelNameDisplay.Text = "01";
            // 
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.LabelNameDisplay);
            this.PanelMain.Controls.Add(this.PictureBoxMain);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(160, 180);
            this.PanelMain.TabIndex = 2;
            // 
            // UIPictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelMain);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UIPictureBox";
            this.Size = new System.Drawing.Size(160, 180);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UIPictureBox_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMain)).EndInit();
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxMain;
        private System.Windows.Forms.Label LabelNameDisplay;
        private System.Windows.Forms.Panel PanelMain;
    }
}
