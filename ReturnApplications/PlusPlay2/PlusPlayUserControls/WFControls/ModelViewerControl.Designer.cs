namespace PlusPlayUserControls.WFControls
{
    partial class ModelViewerControl
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
            this.ListBoxGalleries = new System.Windows.Forms.ListBox();
            this.BindingSourceModelGalleriesList = new System.Windows.Forms.BindingSource(this.components);
            this.ButtonAddGallery = new System.Windows.Forms.Button();
            this.ButtonRemoveGallery = new System.Windows.Forms.Button();
            this.PanelFlowGalleryPhotos = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.LabelGalleries = new System.Windows.Forms.Label();
            this.TextBoxModelName = new System.Windows.Forms.TextBox();
            this.BindingSourceModel = new System.Windows.Forms.BindingSource(this.components);
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.PictureBoxModelCoverPhoto = new PlusPlayUserControls.ucControls.ucPictureBox();
            this.LinkLabelChangeModelCoverPhoto = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceModelGalleriesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceModel)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBoxGalleries
            // 
            this.ListBoxGalleries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBoxGalleries.DataSource = this.BindingSourceModelGalleriesList;
            this.ListBoxGalleries.DisplayMember = "GalleryName";
            this.ListBoxGalleries.FormattingEnabled = true;
            this.ListBoxGalleries.Location = new System.Drawing.Point(3, 200);
            this.ListBoxGalleries.Name = "ListBoxGalleries";
            this.ListBoxGalleries.Size = new System.Drawing.Size(196, 212);
            this.ListBoxGalleries.TabIndex = 1;
            this.ListBoxGalleries.ValueMember = "ID";
            // 
            // BindingSourceModelGalleriesList
            // 
            this.BindingSourceModelGalleriesList.DataSource = typeof(PlusPlayDBGenLib.Lists.GalleriesList);
            // 
            // ButtonAddGallery
            // 
            this.ButtonAddGallery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAddGallery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAddGallery.Location = new System.Drawing.Point(3, 415);
            this.ButtonAddGallery.Name = "ButtonAddGallery";
            this.ButtonAddGallery.Size = new System.Drawing.Size(25, 28);
            this.ButtonAddGallery.TabIndex = 2;
            this.ButtonAddGallery.Text = "+";
            this.ButtonAddGallery.UseVisualStyleBackColor = true;
            // 
            // ButtonRemoveGallery
            // 
            this.ButtonRemoveGallery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonRemoveGallery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonRemoveGallery.Location = new System.Drawing.Point(174, 415);
            this.ButtonRemoveGallery.Name = "ButtonRemoveGallery";
            this.ButtonRemoveGallery.Size = new System.Drawing.Size(25, 28);
            this.ButtonRemoveGallery.TabIndex = 3;
            this.ButtonRemoveGallery.Text = "-";
            this.ButtonRemoveGallery.UseVisualStyleBackColor = true;
            // 
            // PanelFlowGalleryPhotos
            // 
            this.PanelFlowGalleryPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelFlowGalleryPhotos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelFlowGalleryPhotos.Location = new System.Drawing.Point(205, 46);
            this.PanelFlowGalleryPhotos.Name = "PanelFlowGalleryPhotos";
            this.PanelFlowGalleryPhotos.Size = new System.Drawing.Size(466, 366);
            this.PanelFlowGalleryPhotos.TabIndex = 4;
            // 
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.Location = new System.Drawing.Point(596, 418);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 3;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.UseVisualStyleBackColor = true;
            // 
            // LabelGalleries
            // 
            this.LabelGalleries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelGalleries.AutoSize = true;
            this.LabelGalleries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGalleries.Location = new System.Drawing.Point(62, 419);
            this.LabelGalleries.Name = "LabelGalleries";
            this.LabelGalleries.Size = new System.Drawing.Size(71, 20);
            this.LabelGalleries.TabIndex = 5;
            this.LabelGalleries.Text = "Galleries";
            // 
            // TextBoxModelName
            // 
            this.TextBoxModelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxModelName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BindingSourceModel, "ModelName", true));
            this.TextBoxModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TextBoxModelName.Location = new System.Drawing.Point(205, 14);
            this.TextBoxModelName.Name = "TextBoxModelName";
            this.TextBoxModelName.Size = new System.Drawing.Size(466, 26);
            this.TextBoxModelName.TabIndex = 6;
            this.TextBoxModelName.Text = "Model Name";
            // 
            // BindingSourceModel
            // 
            this.BindingSourceModel.DataSource = typeof(PlusPlayDBGenLib.Business.Models);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(3, 14);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(196, 167);
            this.elementHost1.TabIndex = 7;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.PictureBoxModelCoverPhoto;
            // 
            // LinkLabelChangeModelCoverPhoto
            // 
            this.LinkLabelChangeModelCoverPhoto.AutoSize = true;
            this.LinkLabelChangeModelCoverPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LinkLabelChangeModelCoverPhoto.Location = new System.Drawing.Point(61, 184);
            this.LinkLabelChangeModelCoverPhoto.Name = "LinkLabelChangeModelCoverPhoto";
            this.LinkLabelChangeModelCoverPhoto.Size = new System.Drawing.Size(138, 13);
            this.LinkLabelChangeModelCoverPhoto.TabIndex = 8;
            this.LinkLabelChangeModelCoverPhoto.TabStop = true;
            this.LinkLabelChangeModelCoverPhoto.Text = "Change Model Cover Photo";
            this.LinkLabelChangeModelCoverPhoto.Click += new System.EventHandler(this.LinkLabelChangeModelCoverPhoto_Click);
            // 
            // ModelViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LinkLabelChangeModelCoverPhoto);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.TextBoxModelName);
            this.Controls.Add(this.LabelGalleries);
            this.Controls.Add(this.PanelFlowGalleryPhotos);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonRemoveGallery);
            this.Controls.Add(this.ButtonAddGallery);
            this.Controls.Add(this.ListBoxGalleries);
            this.Name = "ModelViewerControl";
            this.Size = new System.Drawing.Size(674, 446);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceModelGalleriesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceModel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxGalleries;
        private System.Windows.Forms.Button ButtonAddGallery;
        private System.Windows.Forms.Button ButtonRemoveGallery;
        private System.Windows.Forms.FlowLayoutPanel PanelFlowGalleryPhotos;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Label LabelGalleries;
        private System.Windows.Forms.TextBox TextBoxModelName;
        private System.Windows.Forms.BindingSource BindingSourceModelGalleriesList;
        private System.Windows.Forms.BindingSource BindingSourceModel;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private ucControls.ucPictureBox PictureBoxModelCoverPhoto;
        private System.Windows.Forms.LinkLabel LinkLabelChangeModelCoverPhoto;
    }
}
