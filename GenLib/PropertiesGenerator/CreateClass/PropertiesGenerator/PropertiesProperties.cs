﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateClass.PropertiesGenerator
{
    public class PropertiesProperties : BaseProperties
    {
        public PropertiesProperties(string ns, string className)
            : base(1)
        {
            this.NS = ns;
            this.ClassName = className;
            Prop = new List<PropertiesProps>();
        }

        private string Constructor
        {
            get
            {
                string s = NL + "        ";
                s += "public " + ClassNameFull + "()" + NL;
                s += "        {" + NL;
                s += "        }" + NL;
                return s;
            }
        }

        public List<PropertiesProps> Prop { get; set; }

        private List<string> PropsAll
        {
            get
            {
                List<string> sList = new List<string>();

                Prop.ForEach(x =>
                    {
                        string s = NL;
                        s += "        partial void On" + x.PName + "Changing();" + NL;
                        s += "        partial void On" + x.PName + "Changed();" + NL;

                        if (x.PName.ToLower() == "" + this.PrimaryKeyName.ToLower() + "")
                        {
                            s += "        private " + x.PDataType + " _" + this.PrimaryKeyName.ToLower() + ";" + NL;
                            s += "        public " + x.PDataType + " " + this.PrimaryKeyName + "" + NL;
                            s += "        {" + NL;
                            s += "            get { return _" + this.PrimaryKeyName.ToLower() + "; }" + NL;
                            s += "            set" + NL;
                            s += "            {" + NL;
                            s += "                On" + x.PName + "Changing();" + NL;
                            s += "                _" + this.PrimaryKeyName.ToLower() + " = value;" + NL;
                            s += "                base.HasChanged = true;" + NL;
                            s += "                On" + x.PName + "Changed();" + NL;
                            s += "            }" + NL;
                            s += "        }" + NL;
                        }
                        else if (x.AllowNulls)
                        {
                            s += "        private " + x.PDataType + "? " + GetVariable(x.PName) + ";" + NL;
                            s += "        public " + x.PDataType + "? " + x.PName + NL;
                            s += "        {" + NL;
                            s += "            get { return " + GetVariable(x.PName) + "; }" + NL;
                            s += "            set" + NL;
                            s += "            {" + NL;
                            s += "                On" + x.PName + "Changing();" + NL;
                            s += "                " + GetVariable(x.PName) + " = value;" + NL;
                            s += "                base.HasChanged = true;" + NL;
                            s += "                On" + x.PName + "Changed();" + NL;
                            s += "            }" + NL;
                            s += "        }" + NL;
                        }
                        else
                        {
                            s += "        private " + x.PDataType + " " + GetVariable(x.PName) + ";" + NL;
                            s += "        public " + x.PDataType + " " + x.PName + NL;
                            s += "        {" + NL;
                            s += "            get { return " + GetVariable(x.PName) + "; }" + NL;
                            s += "            set" + NL;
                            s += "            {" + NL;
                            s += "                On" + x.PName + "Changing();" + NL;
                            s += "                " + GetVariable(x.PName) + " = value;" + NL;
                            s += "                base.HasChanged = true;" + NL;
                            s += "                On" + x.PName + "Changed();" + NL;
                            s += "            }" + NL; 
                            s += "        }" + NL;
                        }

                        sList.Add(s);
                    });

                return sList;
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
                        s += Constructor;
                        PropsAll.ForEach(x => s += x);
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

        private string GetVariable(string v)
        {
            return "_" + v.Substring(0, 1).ToLower() + v.Substring(1, v.Length - 1);
        }
    }

    public class PropertiesProps
    {
        public string PName { get; set; }
        public string PDataType { get; set; }
        public bool AllowNulls { get; set; }
    }
}
