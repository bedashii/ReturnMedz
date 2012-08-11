namespace ReturnMovieManagerWF
{
    partial class MainMenu
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
            this.TabPreferences = new System.Windows.Forms.TabControl();
            this.TabMovieAddControl = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TabPreferences.SuspendLayout();
            this.TabMovieAddControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPreferences
            // 
            this.TabPreferences.Controls.Add(this.TabMovieAddControl);
            this.TabPreferences.Controls.Add(this.tabPage2);
            this.TabPreferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPreferences.Location = new System.Drawing.Point(0, 0);
            this.TabPreferences.Name = "TabPreferences";
            this.TabPreferences.SelectedIndex = 0;
            this.TabPreferences.Size = new System.Drawing.Size(822, 651);
            this.TabPreferences.TabIndex = 0;
            // 
            // TabMovieAddControl
            // 
            this.TabMovieAddControl.Location = new System.Drawing.Point(4, 22);
            this.TabMovieAddControl.Name = "TabMovieAddControl";
            this.TabMovieAddControl.Padding = new System.Windows.Forms.Padding(3);
            this.TabMovieAddControl.Size = new System.Drawing.Size(814, 625);
            this.TabMovieAddControl.TabIndex = 0;
            this.TabMovieAddControl.Text = "Add Movie";
            this.TabMovieAddControl.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(814, 625);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Preferences";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 651);
            this.Controls.Add(this.TabPreferences);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.TabPreferences.ResumeLayout(false);
            this.TabMovieAddControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabPreferences;
        private System.Windows.Forms.TabPage TabMovieAddControl;
        private System.Windows.Forms.TabPage tabPage2;


    }
}

