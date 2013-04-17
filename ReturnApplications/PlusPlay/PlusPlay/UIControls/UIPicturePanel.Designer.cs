namespace PlusPlay.UIControls
{
    partial class UIPicturePanel
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
            this.FlowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FlowLayoutPanelMain
            // 
            this.FlowLayoutPanelMain.AutoScroll = true;
            this.FlowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.FlowLayoutPanelMain.Name = "FlowLayoutPanelMain";
            this.FlowLayoutPanelMain.Size = new System.Drawing.Size(162, 176);
            this.FlowLayoutPanelMain.TabIndex = 0;
            // 
            // UIPicturePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FlowLayoutPanelMain);
            this.Name = "UIPicturePanel";
            this.Size = new System.Drawing.Size(162, 176);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelMain;
    }
}
