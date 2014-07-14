
namespace PlusPlayWF
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
            this.components = new System.ComponentModel.Container();
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.TSMI_File = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_AddModel = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_Separator = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ListBoxModels = new System.Windows.Forms.ListBox();
            this.BindingSourceModelsList = new System.Windows.Forms.BindingSource(this.components);
            this.PanelSplit = new System.Windows.Forms.SplitContainer();
            this.PanelControls = new System.Windows.Forms.Panel();
            this.MenuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceModelsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelSplit)).BeginInit();
            this.PanelSplit.Panel1.SuspendLayout();
            this.PanelSplit.Panel2.SuspendLayout();
            this.PanelSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStripMain
            // 
            this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_File});
            this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Size = new System.Drawing.Size(954, 24);
            this.MenuStripMain.TabIndex = 0;
            this.MenuStripMain.Text = "menuStrip1";
            // 
            // TSMI_File
            // 
            this.TSMI_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_AddModel,
            this.TSM_Separator,
            this.TSMI_Exit});
            this.TSMI_File.Name = "TSMI_File";
            this.TSMI_File.Size = new System.Drawing.Size(37, 20);
            this.TSMI_File.Text = "&File";
            // 
            // TSMI_AddModel
            // 
            this.TSMI_AddModel.Name = "TSMI_AddModel";
            this.TSMI_AddModel.Size = new System.Drawing.Size(133, 22);
            this.TSMI_AddModel.Text = "Add &Model";
            this.TSMI_AddModel.Click += new System.EventHandler(this.TSMI_AddModel_Click);
            // 
            // TSM_Separator
            // 
            this.TSM_Separator.Name = "TSM_Separator";
            this.TSM_Separator.Size = new System.Drawing.Size(130, 6);
            // 
            // TSMI_Exit
            // 
            this.TSMI_Exit.Name = "TSMI_Exit";
            this.TSMI_Exit.Size = new System.Drawing.Size(133, 22);
            this.TSMI_Exit.Text = "E&xit";
            // 
            // ListBoxModels
            // 
            this.ListBoxModels.DataSource = this.BindingSourceModelsList;
            this.ListBoxModels.DisplayMember = "ModelName";
            this.ListBoxModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxModels.FormattingEnabled = true;
            this.ListBoxModels.ItemHeight = 16;
            this.ListBoxModels.Location = new System.Drawing.Point(0, 0);
            this.ListBoxModels.Name = "ListBoxModels";
            this.ListBoxModels.Size = new System.Drawing.Size(225, 535);
            this.ListBoxModels.TabIndex = 0;
            this.ListBoxModels.ValueMember = "ID";
            this.ListBoxModels.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxModels_MouseDoubleClick);
            // 
            // BindingSourceModelsList
            // 
            this.BindingSourceModelsList.DataSource = typeof(PlusPlayDBGenLib.Lists.ModelsList);
            // 
            // PanelSplit
            // 
            this.PanelSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSplit.Location = new System.Drawing.Point(0, 24);
            this.PanelSplit.Name = "PanelSplit";
            // 
            // PanelSplit.Panel1
            // 
            this.PanelSplit.Panel1.Controls.Add(this.ListBoxModels);
            // 
            // PanelSplit.Panel2
            // 
            this.PanelSplit.Panel2.Controls.Add(this.PanelControls);
            this.PanelSplit.Size = new System.Drawing.Size(954, 535);
            this.PanelSplit.SplitterDistance = 225;
            this.PanelSplit.TabIndex = 1;
            // 
            // PanelControls
            // 
            this.PanelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelControls.Location = new System.Drawing.Point(0, 0);
            this.PanelControls.Name = "PanelControls";
            this.PanelControls.Padding = new System.Windows.Forms.Padding(15);
            this.PanelControls.Size = new System.Drawing.Size(725, 535);
            this.PanelControls.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 559);
            this.Controls.Add(this.PanelSplit);
            this.Controls.Add(this.MenuStripMain);
            this.MainMenuStrip = this.MenuStripMain;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuStripMain.ResumeLayout(false);
            this.MenuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceModelsList)).EndInit();
            this.PanelSplit.Panel1.ResumeLayout(false);
            this.PanelSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelSplit)).EndInit();
            this.PanelSplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem TSMI_File;
        private System.Windows.Forms.ToolStripMenuItem TSMI_AddModel;
        private System.Windows.Forms.ToolStripSeparator TSM_Separator;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Exit;
        private System.Windows.Forms.ListBox ListBoxModels;
        private System.Windows.Forms.BindingSource BindingSourceModelsList;
        private System.Windows.Forms.SplitContainer PanelSplit;
        private System.Windows.Forms.Panel PanelControls;
    }
}
