﻿namespace ChattersApp
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.buttonMenuItems = new System.Windows.Forms.Button();
            this.buttonSystemInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonSystemInfo);
            this.splitContainer1.Panel1.Controls.Add(this.buttonMenu);
            this.splitContainer1.Panel1.Controls.Add(this.buttonMenuItems);
            this.splitContainer1.Size = new System.Drawing.Size(622, 360);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonMenu
            // 
            this.buttonMenu.Location = new System.Drawing.Point(3, 3);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(131, 38);
            this.buttonMenu.TabIndex = 1;
            this.buttonMenu.Text = "Menus";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // buttonMenuItems
            // 
            this.buttonMenuItems.Location = new System.Drawing.Point(3, 47);
            this.buttonMenuItems.Name = "buttonMenuItems";
            this.buttonMenuItems.Size = new System.Drawing.Size(131, 38);
            this.buttonMenuItems.TabIndex = 0;
            this.buttonMenuItems.Text = "Menu Items";
            this.buttonMenuItems.UseVisualStyleBackColor = true;
            this.buttonMenuItems.Click += new System.EventHandler(this.buttonMenuItems_Click);
            // 
            // buttonSystemInfo
            // 
            this.buttonSystemInfo.Location = new System.Drawing.Point(3, 91);
            this.buttonSystemInfo.Name = "buttonSystemInfo";
            this.buttonSystemInfo.Size = new System.Drawing.Size(131, 38);
            this.buttonSystemInfo.TabIndex = 2;
            this.buttonSystemInfo.Text = "System Info";
            this.buttonSystemInfo.UseVisualStyleBackColor = true;
            this.buttonSystemInfo.Click += new System.EventHandler(this.buttonSystemInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 360);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Chatters - Admin App";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonMenuItems;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Button buttonSystemInfo;
    }
}

