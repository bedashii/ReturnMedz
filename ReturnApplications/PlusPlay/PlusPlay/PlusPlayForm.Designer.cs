namespace PlusPlay
{
    partial class PlusPlayForm
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
            this.PanelMain = new System.Windows.Forms.Panel();
            this.elementHost9 = new System.Windows.Forms.Integration.ElementHost();
            this.WUIControlBoxPlusPlay = new PlusPlay.WUIControls.WUIControlBox();
            this.TextBoxGallery = new System.Windows.Forms.TextBox();
            this.TextBoxModel = new System.Windows.Forms.TextBox();
            this.PanelMainGalleryDisplay = new System.Windows.Forms.Panel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.PicturePanelMain = new PlusPlay.WUIControls.WUIPicturePanel();
            this.elementHost8 = new System.Windows.Forms.Integration.ElementHost();
            this.wuiPanel1 = new PlusPlay.WUIControls.WUIPanel();
            this.elementHost5 = new System.Windows.Forms.Integration.ElementHost();
            this.ButtonImport = new PlusPlay.WUIControls.WUIButton();
            this.elementHost6 = new System.Windows.Forms.Integration.ElementHost();
            this.ButtonSave = new PlusPlay.WUIControls.WUIButton();
            this.elementHost7 = new System.Windows.Forms.Integration.ElementHost();
            this.ButtonDiscard = new PlusPlay.WUIControls.WUIButton();
            this.PanelListViewModelGallerySelection = new System.Windows.Forms.Panel();
            this.ListBoxModelGallerySelection = new PlusPlay.UIControls.UIListBoxDouble();
            this.PanelMain.SuspendLayout();
            this.PanelMainGalleryDisplay.SuspendLayout();
            this.PanelListViewModelGallerySelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.PanelMain.Controls.Add(this.elementHost9);
            this.PanelMain.Controls.Add(this.TextBoxGallery);
            this.PanelMain.Controls.Add(this.TextBoxModel);
            this.PanelMain.Controls.Add(this.PanelMainGalleryDisplay);
            this.PanelMain.Controls.Add(this.elementHost8);
            this.PanelMain.Controls.Add(this.elementHost5);
            this.PanelMain.Controls.Add(this.elementHost6);
            this.PanelMain.Controls.Add(this.elementHost7);
            this.PanelMain.Controls.Add(this.PanelListViewModelGallerySelection);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(1018, 500);
            this.PanelMain.TabIndex = 1;
            // 
            // elementHost9
            // 
            this.elementHost9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost9.Location = new System.Drawing.Point(946, 0);
            this.elementHost9.Name = "elementHost9";
            this.elementHost9.Size = new System.Drawing.Size(72, 24);
            this.elementHost9.TabIndex = 7;
            this.elementHost9.Text = "elementHost9";
            this.elementHost9.Child = this.WUIControlBoxPlusPlay;
            // 
            // TextBoxGallery
            // 
            this.TextBoxGallery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxGallery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.TextBoxGallery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxGallery.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxGallery.Location = new System.Drawing.Point(791, 63);
            this.TextBoxGallery.Name = "TextBoxGallery";
            this.TextBoxGallery.Size = new System.Drawing.Size(215, 23);
            this.TextBoxGallery.TabIndex = 4;
            this.TextBoxGallery.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TextBoxModel
            // 
            this.TextBoxModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.TextBoxModel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxModel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxModel.Location = new System.Drawing.Point(862, 92);
            this.TextBoxModel.Name = "TextBoxModel";
            this.TextBoxModel.Size = new System.Drawing.Size(144, 20);
            this.TextBoxModel.TabIndex = 4;
            this.TextBoxModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PanelMainGalleryDisplay
            // 
            this.PanelMainGalleryDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMainGalleryDisplay.Controls.Add(this.elementHost1);
            this.PanelMainGalleryDisplay.Location = new System.Drawing.Point(247, 158);
            this.PanelMainGalleryDisplay.Name = "PanelMainGalleryDisplay";
            this.PanelMainGalleryDisplay.Size = new System.Drawing.Size(587, 313);
            this.PanelMainGalleryDisplay.TabIndex = 2;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(587, 313);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.PicturePanelMain;
            // 
            // elementHost8
            // 
            this.elementHost8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost8.Location = new System.Drawing.Point(224, 142);
            this.elementHost8.Name = "elementHost8";
            this.elementHost8.Size = new System.Drawing.Size(632, 346);
            this.elementHost8.TabIndex = 6;
            this.elementHost8.Text = "elementHost8";
            this.elementHost8.Child = this.wuiPanel1;
            // 
            // elementHost5
            // 
            this.elementHost5.Location = new System.Drawing.Point(364, 12);
            this.elementHost5.Name = "elementHost5";
            this.elementHost5.Size = new System.Drawing.Size(64, 100);
            this.elementHost5.TabIndex = 3;
            this.elementHost5.Text = "elementHost2";
            this.elementHost5.Child = this.ButtonImport;
            // 
            // elementHost6
            // 
            this.elementHost6.Location = new System.Drawing.Point(224, 12);
            this.elementHost6.Name = "elementHost6";
            this.elementHost6.Size = new System.Drawing.Size(64, 100);
            this.elementHost6.TabIndex = 4;
            this.elementHost6.Text = "elementHost2";
            this.elementHost6.Child = this.ButtonSave;
            // 
            // elementHost7
            // 
            this.elementHost7.Location = new System.Drawing.Point(294, 12);
            this.elementHost7.Name = "elementHost7";
            this.elementHost7.Size = new System.Drawing.Size(64, 100);
            this.elementHost7.TabIndex = 5;
            this.elementHost7.Text = "elementHost7";
            this.elementHost7.Child = this.ButtonDiscard;
            // 
            // PanelListViewModelGallerySelection
            // 
            this.PanelListViewModelGallerySelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PanelListViewModelGallerySelection.Controls.Add(this.ListBoxModelGallerySelection);
            this.PanelListViewModelGallerySelection.Location = new System.Drawing.Point(3, 6);
            this.PanelListViewModelGallerySelection.Name = "PanelListViewModelGallerySelection";
            this.PanelListViewModelGallerySelection.Size = new System.Drawing.Size(215, 491);
            this.PanelListViewModelGallerySelection.TabIndex = 1;
            // 
            // ListBoxModelGallerySelection
            // 
            this.ListBoxModelGallerySelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxModelGallerySelection.Location = new System.Drawing.Point(0, 0);
            this.ListBoxModelGallerySelection.Name = "ListBoxModelGallerySelection";
            this.ListBoxModelGallerySelection.Size = new System.Drawing.Size(215, 491);
            this.ListBoxModelGallerySelection.TabIndex = 2;
            this.ListBoxModelGallerySelection.ListBoxMain_Set += new PlusPlay.UIControls.UIListBoxDouble_SetListBoxMain(this.ListBoxModelGallerySelection_ListBoxMain_Set);
            this.ListBoxModelGallerySelection.ListBoxSub_Set += new PlusPlay.UIControls.UIListBoxDouble_SetListBoxSub(this.ListBoxModelGallerySelection_ListBoxSub_Set);
            this.ListBoxModelGallerySelection.SubListBox_SelectedValueChanged += new PlusPlay.UIControls.UIListBoxDouble_SubSelectedValueChanged(this.ListBoxModelGallerySelection_SubListBox_SelectedValueChanged);
            // 
            // PlusPlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1018, 500);
            this.ControlBox = false;
            this.Controls.Add(this.PanelMain);
            this.Name = "PlusPlayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.PanelMainGalleryDisplay.ResumeLayout(false);
            this.PanelListViewModelGallerySelection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Panel PanelListViewModelGallerySelection;
        private UIControls.UIListBoxDouble ListBoxModelGallerySelection;
        private System.Windows.Forms.Panel PanelMainGalleryDisplay;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.TextBox TextBoxGallery;
        private System.Windows.Forms.TextBox TextBoxModel;
        private System.Windows.Forms.Integration.ElementHost elementHost5;
        private WUIControls.WUIButton ButtonImport;
        private System.Windows.Forms.Integration.ElementHost elementHost6;
        private WUIControls.WUIButton ButtonSave;
        private System.Windows.Forms.Integration.ElementHost elementHost7;
        private WUIControls.WUIButton ButtonDiscard;
        private WUIControls.WUIPicturePanel PicturePanelMain;
        private System.Windows.Forms.Integration.ElementHost elementHost8;
        private WUIControls.WUIPanel wuiPanel1;
        private System.Windows.Forms.Integration.ElementHost elementHost9;
        private WUIControls.WUIControlBox WUIControlBoxPlusPlay;
    }
}

