namespace PlusPlayUserControls.WFControls
{
    partial class GallleryEditorControl
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
            this.PanelFlowMain = new System.Windows.Forms.FlowLayoutPanel();
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.TSMI_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Cancel = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBoxGalleryName = new System.Windows.Forms.TextBox();
            this.LabelGalleryName = new System.Windows.Forms.Label();
            this.BindingSourceGalleries = new System.Windows.Forms.BindingSource(this.components);
            this.TSMI_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceGalleries)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelFlowMain
            // 
            this.PanelFlowMain.Location = new System.Drawing.Point(3, 47);
            this.PanelFlowMain.Name = "PanelFlowMain";
            this.PanelFlowMain.Size = new System.Drawing.Size(630, 285);
            this.PanelFlowMain.TabIndex = 0;
            // 
            // MenuStripMain
            // 
            this.MenuStripMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Save,
            this.TSMI_Cancel,
            this.TSMI_Delete});
            this.MenuStripMain.Location = new System.Drawing.Point(0, 338);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Size = new System.Drawing.Size(636, 24);
            this.MenuStripMain.TabIndex = 1;
            this.MenuStripMain.Text = "menuStrip1";
            // 
            // TSMI_Save
            // 
            this.TSMI_Save.Name = "TSMI_Save";
            this.TSMI_Save.Size = new System.Drawing.Size(43, 20);
            this.TSMI_Save.Text = "&Save";
            // 
            // TSMI_Cancel
            // 
            this.TSMI_Cancel.Name = "TSMI_Cancel";
            this.TSMI_Cancel.Size = new System.Drawing.Size(55, 20);
            this.TSMI_Cancel.Text = "&Cancel";
            // 
            // TextBoxGalleryName
            // 
            this.TextBoxGalleryName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSourceGalleries, "GalleryName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBoxGalleryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.TextBoxGalleryName.Location = new System.Drawing.Point(115, 18);
            this.TextBoxGalleryName.Name = "TextBoxGalleryName";
            this.TextBoxGalleryName.Size = new System.Drawing.Size(518, 23);
            this.TextBoxGalleryName.TabIndex = 2;
            // 
            // LabelGalleryName
            // 
            this.LabelGalleryName.AutoSize = true;
            this.LabelGalleryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGalleryName.Location = new System.Drawing.Point(3, 21);
            this.LabelGalleryName.Name = "LabelGalleryName";
            this.LabelGalleryName.Size = new System.Drawing.Size(106, 17);
            this.LabelGalleryName.TabIndex = 3;
            this.LabelGalleryName.Text = "Gallery Name";
            // 
            // BindingSourceGalleries
            // 
            this.BindingSourceGalleries.DataSource = typeof(PlusPlayDBGenLib.Business.Galleries);
            // 
            // TSMI_Delete
            // 
            this.TSMI_Delete.Enabled = false;
            this.TSMI_Delete.Name = "TSMI_Delete";
            this.TSMI_Delete.Size = new System.Drawing.Size(52, 20);
            this.TSMI_Delete.Text = "Delete";
            // 
            // GallleryEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabelGalleryName);
            this.Controls.Add(this.TextBoxGalleryName);
            this.Controls.Add(this.PanelFlowMain);
            this.Controls.Add(this.MenuStripMain);
            this.Name = "GallleryEditorControl";
            this.Size = new System.Drawing.Size(636, 362);
            this.MenuStripMain.ResumeLayout(false);
            this.MenuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceGalleries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PanelFlowMain;
        private System.Windows.Forms.MenuStrip MenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Save;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Cancel;
        private System.Windows.Forms.TextBox TextBoxGalleryName;
        private System.Windows.Forms.Label LabelGalleryName;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Delete;
        private System.Windows.Forms.BindingSource BindingSourceGalleries;
    }
}
