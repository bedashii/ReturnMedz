namespace HolisticsCommander
{
    partial class ServerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.TextBoxRServerForm = new System.Windows.Forms.RichTextBox();
            this.NotifyIconServer = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // TextBoxRServerForm
            // 
            this.TextBoxRServerForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxRServerForm.Location = new System.Drawing.Point(0, 0);
            this.TextBoxRServerForm.Name = "TextBoxRServerForm";
            this.TextBoxRServerForm.ReadOnly = true;
            this.TextBoxRServerForm.Size = new System.Drawing.Size(418, 435);
            this.TextBoxRServerForm.TabIndex = 0;
            this.TextBoxRServerForm.Text = "";
            // 
            // NotifyIconServer
            // 
            this.NotifyIconServer.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIconServer.Icon")));
            this.NotifyIconServer.Text = "notifyIcon1";
            this.NotifyIconServer.Visible = true;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 435);
            this.Controls.Add(this.TextBoxRServerForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServerForm";
            this.Text = "Holistics Commander Server";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.Resize += new System.EventHandler(this.ServerForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextBoxRServerForm;
        private System.Windows.Forms.NotifyIcon NotifyIconServer;
    }
}