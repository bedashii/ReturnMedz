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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabMovieAddControl = new System.Windows.Forms.TabPage();
            this.TabPreferencesControl = new System.Windows.Forms.TabPage();
            this.preferencesControl1 = new ReturnMovieManagerWF.Controls.PreferencesControl();
            this.TabControl.SuspendLayout();
            this.TabPreferencesControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabMovieAddControl);
            this.TabControl.Controls.Add(this.TabPreferencesControl);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(822, 651);
            this.TabControl.TabIndex = 0;
            // 
            // TabMovieAddControl
            // 
            this.TabMovieAddControl.Location = new System.Drawing.Point(4, 22);
            this.TabMovieAddControl.Name = "TabMovieAddControl";
            this.TabMovieAddControl.Padding = new System.Windows.Forms.Padding(3);
            this.TabMovieAddControl.Size = new System.Drawing.Size(646, 364);
            this.TabMovieAddControl.TabIndex = 0;
            this.TabMovieAddControl.Text = "Movie Add";
            this.TabMovieAddControl.UseVisualStyleBackColor = true;
            // 
            // TabPreferencesControl
            // 
            this.TabPreferencesControl.Controls.Add(this.preferencesControl1);
            this.TabPreferencesControl.Location = new System.Drawing.Point(4, 22);
            this.TabPreferencesControl.Name = "TabPreferencesControl";
            this.TabPreferencesControl.Padding = new System.Windows.Forms.Padding(3);
            this.TabPreferencesControl.Size = new System.Drawing.Size(814, 625);
            this.TabPreferencesControl.TabIndex = 1;
            this.TabPreferencesControl.Text = "Preferences";
            this.TabPreferencesControl.UseVisualStyleBackColor = true;
            // 
            // preferencesControl1
            // 
            this.preferencesControl1.Location = new System.Drawing.Point(0, 0);
            this.preferencesControl1.Name = "preferencesControl1";
            this.preferencesControl1.Size = new System.Drawing.Size(811, 625);
            this.preferencesControl1.TabIndex = 0;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 651);
            this.Controls.Add(this.TabControl);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.TabControl.ResumeLayout(false);
            this.TabPreferencesControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabMovieAddControl;
        private System.Windows.Forms.TabPage TabPreferencesControl;
        private Controls.PreferencesControl preferencesControl1;

    }
}

