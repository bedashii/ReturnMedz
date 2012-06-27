using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Variable;
using System.IO;

namespace PropertiesGenerator
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
                dProps.PDataType = v.Type;
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
                pProps.PDataType = v.Type;
                pProps.AllowNulls = v.AllowNulls;
                pp.Prop.Add(pProps);
            }
            Directory.CreateDirectory(path == "" ? "\\Properties" : path + "\\Properties");
            StreamWriter sw = new StreamWriter(path == "" ? "\\Properties\\" + pp.FileName : path + "\\Properties\\" + pp.FileName);
            sw.Write(pp.GetAll);
            sw.Close();
        }
    }
}
