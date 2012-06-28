// Author: Rian Mostert
// Date: 28 May 2012

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PropertiesGenerator;

namespace ImportDB
{
    public partial class Summary : Form
    {
        private DataHelper.DataHelper _connect;

        private CustomClassesList _customClassesList;

        public Summary(DataHelper.DataHelper connect)
        {
            InitializeComponent();
            _connect = connect;

            LoadClasses();

            _customClassesList.ForEach(x =>
                {
                    listBoxClasses.Items.Add(x.Name);
                });

            if (listBoxClasses.Items.Count > 0)
                listBoxClasses.SelectedIndex = 0;
        }

        public void LoadClasses()
        {
            _customClassesList = new CustomClassesList();

            string q = "SELECT TABLE_NAME ,\n";
            q += "COLUMN_NAME ,\n";
            q += "IS_NULLABLE ,\n";
            q += "DATA_TYPE ,\n";
            q += "CASE WHEN CHARACTER_MAXIMUM_LENGTH is NULL or CHARACTER_MAXIMUM_LENGTH = -1 THEN 0 ELSE CHARACTER_MAXIMUM_LENGTH END CHARACTER_MAXIMUM_LENGTH\n";
            q += "FROM INFORMATION_SCHEMA.COLUMNS isc\n";
            q += "JOIN sys.objects so ON OBJECT_ID('' + isc.TABLE_NAME + '') = so.object_id\n";
            q += "WHERE type = 'U'\n";
            q += "ORDER BY TABLE_NAME,ORDINAL_POSITION";

            SqlCommand cmd = _connect.CreateCommand(q);

            DataTable dt = _connect.ExecuteQuery(cmd);

            string tableName;
            string columnName;
            string type;
            int length;
            bool allowNulls;
            CustomClasses cc;

            foreach (DataRow dr in dt.Rows)
            {
                tableName = dr["TABLE_NAME"].ToString();
                columnName = dr["COLUMN_NAME"].ToString();
                type = dr["DATA_TYPE"].ToString();
                SelectCSharpType(ref type);
                length = Convert.ToInt32(dr["CHARACTER_MAXIMUM_LENGTH"]);
                allowNulls = dr["IS_NULLABLE"].ToString() == "NO" ? false : true;

                cc = _customClassesList.Find(x => x.Name == tableName);

                if (cc == null)
                {
                    _customClassesList.Add(new CustomClasses(tableName, columnName, type, length, allowNulls));
                }
                else
                {
                    cc.Variables.Add(new Variable.Variables(columnName, type, length, allowNulls));
                }

                tableName = "";
                columnName = "";
                type = "";
                length = 0;
                allowNulls = true;
                cc = null;
            }
        }

        private List<string> _unknownTypes;

        private void SelectCSharpType(ref string type)
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
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (textBoxPath.Text.Length != 0 && textBoxPath.Text[textBoxPath.Text.Length - 1] != '\\')
                textBoxPath.Text += "\\";

            _customClassesList.ForEach(x =>
                {
                    CreateClass.WriteProperties(x.Variables, x.Name, textBoxPath.Text);
                    CreateClass.WriteData(x.Variables, x.Name, textBoxPath.Text);
                });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindingSourceVariables.DataSource = _customClassesList.Find(x => x.Name == listBoxClasses.SelectedItem).Variables;
        }

        private void buttonOpenDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxPath.Text = folderBrowserDialog1.SelectedPath;
        }
    }

    public class CustomClassesList : List<CustomClasses>
    {

    }

    public class CustomClasses
    {
        public CustomClasses()
        {

        }

        public CustomClasses(string tableName, string columnName, string type, int length, bool allowNulls)
        {
            Name = tableName;
            Variables.Add(new Variable.Variables(columnName, type, length, allowNulls));
        }

        public string Name { get; set; }
        private Variable.VariablesList _variables { get; set; }
        public Variable.VariablesList Variables
        {
            get
            {
                if (_variables == null)
                    _variables = new Variable.VariablesList();
                return _variables;
            }
            set
            {
                _variables = value;
            }
        }
    }
}
