using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImportDB;
using Variable;

namespace CreateClass
{
    public partial class MainMenu : Form
    {
        private List<string> _unknownTypes;
        string _className;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            List<Variables> vList = new List<Variables>();

            for (int i = 0; i < DGVProperties.Rows.Count - 1; i++)
            {
                Variables v = new Variables();
                v.Name = DGVProperties.Rows[i].Cells[0].Value.ToString();
                v.SQLType = DGVProperties.Rows[i].Cells[1].Value.ToString();

                if (v.SQLType != null && v.SQLType != "")
                    v.CSharpType = SelectCSharpType(v.SQLType.ToLower());

                if (DGVProperties.Rows[i].Cells[2].Value != null && DGVProperties.Rows[i].Cells[2].Value.ToString() != "")
                    v.VariableSize = Convert.ToInt32(DGVProperties.Rows[i].Cells[2].Value.ToString());
                else
                    v.VariableSize = 0;
                v.AllowNulls = Convert.ToBoolean(DGVProperties.Rows[i].Cells[3].Value);
                vList.Add(v);
            }

            if (textBoxPath.Text.Length != 0 && textBoxPath.Text[textBoxPath.Text.Length - 1] != '\\')
                textBoxPath.Text += "\\";

            CreateClass.WriteProperties(vList, _className, textBoxPath.Text);
            CreateClass.WriteData(vList, _className, textBoxPath.Text);
            CreateClass.WriteBusiness(vList, _className, textBoxPath.Text);
            CreateClass.WriteList(vList, _className, textBoxPath.Text);
        }

        private void TBoxClassName_Validating(object sender, CancelEventArgs e)
        {
            _className = TBoxClassName.Text;
        }

        private void fromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionDetails cd = new ConnectionDetails();
            if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Summary summary = new Summary(cd.Connect);
                cd.Close();
                summary.ShowDialog();
            }
            else
            {
                //Import aborted.
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGVProperties.Rows.Clear();
        }

        private void buttonOpenDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private string SelectCSharpType(string type)
        {
            if (_unknownTypes == null)
                _unknownTypes = new List<string>();

            //image

            if (type == "bit") type = "bool";
            else if (type == "datetime") type = "bool";
            else if (type == "varchar") type = "string";
            else if (type == "nvarchar") type = "string";
            else if (type == "varbinary") type = "string";
            else if (type == "int") { }

            else if (type == "xml") type = "string";
            else if (type == "money") type = "decimal";
            else if (type == "decimal") type = "decimal";
            else if (type == "timestamp") type = "DateTime";
            else if (type == "datetime") type = "DateTime";
            else if (type == "tinyint") type = "byte";
            else if (type == "nchar") type = "string";
            else if (type == "text") type = "string";
            else if (type == "smallint") type = "short";
            else if (type == "smalldatetime") type = "DateTime";
            else if (type == "float") { }
            else if (type == "char") type = "string";
            else if (type == "real") type = "float";
            else if (type == "bigint") type = "long";
            else if (type == "smallmoney") type = "decimal";

            else if (!_unknownTypes.Contains(type))
            {
                _unknownTypes.Add(type);
                MessageBox.Show("Unknown Type: " + type);
            }

            return type;
        }
    }
}
