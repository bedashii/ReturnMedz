namespace Crack
{
    partial class TexteBox
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
            this.TextBoxText = new System.Windows.Forms.TextBox();
            this.LabelPreText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBoxText
            // 
            this.TextBoxText.Location = new System.Drawing.Point(29, 13);
            this.TextBoxText.Name = "TextBoxText";
            this.TextBoxText.Size = new System.Drawing.Size(100, 20);
            this.TextBoxText.TabIndex = 0;
            this.TextBoxText.SizeChanged += new System.EventHandler(this.textBox1_SizeChanged);
            this.TextBoxText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LabelPreText
            // 
            this.LabelPreText.AutoSize = true;
            this.LabelPreText.BackColor = System.Drawing.Color.White;
            this.LabelPreText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LabelPreText.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPreText.ForeColor = System.Drawing.Color.DimGray;
            this.LabelPreText.Location = new System.Drawing.Point(113, 36);
            this.LabelPreText.Name = "LabelPreText";
            this.LabelPreText.Size = new System.Drawing.Size(40, 14);
            this.LabelPreText.TabIndex = 1;
            this.LabelPreText.Text = "label1";
            // 
            // TexteBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabelPreText);
            this.Controls.Add(this.TextBoxText);
            this.Name = "TexteBox";
            this.Size = new System.Drawing.Size(165, 55);
            this.Resize += new System.EventHandler(this.TexteBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxText;
        private System.Windows.Forms.Label LabelPreText;
    }
}
