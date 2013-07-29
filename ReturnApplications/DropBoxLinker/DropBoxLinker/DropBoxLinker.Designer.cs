namespace DropBoxLinker
{
    partial class DropBoxLinker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropBoxLinker));
            this.TextBoxFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonGO = new System.Windows.Forms.Button();
            this.ListBoxLinks = new System.Windows.Forms.ListBox();
            this.ComboBoxExtension = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckBoxImageTags = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TextBoxFilePath
            // 
            this.TextBoxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxFilePath.Location = new System.Drawing.Point(12, 25);
            this.TextBoxFilePath.Name = "TextBoxFilePath";
            this.TextBoxFilePath.Size = new System.Drawing.Size(311, 20);
            this.TextBoxFilePath.TabIndex = 0;
            this.TextBoxFilePath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxFilePath_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File/ Folder";
            // 
            // ButtonGO
            // 
            this.ButtonGO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGO.Location = new System.Drawing.Point(481, 22);
            this.ButtonGO.Name = "ButtonGO";
            this.ButtonGO.Size = new System.Drawing.Size(75, 23);
            this.ButtonGO.TabIndex = 3;
            this.ButtonGO.Text = "GO";
            this.ButtonGO.UseVisualStyleBackColor = true;
            this.ButtonGO.Click += new System.EventHandler(this.ButtonGO_Click);
            // 
            // ListBoxLinks
            // 
            this.ListBoxLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxLinks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBoxLinks.FormattingEnabled = true;
            this.ListBoxLinks.Location = new System.Drawing.Point(12, 51);
            this.ListBoxLinks.Name = "ListBoxLinks";
            this.ListBoxLinks.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListBoxLinks.Size = new System.Drawing.Size(544, 236);
            this.ListBoxLinks.TabIndex = 4;
            // 
            // ComboBoxExtension
            // 
            this.ComboBoxExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxExtension.FormattingEnabled = true;
            this.ComboBoxExtension.Location = new System.Drawing.Point(415, 25);
            this.ComboBoxExtension.Name = "ComboBoxExtension";
            this.ComboBoxExtension.Size = new System.Drawing.Size(60, 21);
            this.ComboBoxExtension.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Extension";
            // 
            // CheckBoxImageTags
            // 
            this.CheckBoxImageTags.AutoSize = true;
            this.CheckBoxImageTags.Location = new System.Drawing.Point(329, 27);
            this.CheckBoxImageTags.Name = "CheckBoxImageTags";
            this.CheckBoxImageTags.Size = new System.Drawing.Size(82, 17);
            this.CheckBoxImageTags.TabIndex = 7;
            this.CheckBoxImageTags.Text = "Image Tags";
            this.CheckBoxImageTags.UseVisualStyleBackColor = true;
            this.CheckBoxImageTags.CheckedChanged += new System.EventHandler(this.CheckBoxImageTags_CheckedChanged);
            // 
            // DropBoxLinker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 315);
            this.Controls.Add(this.CheckBoxImageTags);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComboBoxExtension);
            this.Controls.Add(this.ListBoxLinks);
            this.Controls.Add(this.ButtonGO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxFilePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DropBoxLinker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DropBox Linker";
            this.Load += new System.EventHandler(this.DropBoxLinker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonGO;
        private System.Windows.Forms.ListBox ListBoxLinks;
        private System.Windows.Forms.ComboBox ComboBoxExtension;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CheckBoxImageTags;
    }
}

