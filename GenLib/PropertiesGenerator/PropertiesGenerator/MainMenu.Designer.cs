namespace PropertiesGenerator
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
            this.DGVProperties = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.TBoxClassName = new System.Windows.Forms.TextBox();
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VariableSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVProperties
            // 
            this.DGVProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyName,
            this.DataType,
            this.VariableSize,
            this.Nullable});
            this.DGVProperties.Location = new System.Drawing.Point(0, 82);
            this.DGVProperties.Name = "DGVProperties";
            this.DGVProperties.Size = new System.Drawing.Size(410, 369);
            this.DGVProperties.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Class Name";
            // 
            // TBoxClassName
            // 
            this.TBoxClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TBoxClassName.Location = new System.Drawing.Point(81, 42);
            this.TBoxClassName.Name = "TBoxClassName";
            this.TBoxClassName.Size = new System.Drawing.Size(317, 20);
            this.TBoxClassName.TabIndex = 2;
            this.TBoxClassName.Validating += new System.ComponentModel.CancelEventHandler(this.TBoxClassName_Validating);
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGenerate.Location = new System.Drawing.Point(323, 12);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(75, 23);
            this.ButtonGenerate.TabIndex = 3;
            this.ButtonGenerate.Text = "Generate";
            this.ButtonGenerate.UseVisualStyleBackColor = true;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(12, 12);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 3;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // PropertyName
            // 
            this.PropertyName.HeaderText = "Property Name";
            this.PropertyName.Name = "PropertyName";
            // 
            // DataType
            // 
            this.DataType.HeaderText = "Data Type";
            this.DataType.Name = "DataType";
            // 
            // VariableSize
            // 
            this.VariableSize.HeaderText = "Variable Size";
            this.VariableSize.Name = "VariableSize";
            // 
            // Nullable
            // 
            this.Nullable.HeaderText = "Nullable";
            this.Nullable.Name = "Nullable";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 451);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonGenerate);
            this.Controls.Add(this.TBoxClassName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVProperties);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            ((System.ComponentModel.ISupportInitialize)(this.DGVProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVProperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBoxClassName;
        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn VariableSize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Nullable;
    }
}