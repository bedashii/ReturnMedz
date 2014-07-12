namespace PlusPlay.UIControls
{
    partial class UIListBoxDouble
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
            this.SplitContainerMain = new System.Windows.Forms.SplitContainer();
            this.ListBoxMain = new System.Windows.Forms.ListBox();
            this.ListBoxSub = new System.Windows.Forms.ListBox();
            this.modelListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.galleryListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).BeginInit();
            this.SplitContainerMain.Panel1.SuspendLayout();
            this.SplitContainerMain.Panel2.SuspendLayout();
            this.SplitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SplitContainerMain
            // 
            this.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerMain.Margin = new System.Windows.Forms.Padding(0);
            this.SplitContainerMain.Name = "SplitContainerMain";
            // 
            // SplitContainerMain.Panel1
            // 
            this.SplitContainerMain.Panel1.Controls.Add(this.ListBoxMain);
            // 
            // SplitContainerMain.Panel2
            // 
            this.SplitContainerMain.Panel2.Controls.Add(this.ListBoxSub);
            this.SplitContainerMain.Size = new System.Drawing.Size(252, 353);
            this.SplitContainerMain.SplitterDistance = 125;
            this.SplitContainerMain.SplitterWidth = 2;
            this.SplitContainerMain.TabIndex = 0;
            // 
            // ListBoxMain
            // 
            this.ListBoxMain.DataSource = this.modelListBindingSource;
            this.ListBoxMain.DisplayMember = "ModelName";
            this.ListBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxMain.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxMain.FormattingEnabled = true;
            this.ListBoxMain.ItemHeight = 23;
            this.ListBoxMain.Location = new System.Drawing.Point(0, 0);
            this.ListBoxMain.Name = "ListBoxMain";
            this.ListBoxMain.Size = new System.Drawing.Size(125, 353);
            this.ListBoxMain.TabIndex = 0;
            this.ListBoxMain.ValueMember = "ModelName";
            this.ListBoxMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxMain_KeyDown);
            this.ListBoxMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxMain_MouseDoubleClick);
            // 
            // ListBoxSub
            // 
            this.ListBoxSub.DataSource = this.galleryListBindingSource;
            this.ListBoxSub.DisplayMember = "GalleryName";
            this.ListBoxSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxSub.Font = new System.Drawing.Font("Tahoma", 14F);
            this.ListBoxSub.FormattingEnabled = true;
            this.ListBoxSub.ItemHeight = 23;
            this.ListBoxSub.Location = new System.Drawing.Point(0, 0);
            this.ListBoxSub.Name = "ListBoxSub";
            this.ListBoxSub.Size = new System.Drawing.Size(125, 353);
            this.ListBoxSub.TabIndex = 0;
            this.ListBoxSub.ValueMember = "GalleryName";
            this.ListBoxSub.SelectedValueChanged += new System.EventHandler(this.ListBoxSub_SelectedValueChanged);
            this.ListBoxSub.Leave += new System.EventHandler(this.ListBoxSub_Leave);
            this.ListBoxSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBoxSub_MouseDown);
            this.ListBoxSub.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListBoxSub_MouseMove);
            this.ListBoxSub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListBoxSub_MouseUp);
            // 
            // modelListBindingSource
            // 
            this.modelListBindingSource.DataSource = typeof(PlusPlayLib.List.ModelList);
            // 
            // galleryListBindingSource
            // 
            this.galleryListBindingSource.DataSource = typeof(PlusPlayLib.List.GalleryList);
            // 
            // UIListBoxDouble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainerMain);
            this.Name = "UIListBoxDouble";
            this.Size = new System.Drawing.Size(252, 353);
            this.SplitContainerMain.Panel1.ResumeLayout(false);
            this.SplitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).EndInit();
            this.SplitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modelListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainerMain;
        private System.Windows.Forms.ListBox ListBoxMain;
        private System.Windows.Forms.ListBox ListBoxSub;
        private System.Windows.Forms.BindingSource modelListBindingSource;
        private System.Windows.Forms.BindingSource galleryListBindingSource;
    }
}
