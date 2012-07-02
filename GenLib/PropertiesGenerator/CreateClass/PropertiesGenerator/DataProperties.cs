using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateClass.PropertiesGenerator
{
    public class DataProperties : BaseProperties
    {
        public DataProperties(string ns, string className)
            : base(2)
        {
            this.NS = ns;
            Prop = new List<DataProps>();
            this.ClassName = className;
        }

        private string TH
        {
            get { return this.ClassName.Substring(0, 1).ToUpper(); }
        }

        private string ColumnNames
        {
            get
            {
                string s = @"        private string _selectColumnNames = """;
                Prop.ForEach(x =>
                    {
                        if (x.PName != this.Prop.Last().PName)
                            s += TH + ".[" + x.PName + "], ";
                        else
                            s += TH + ".[" + x.PName + "]";
                    });

                s += @""";" + NL;
                return s;
            }
        }

        private string DataHelper
        {
            get { return "        private DataHelper dataHelper;" + NL; }
        }

        private string Constructor
        {
            get
            {
                string s = NL + "        ";
                s += "public " + ClassNameFull + "()" + NL;
                s += "        {" + NL;
                s += "            dataHelper = new DataHelper();" + NL;
                s += "        }" + NL;
                return s;
            }
        }

        private string SetRowProperties
        {
            get
            {
                string s = NL + "        ";
                s += "internal void SetRowProperties(DataRow dr, Properties." + this.ClassName + "Properties row)" + NL;
                s += "        {";

                Prop.ForEach(x =>
                    {
                        if (x.CanBeNull)
                        {
                            s += NL;
                            s += "            if ((" + GetRow(x.PName) + ") == DBNull.Value)" + NL;
                            s += "                row." + x.PName + " = null;" + NL;
                            s += "            else" + NL;
                            s += "                row." + x.PName + GetConversion(x.PCSharpType) + "(" + GetRow(x.PName) + ");" + NL;
                        }
                        else
                        {
                            s += NL;
                            s += "            row." + x.PName + GetConversion(x.PCSharpType) + "(" + GetRow(x.PName) + ");";
                        }
                    });

                s += "            row.Exists = true;" + NL;
                s += "            row.HasChanged = false;" + NL;
                s += "        }" + NL;

                return s;
            }
        }

        private string GetData
        {
            get
            {
                string s = NL + "        ";
                s += "internal DataTable GetData(string orderBy)" + NL;
                s += "        {" + NL;
                s += @"            string q = ""SELECT "";" + NL;
                s += @"            if (dataHelper.MaxRows != 0)" + NL;
                s += @"                q += "" TOP "" + dataHelper.MaxRows.ToString() + "" "";" + NL;
                s += @"            q += _selectColumnNames + ""\n"";" + NL;
                s += @"            q += ""FROM dbo." + this.ClassName + " AS " + TH + @"\n"";" + NL;
                s += @"            if (orderBy != """")" + NL;
                s += @"                q += ""ORDER BY "" + orderBy;" + NL + NL;
                s += @"            return dataHelper.ExecuteQuery(dataHelper.CreateCommand(q));" + NL;
                s += "        }" + NL;
                return s;
            }
        }

        private string UpdateData
        {
            get
            {
                string s = NL + "        ";
                s += "private UpdateProperties UpdateData()" + NL;
                s += "        {" + NL;
                s += @"string q = ""UPDATE dbo." + this.ClassName + " SET";

                Prop.ForEach(x =>
                    {
                        if (x.PName != Prop.Last().PName)
                            s += " " + GetDBVariable(x.PName) + " = " + GetCSPlaceHolder(x.PName) + ",";
                        else
                            s += " " + GetDBVariable(x.PName) + " = " + GetCSPlaceHolder(x.PName) + @"\n"";" + NL;
                    });

                s += @"q += ""WHERE ID = @ID\n"";" + NL;
                s += @"q += ""SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'"";" + NL;

                s += NL + @"             SqlCommand cmd = dataHelper.CreateCommand(q);" + NL + NL;

                s = ICantThinkOfANameForThisMethodRightNowBecauseItDoesSoMuchShit(s) + NL;

                s += "          UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);" + NL;
                s += "          base.HasChanged = false;" + NL;
                s += "          return up;" + NL;
                s += "        }" + NL;

                return s;
            }
        }

        private string InsertData
        {
            get
            {
                string s = NL + "        ";
                s += "private UpdateProperties InsertData()" + NL;
                s += "        {" + NL;
                s += @"              string q = ""INSERT INTO dbo." + this.ClassName + " ( ";

                Prop.ForEach(x =>
                    {
                        if (x.PName != Prop.Last().PName)
                            s += GetDBVariable(x.PName) + ", ";
                        else
                            s += GetDBVariable(x.PName) + @" )\n"";" + NL;
                    });

                s += @"q += ""VALUES ( ";

                Prop.ForEach(x =>
                    {
                        if (x.PName != Prop.Last().PName)
                            s += GetCSPlaceHolder(x.PName) + ", ";
                        else
                            s += GetCSPlaceHolder(x.PName) + @" )\n"";" + NL;
                    });

                s += @"            q += ""SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'"";" + NL;
                s += @"            SqlCommand cmd = dataHelper.CreateCommand(q);" + NL + NL;

                s = ICantThinkOfANameForThisMethodRightNowBecauseItDoesSoMuchShit(s) + NL;

                s += "            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);" + NL;
                s += "            ID = up.Identity;" + NL + NL;
                s += "            base.Exists = true; //After instert Exist must be true" + NL;
                s += "            base.HasChanged = false; //After instert Change is false since it is a new record" + NL + NL;
                s += "            return up;" + NL;
                s += "        }" + NL;

                return s;
            }
        }

        private string DeleteItem
        {
            get
            {
                string s = "        ";
                s += "internal void DeleteItem(int id)" + NL;
                s += "        {" + NL;
                s += @"            string q = ""DELETE FROM dbo." + this.ClassName + @"\n"";" + NL;
                s += @"            q += ""WHERE ID = @ID\n"";" + NL + NL;
                s += @"            SqlCommand cmd = dataHelper.CreateCommand(q);" + NL;
                s += @"            cmd.Parameters.Add(""@ID"", SqlDbType.Int).Value = id;" + NL + NL;
                s += @"            dataHelper.ExecuteNonQuery(cmd);" + NL;
                s += "        }" + NL;
                return s;
            }
        }

        private string LoadItemData
        {
            get
            {
                string s = "        ";
                s += "internal void LoadItemData(int iD)" + NL;
                s += "        {" + NL;
                s += @"            string q = ""SELECT "" + _selectColumnNames + "" FROM dbo." + this.ClassName + " " + TH + @"\n"";" + NL;
                s += @"            q += ""WHERE " + TH + @".ID = @ID\n"";" + NL + NL;
                s += @"            SqlCommand cmd = dataHelper.CreateCommand(q);" + NL;
                s += @"            cmd.Parameters.Add(""@ID"", SqlDbType.Int).Value = iD;" + NL + NL;
                s += @"            DataTable dt = dataHelper.ExecuteQuery(cmd);" + NL;
                s += @"            if (dt.Rows.Count == 0)" + NL;
                s += @"                base.Exists = false;" + NL;
                s += @"            else" + NL;
                s += @"                SetRowProperties(dt.Rows[0], this);" + NL;
                s += "        }" + NL;
                return s;
            }
        }

        private string PopulateList
        {
            get
            {
                string s = "        ";
                s += "internal void PopulateList(List<Business." + this.ClassName + "> list, DataTable dt)" + NL;
                s += "        {" + NL;
                s += @"            list.Clear();" + NL + NL;
                s += @"            foreach (DataRow dr in dt.Rows)" + NL;
                s += @"            {" + NL;
                s += @"                Business." + this.ClassName + " p = new Business." + this.ClassName + "();" + NL;
                s += @"                SetRowProperties(dr, p);" + NL;
                s += @"                list.Add(p);" + NL;
                s += @"            }" + NL;
                s += "        }" + NL;
                return s;
            }
        }

        private string LoadAll
        {
            get
            {
                string s = "        ";
                s += "internal void LoadAll(List<Business." + this.ClassName + "> list)" + NL;
                s += "        {" + NL;
                s += @"            PopulateList(list, GetData(""""));" + NL;
                s += "        }" + NL;
                return s;
            }
        }


        private string GetDBVariable(string pName)
        {
            return "[" + pName + "]";
        }

        private string GetCSPlaceHolder(string pName)
        {
            return "@" + pName;
        }

        private string GetRow(string pName)
        {
            return @"dr[""" + pName + @"""]";
        }

        private string GetConversion(string dataType)
        {
            string s = " = Convert.To";

            if (dataType.Equals("int"))
                return s += "Int32";
            else if (dataType.Equals("decimal"))
                return s += "Decimal";
            else if (dataType.Equals("long"))
                return s += "Long";
            else if (dataType.Equals("DateTime"))
                return s += "DateTime";
            else if (dataType.Equals("string"))
                return s += "String";
            else
                return s;
        }

        private string GetSQLDataType(string dataType)
        {
            string s = "SqlDbType.";

            if (dataType.Equals("bool"))
                return s += "Bit";
            else if (dataType.Equals("DateTime"))
                return s += "DateTime";
            else if (dataType.Equals("string"))
                return s += "varchar";
            else if (dataType.Equals("int"))
                return s += "Int";
            else if (dataType.Equals("decimal"))
                return s += "Decimal";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            else if (dataType.Equals(""))
                return s += "";
            
            if (dataType.Equals("int"))
                return s += "Int";
            else if (dataType.Equals("decimal"))
                return s += "Decimal";
            else if (dataType.Equals("long"))
                return s += "Long";
            else if (dataType.Equals("DateTime"))
                return s += "DateTime";
            else if (dataType.Equals("string"))
                return s += "VarChar";
            else
                return s;
        }

        private string ICantThinkOfANameForThisMethodRightNowBecauseItDoesSoMuchShit(string s)
        {
            Prop.ForEach(x =>
            {
                if (x.CanBeNull && x.Size == 0)
                {
                    s += NL + "             if (" + x.PName + " == null)" + NL;
                    s += @"                 cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + GetSQLDataType(x.PSQLType) + ").Value = DBNull.Value;" + NL;
                    s += @"             else" + NL;
                    s += @"                 cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + GetSQLDataType(x.PSQLType) + ").Value = " + x.PName + ";" + NL + NL;
                }
                else if (x.CanBeNull == false && x.Size == 0)
                    s += @"                 cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + GetSQLDataType(x.PSQLType) + ").Value = " + x.PName + ";" + NL;
                else if (x.CanBeNull && x.Size > 0)
                {
                    s += NL + "             if (" + x.PName + " == null)" + NL;
                    s += @"                 cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + GetSQLDataType(x.PSQLType) + ", " + x.Size.ToString() + " ).Value = DBNull.Value;" + NL;
                    s += @"             else" + NL;
                    s += @"                 cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + GetSQLDataType(x.PSQLType) + ", " + x.Size.ToString() + " ).Value = " + x.PName + ";" + NL;
                }
                else if (x.CanBeNull == false && x.Size > 0)
                    s += @"                 cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + GetSQLDataType(x.PSQLType) + ", " + x.Size.ToString() + " ).Value = " + x.PName + ";" + NL + NL;
            });
            return s;
        }

        public string GetAll
        {
            get
            {
                string s = "";

                try
                {
                    if (this.Prop.Count > 0)
                    {
                        s += Imports;
                        s += Namespace;
                        s += ClassHeader;
                        s += ColumnNames;
                        s += DataHelper;
                        s += Constructor;
                        s += SetRowProperties;
                        s += GetData;
                        s += UpdateData;
                        s += InsertData;
                        s += DeleteItem;
                        s += LoadItemData;
                        s += PopulateList;
                        s += LoadAll;
                        s += Footer;
                    }

                    this.ErrWhileGenerating = false;
                }
                catch (Exception)
                {
                    this.ErrWhileGenerating = true;
                }
                finally
                {

                }

                return s;
            }
        }

        public List<DataProps> Prop { get; set; }

    }

    public class DataProps
    {
        public string PName { get; set; }
        public string PSQLType { get; set; }
        public string PCSharpType { get; set; }

        private int _size = 0;
        public int Size
        {
            get { return _size; }
            set { _size = value; }

        }

        public bool CanBeNull { get; set; }
    }
}
