using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Variable;
using System.IO;

namespace CreateClass
{
    public class CreateClass
    {
        public static void WriteData(List<Variables> vList,string className, string path)
        {
            PropertiesGenerator.DataProperties dp = new PropertiesGenerator.DataProperties(System.Configuration.ConfigurationManager.AppSettings["DataNamespace"].ToString(), className);

            foreach (Variables v in vList)
            {
                PropertiesGenerator.DataProps dProps = new PropertiesGenerator.DataProps();
                dProps.PName = v.Name;
                dProps.PSQLType = v.SQLType;
                dProps.PCSharpType = v.CSharpType;
                dProps.CanBeNull = v.AllowNulls;
                dProps.Size = v.VariableSize;
                dp.Prop.Add(dProps);
            }

            Directory.CreateDirectory(path == "" ? "\\Data" : path + "\\Data");
            StreamWriter sw = new StreamWriter(path == "" ? "\\Data\\" + dp.FileName : path + "\\Data\\" + dp.FileName);
            sw.Write(dp.GetAll);
            sw.Close();
        }

        public static void WriteProperties(List<Variables> vList,string className, string path)
        {
            PropertiesGenerator.PropertiesProperties pp = new PropertiesGenerator.PropertiesProperties(System.Configuration.ConfigurationManager.AppSettings["PropertiesNamespace"].ToString(), className);
            
            foreach (Variables v in vList)
            {
                PropertiesGenerator.PropertiesProps pProps = new PropertiesGenerator.PropertiesProps();
                pProps.PName = v.Name;
                pProps.PDataType = v.CSharpType;
                pProps.AllowNulls = v.AllowNulls;
                pp.Prop.Add(pProps);
            }
            Directory.CreateDirectory(path == "" ? "\\Properties" : path + "\\Properties");
            StreamWriter sw = new StreamWriter(path == "" ? "\\Properties\\" + pp.FileName : path + "\\Properties\\" + pp.FileName);
            sw.Write(pp.GetAll);
            sw.Close();
        }

        public static void WriteBusiness(List<Variables> vList, string className, string path)
        {
            PropertiesGenerator.BusinessProperties bp = new PropertiesGenerator.BusinessProperties(System.Configuration.ConfigurationManager.AppSettings["BusinessNamespace"].ToString(), className);
            
            foreach (Variables v in vList)
            {
                PropertiesGenerator.BusinessProps pProps = new PropertiesGenerator.BusinessProps();
                pProps.BName = v.Name;
                bp.Prop.Add(pProps);
            }
            Directory.CreateDirectory(path == "" ? "\\Business" : path + "\\Business");
            StreamWriter sw = new StreamWriter(path == "" ? "\\Business\\" + bp.FileName : path + "\\Business\\" + bp.FileName);
            sw.Write(bp.GetAll);
            sw.Close();
        }

        public static void WriteList(List<Variables> vList, string className, string path)
        {
            PropertiesGenerator.ListProperties lp = new PropertiesGenerator.ListProperties(System.Configuration.ConfigurationManager.AppSettings["ListNamespace"].ToString(), className);
            foreach (Variables v in vList)
            {
                PropertiesGenerator.ListProps pProps = new PropertiesGenerator.ListProps();
                pProps.LName = v.Name;
                lp.Prop.Add(pProps);
            }
            Directory.CreateDirectory(path == "" ? "\\List" : path + "\\List");
            StreamWriter sw = new StreamWriter(path == "" ? "\\List\\" + lp.FileName : path + "\\List\\" + lp.FileName);
            sw.Write(lp.GetAll);
            sw.Close();
        }
    }
}
