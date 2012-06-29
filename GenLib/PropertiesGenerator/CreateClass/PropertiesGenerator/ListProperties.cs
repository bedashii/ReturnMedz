using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateClass.PropertiesGenerator
{
    public class ListProperties : BaseProperties
    {
        public ListProperties(string ns, string className)
            : base(4)
        {
            this.NS = ns;
            Prop = new List<ListProps>();
            this.ClassName = ClassName;
        }

        private string Data
        {
            get { return "Data." + this.ClassName + "Data _data = new Data." + this.ClassName + "Data();" + NL + NL; }
        }

        private string Constructor
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

        private string GetAllDataMethod
        {
            get
            {
                string s = NL;
                s += "        public void GetAll()" + NL;
                s += "        {" + NL;
                s += "            _data.LoadAll(this);" + NL;
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
                    if (this.Prop.Count >= 0)
                    {
                        s += Imports;
                        s += Namespace;
                        s += ClassHeader;
                        s += Data;
                        s += Constructor;
                        s += GetAllDataMethod;
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

        public List<ListProps> Prop;
    }

    public class ListProps
    {
        public string LName { get; set; }
    }
}
