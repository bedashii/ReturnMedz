using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateClass.PropertiesGenerator
{
    public class BusinessProperties : BaseProperties
    {
        public BusinessProperties(string ns, string className)
            : base(3)
        {
            this.NS = ns;
            Prop = new List<BusinessProps>();
            this.ClassName = className;
        }

        private string ConstructorEmpty
        {
            get
            {
                string s = NL;
                s += "        public " + ClassNameFull + "()" + NL;
                s += "        {" + NL;
                s += "        }" + NL;
                return s;
            }
        }

        private string ConstructorWithParameters
        {
            get
            {
                string s = NL;
                s += "        public " + ClassNameFull + "(" + this.PrimaryKeyCSharpType + " " + this.PrimaryKeyName.ToLower() + ")" + NL;
                s += "        {" + NL;
                s += "            PreConstructionTasks();" + NL;
                s += "            this.LoadItemData(" + this.PrimaryKeyName.ToLower() + ");" + NL;
                s += "            PostConstructionTasks();" + NL;
                s += "        }" + NL;
                return s;
            }
        }

        private string LoadItem
        {
            get
            {
                string s = NL;
                s += "        public void LoadItem(" + this.PrimaryKeyCSharpType + " " + this.PrimaryKeyName.ToLower() + ")" + NL;
                s += "        {" + NL;
                s += "            this.ID = id;" + NL;
                s += "            base.LoadItemData(" + this.PrimaryKeyName.ToLower() + ");" + NL;
                s += "        }" + NL;
                return s;
            }
        }

        private string Refresh
        {
            get
            {
                string s = NL;
                s += "        public void Refresh(" + this.PrimaryKeyCSharpType + " " + this.PrimaryKeyName.ToLower() + ")" + NL;
                s += "        {" + NL;
                s += "            base.LoadItemData(" + this.PrimaryKeyName.ToLower() + ");" + NL;
                s += "        }" + NL;
                return s;
            }
        }

        private string SetProperties
        {
            get
            {
                string s = NL;
                s += "        public void SetProperties(" + this.NS + "." + this.ClassName + " properties)" + NL;
                s += "        {" + NL;

                foreach (BusinessProps bp in Prop)
                    s += "            this." + bp.BName + " = properties." + bp.BName + ";" + NL;

                s += "        }" + NL;
                return s;
            }
        }

        private string PreConstructionTasks
        {
            get
            {
                string s = NL;
                s += "        internal virtual void PreConstructionTasks()" + NL;
                s += "        {" + NL;
                s += "        }" + NL;
                return s;
            }
        }

        private string PostConstructionTasks
        {
            get
            {
                string s = NL;
                s += "        internal virtual void PostConstructionTasks()" + NL;
                s += "        {" + NL;
                s += "        }" + NL;
                return s;
            }
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
                        s += ConstructorEmpty;
                        s += ConstructorWithParameters;
                        s += LoadItem;
                        s += Refresh;
                        s += SetProperties;
                        s += PreConstructionTasks;
                        s += PostConstructionTasks;
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

        public string PK { get; set; }
        public List<BusinessProps> Prop { get; set; }
    }

    public class BusinessProps
    {
        public string BName { get; set; }
    }
}
