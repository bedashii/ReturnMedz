// Author: LB
// Edited: 2012-08-06

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateClass.PropertiesGenerator
{
    public partial class BaseProperties
    {
        protected string NL = Environment.NewLine;
        protected string NS;

        internal string InternalItem
        {
            get
            {
                return this.ClassName.Substring(0, 1).ToLower() + this.ClassName.Substring(1, this.ClassName.Length - 1);
            }
        }
        
        internal string FileName
        {
            get
            {
                switch (this.ClassType)
                {
                    case 1:
                        return this.ClassName + "Properties.cs";
                    case 2:
                        return this.ClassName + "Data.cs";
                    case 3:
                        return this.ClassName + ".cs";
                    case 4:
                        return this.ClassName + "List.cs";
                    default:
                        return null;
                }
            }
        }

        protected string ClassNameFull
        {
            get
            {
                switch (this.ClassType)
                {
                    case 1:
                        return this.ClassName + "Properties";
                    case 2:
                        return this.ClassName + "Data";
                    case 3:
                        return this.ClassName;
                    case 4:
                        return this.ClassName + "List";
                    default:
                        return null;
                }
            }
        }

        protected BaseProperties(int classType)
        {
            this.ClassType = classType;
        }

        protected int ClassType { get; set; }

        protected string Imports
        {
            get
            {
                string s = "";

                switch (this.ClassType)
                {
                    case 1: // Properties
                        s += "using System;" + NL;
                        s += "using System.Collections.Generic;" + NL;
                        s += "using System.Linq;" + NL;
                        s += "using System.Text;" + NL;
                        return s;
                    case 2: // Data
                        s += "using System;" + NL;
                        s += "using System.Data;" + NL;
                        s += "using System.Data.SqlClient;" + NL;
                        s += "using System.Collections.Generic;" + NL;
                        s += "using System.Linq;" + NL;
                        s += "using System.Text;" + NL;
                        return s;
                    case 3: // Business
                        s += "using System;" + NL;
                        s += "using System.Collections.Generic;" + NL;
                        s += "using System.Linq;" + NL;
                        s += "using System.Text;" + NL;
                        s += "using System.Xml;" + NL;
                        return s;
                    case 4: // List
                        s += "using System;" + NL;
                        s += "using System.Collections.Generic;" + NL;
                        s += "using System.Linq;" + NL;
                        s += "using System.Text;" + NL;
                        return s;
                    default:
                        return s;
                }
            }
        }

        private string _className;
        protected string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        protected string Namespace
        {
            get { return "namespace " + NS + NL + "{" + NL; }
        }

        protected string ClassHeader
        {
            get
            {
                string s = "    ";
                s += "public partial class " + ClassNameFull;

                switch (this.ClassType)
                {
                    case 1:
                        s += " : PropertiesBase";
                        break;
                    case 2:
                        s += " : Properties." + this.ClassName + "Properties";
                        break;
                    case 3:
                        s += " : Data." + this.ClassName + "Data";
                        break;
                    case 4:
                        s += " : List<Business." + this.ClassName + ">";
                        break;
                }

                s += NL + "    {" + NL;
                return s;
            }
        }

        protected string Footer
        {
            get { return "    }" + NL + "}"; }
        }

        private bool _errWhileGenerating = false;
        public bool ErrWhileGenerating 
        {
            get { return _errWhileGenerating; }
            set { _errWhileGenerating = value; }
        }

        public string PrimaryKeyName { get; set; }
        public string PrimaryKeySQLType { get; set; }
        public string PrimaryKeyCSharpType { get; set; }
    }
}
