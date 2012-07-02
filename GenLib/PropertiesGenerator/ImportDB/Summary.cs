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
using CreateClass;
using CreateClass.PropertiesGenerator;

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
            string sqlType;
            string cSharpType;
            int length;
            bool allowNulls;
            CustomClasses cc;

            foreach (DataRow dr in dt.Rows)
            {
                tableName = dr["TABLE_NAME"].ToString();
                columnName = dr["COLUMN_NAME"].ToString();
                sqlType = dr["DATA_TYPE"].ToString();
                cSharpType = SelectCSharpType(sqlType);
                length = Convert.ToInt32(dr["CHARACTER_MAXIMUM_LENGTH"]);
                allowNulls = dr["IS_NULLABLE"].ToString() == "NO" ? false : true;

                cc = _customClassesList.Find(x => x.Name == tableName);

                if (cc == null)
                {
                    _customClassesList.Add(new CustomClasses(tableName, columnName, sqlType, cSharpType , length, allowNulls));
                }
                else
                {
                    cc.Variables.Add(new Variable.Variables(columnName, sqlType, cSharpType, length, allowNulls));
                }

                tableName = "";
                columnName = "";
                sqlType = "";
                cSharpType = "";
                length = 0;
                allowNulls = true;
                cc = null;
            }
        }

        private List<string> _unknownTypes;

        private string SelectSQLType(string type)
        {
            if (_unknownTypes == null)
                _unknownTypes = new List<string>();

            if (type == "BigInt") type = "in";
            else if (type == "Binary") type = "string[]";
            else if (type == "Bit") type = "bool";
            else if (type == "Char") type = "string";
            else if (type == "DateTime") type = "DateTime";
            else if (type == "Decimal") type = "decimal";
            else if (type == "Float") type = "float";
            //else if (type == "Image") type = "?";
            else if (type == "Int") type = "int";
            else if (type == "Money") type = "decimal";
            else if (type == "NChar") type = "string";
            else if (type == "NText") type = "string";
            else if (type == "NVarChar") type = "string";
            else if (type == "Real") type = "float";
            else if (type == "UniqueIdentifier") type = "Guid";
            else if (type == "SmallDateTime") type = "DateTime";
            else if (type == "SmallInt") type = "short";
            else if (type == "SmallMoney") type = "decimal";
            else if (type == "Text") type = "string";
            else if (type == "Timestamp") type = "DateTime";
            else if (type == "TinyInt") type = "byte";
            else if (type == "VarBinary") type = "string";
            else if (type == "VarChar") type = "string";
            else if (type == "Variant") type = "object";
            else if (type == "Xml") type = "string";
            else if (type == "Date") type = "DateTime";
            else if (type == "Time") type = "DateTime";
            else if (type == "DateTime2") type = "DateTime";
            else if (type == "DateTimeOffset") type = "DateTime";

            else if (!_unknownTypes.Contains(type))
            {
                _unknownTypes.Add(type);
                MessageBox.Show("Unknown Type: " + type);
            }

            return type;
        }

        private string SelectCSharpType(string type)
        {
            if (_unknownTypes == null)
                _unknownTypes = new List<string>();

            if (type == "BitInt") type = "int";
            else if (type == "Binary") type = "string[]";
            else if (type == "Bit") type = "bool";
            else if (type == "Char") type = "string";
            else if (type == "DateTime") type = "DateTime";
            else if (type == "Decimal") type = "decimal";
            else if (type == "Float") type = "float";
            //else if (type == "Image") type = "?";
            else if (type == "Int") type = "int";
            else if (type == "Money") type = "decimal";
            else if (type == "NChar") type = "string";
            else if (type == "NText") type = "string";
            else if (type == "NVarChar") type = "string";
            else if (type == "Real") type = "float";
            else if (type == "UniqueIdentifier") type = "Guid";
            else if (type == "SmallDateTime") type = "DateTime";
            else if (type == "SmallInt") type = "short";
            else if (type == "SmallMoney") type = "decimal";
            else if (type == "Text") type = "string";
            else if (type == "Timestamp") type = "DateTime";
            else if (type == "TinyInt") type = "byte";
            else if (type == "VarBinary") type = "string";
            else if (type == "VarChar") type = "string";
            else if (type == "Variant") type = "object";
            else if (type == "Xml") type = "string";
            else if (type == "Date") type = "DateTime";
            else if (type == "Time") type = "DateTime";
            else if (type == "DateTime2") type = "DateTime";
            else if (type == "DateTimeOffset") type = "DateTime";

            else if (!_unknownTypes.Contains(type))
            {
                _unknownTypes.Add(type);
                MessageBox.Show("Unknown Type: " + type);
            }

            return type;
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            if (textBoxPath.Text.Length != 0 && textBoxPath.Text[textBoxPath.Text.Length - 1] != '\\')
                textBoxPath.Text += "\\";

            _customClassesList.ForEach(x =>
                {
                    CreateClass.CreateClass.WriteProperties(x.Variables, x.Name, textBoxPath.Text);
                    CreateClass.CreateClass.WriteData(x.Variables, x.Name, textBoxPath.Text);
                    CreateClass.CreateClass.WriteBusiness(x.Variables, x.Name, textBoxPath.Text);
                    CreateClass.CreateClass.WriteList(x.Variables, x.Name, textBoxPath.Text);
                });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindingSourceVariables.DataSource = _customClassesList.Find(x => x.Name == listBoxClasses.SelectedItem.ToString()).Variables;
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

        public CustomClasses(string tableName, string columnName, string sqlType, string cSharpType, int length, bool allowNulls)
        {
            Name = tableName;
            Variables.Add(new Variable.Variables(columnName, sqlType, cSharpType, length, allowNulls));
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
