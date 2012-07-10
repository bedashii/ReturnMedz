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
            Prop = new DataPropsList();
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
                s += NL;
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

        private string UpdateProperties
        {
            get
            {
                string s = NL + "        ";
                s += "private UpdateProperties UpdateData()" + NL;
                s += "        {" + NL;
                s += @"            string q = ""UPDATE dbo." + this.ClassName + " SET";

                Prop.ForEach(x =>
                    {
                        if (x.PName != Prop.Last().PName)
                            s += " " + GetDBVariable(x.PName) + " = " + GetCSPlaceHolder(x.PName) + ",";
                        else
                            s += " " + GetDBVariable(x.PName) + " = " + GetCSPlaceHolder(x.PName) + @"\n"";" + NL;
                    });

                s += @"            q += ""WHERE ID = @ID\n"";" + NL;
                s += @"            q += ""SELECT SCOPE_IDENTITY() 'ID', @@ROWCOUNT 'RowCount'"";" + NL + NL;
                s += @"            SqlCommand cmd = dataHelper.CreateCommand(q);" + NL + NL;

                s = ICantThinkOfANameForThisMethodRightNowBecauseItDoesSoMuchShit(s) + NL;

                s += "            UpdateProperties up = dataHelper.ExecuteAndReturn(cmd);" + NL;
                s += "            base.HasChanged = false;" + NL;
                s += "            return up;" + NL;
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
                s += @"            string q = ""INSERT INTO dbo." + this.ClassName + " ( ";

                Prop.ForEach(x =>
                    {
                        if (x.PName != Prop.Last().PName)
                            s += GetDBVariable(x.PName) + ", ";
                        else
                            s += GetDBVariable(x.PName) + @" )\n"";" + NL;
                    });

                s += @"            q += ""VALUES ( ";

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

        private string GetConversion(string cSharpType)
        {
            //string s = " = Convert.To";

            //switch (dataType)
            //{
            //    case "int":
            //        return s += "Int32";
            //    case "bool":
            //    return s += "ToBoolean";
            //    case "DateTime":
            //    return s += "DateTime";
            //    case "decimal":
            //    return s += "Decimal";
            //    case "float":
            //    return s += "Double";
            //    case "long":
            //        return s += "Int64";
            //    case "short":
            //        return s += "Int16";
            //    case "byte":
            //        return s += "Byte";
            //    case "string":
            //    case "Guid":
            //        return s += "String";
            //    default:
            //        return "";
            //}

            return " = Convert.To" + this.Prop.CSharpThesaurus[cSharpType];
            
        }

        //private string GetSQLDataType(string dataType)
        //{
        //    string s = "SqlDbType.";

        //    if (dataType.Equals("bool"))
        //        return s += "Bit";
        //    else if (dataType.Equals("DateTime"))
        //        return s += "DateTime";
        //    else if (dataType.Equals("string"))
        //        return s += "varchar";
        //    else if (dataType.Equals("int"))
        //        return s += "Int";
        //    else if (dataType.Equals("decimal"))
        //        return s += "Decimal";
            
        //    if (dataType.Equals("int"))
        //        return s += "Int";
        //    else if (dataType.Equals("decimal"))
        //        return s += "Decimal";
        //    else if (dataType.Equals("long"))
        //        return s += "Long";
        //    else if (dataType.Equals("DateTime"))
        //        return s += "DateTime";
        //    else if (dataType.Equals("string"))
        //        return s += "VarChar";
        //    else
        //        return s;
        //}

        private string ICantThinkOfANameForThisMethodRightNowBecauseItDoesSoMuchShit(string s)
        {
            Prop.ForEach(x =>
            {
                if (x.CanBeNull && x.Size == 0)
                {
                    s += NL + "            if (" + x.PName + " == null)" + NL;
                    s += @"                cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + x.PSQLType + ").Value = DBNull.Value;" + NL;
                    s += @"            else" + NL;
                    s += @"                cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + x.PSQLType + ").Value = " + x.PName + ";" + NL + NL;
                }
                else if (x.CanBeNull == false && x.Size == 0)
                    s += @"            cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + x.PSQLType + ").Value = " + x.PName + ";" + NL;
                else if (x.CanBeNull && x.Size > 0)
                {
                    s += NL + "            if (" + x.PName + " == null)" + NL;
                    s += @"                cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + x.PSQLType + ", " + x.Size.ToString() + ").Value = DBNull.Value;" + NL;
                    s += @"            else" + NL;
                    s += @"                cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + x.PSQLType + ", " + x.Size.ToString() + ").Value = " + x.PName + ";" + NL;
                }
                else if (x.CanBeNull == false && x.Size > 0)
                    s += @"            cmd.Parameters.Add(""" + GetCSPlaceHolder(x.PName) + @""", " + x.PSQLType + ", " + x.Size.ToString() + ").Value = " + x.PName + ";" + NL + NL;
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
                        s += UpdateProperties;
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

        public DataPropsList Prop { get; set; }

    }

    public class DataPropsList : List<DataProps>
    {
        public Dictionary<string, string> CSharpDictionary { get; set; }
        public Dictionary<string, string> CSharpThesaurus { get; set; }
        public Dictionary<string, string> SQLDictionary { get; set; }
        public Dictionary<string, string> SQLThesaurus { get; set; }

        public DataPropsList()
        {
            CSharpDictionary = new Dictionary<string, string>();
            CSharpThesaurus = new Dictionary<string, string>();
            SQLDictionary = new Dictionary<string, string>();
            SQLThesaurus = new Dictionary<string, string>();

            SetCSharpDictionary();
            SetCSharpThesaurus();
            SetSQLDictionary();
            SetSQLThesaurus();
        }

        private void SetCSharpDictionary()
        {
            CSharpDictionary.Add("Int", "int");
            CSharpDictionary.Add("VarChar", "string");
            CSharpDictionary.Add("Bit", "bool");
            CSharpDictionary.Add("DateTime", "DateTime");
            CSharpDictionary.Add("Decimal", "decimal");
            CSharpDictionary.Add("Float", "float");
            CSharpDictionary.Add("UniqueIdentifier", "Guid");
            CSharpDictionary.Add("Short", "short");
            CSharpDictionary.Add("TinyInt", "byte");
            CSharpDictionary.Add("Variant", "object");
        }

        private void SetCSharpThesaurus()
        {
            CSharpThesaurus.Add("int", "Int32");
            CSharpThesaurus.Add("bool", "Boolean");
            CSharpThesaurus.Add("DateTime", "DateTime");
            CSharpThesaurus.Add("decimal", "Decimal");
            CSharpThesaurus.Add("float", "Double");
            CSharpThesaurus.Add("long", "Int64");
            CSharpThesaurus.Add("short", "Int16");
            CSharpThesaurus.Add("byte", "Byte");
            CSharpThesaurus.Add("string", "String");
            CSharpThesaurus.Add("Guid", "String");
        }

        private void SetSQLDictionary()
        {
            SQLDictionary.Add("BigInt", "int");
            SQLDictionary.Add("Binary", "string");
            SQLDictionary.Add("Bit", "bool");
            SQLDictionary.Add("Char", "string");
            SQLDictionary.Add("DateTime", "DateTime");
            SQLDictionary.Add("Decimal", "decimal");
            SQLDictionary.Add("Float", "float");
            SQLDictionary.Add("Int", "int");
            SQLDictionary.Add("Money", "decimal");
            SQLDictionary.Add("NChar", "string");
            SQLDictionary.Add("NText", "string");
            SQLDictionary.Add("NVarChar", "string");
            SQLDictionary.Add("Real", "float");
            SQLDictionary.Add("UniqueIdentifier", "Guid");
            SQLDictionary.Add("SmallDateTime", "DateTime");
            SQLDictionary.Add("SmallInt", "short");
            SQLDictionary.Add("SmallMoney", "decimal");
            SQLDictionary.Add("Text", "string");
            SQLDictionary.Add("Timestamp", "DateTime");
            SQLDictionary.Add("TinyInt", "byte");
            SQLDictionary.Add("VarBinary", "string");
            SQLDictionary.Add("VarChar", "string");
            SQLDictionary.Add("Variant", "object");
            SQLDictionary.Add("Xml", "string");
            SQLDictionary.Add("Date", "DateTime");
            SQLDictionary.Add("Time", "DateTime");
            SQLDictionary.Add("DateTime2", "DateTime");
            SQLDictionary.Add("DateTimeOffset", "DateTime");
        }

        private void SetSQLThesaurus()
        {
            SQLThesaurus.Add("bigint", "BigInt");
            SQLThesaurus.Add("binary", "Binary");
            SQLThesaurus.Add("bit", "Bit");
            SQLThesaurus.Add("char", "Char");
            SQLThesaurus.Add("datetime", "DateTime");
            SQLThesaurus.Add("decimal", "Decimal");
            SQLThesaurus.Add("float", "Float");
            SQLThesaurus.Add("int", "Int");
            SQLThesaurus.Add("money", "Money");
            SQLThesaurus.Add("nchar", "NChar");
            SQLThesaurus.Add("ntext", "NText");
            SQLThesaurus.Add("nvarchar", "NVarChar");
            SQLThesaurus.Add("real", "Real");
            SQLThesaurus.Add("uniqueidentifier", "UniqueIdentifier");
            SQLThesaurus.Add("smalldatetime", "SmallDateTime");
            SQLThesaurus.Add("smallint", "SmallInt");
            SQLThesaurus.Add("smallmoney", "SmallMoney");
            SQLThesaurus.Add("text", "Text");
            SQLThesaurus.Add("timestamp", "Timestamp");
            SQLThesaurus.Add("tinyint", "TinyInt");
            SQLThesaurus.Add("varbinary", "VarBinary");
            SQLThesaurus.Add("varchar", "VarChar");
            SQLThesaurus.Add("Variant", "Variant");
            SQLThesaurus.Add("xml", "Xml");
            SQLThesaurus.Add("date", "Date");
            SQLThesaurus.Add("time", "Time");
            SQLThesaurus.Add("datetime2", "DateTime2");
            SQLThesaurus.Add("datetimeoffset", "DateTimeOffset");
        }
    }

    public class DataProps
    {
        public DataProps()
        {
        }
        
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
