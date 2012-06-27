using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PropertiesGenerator
{
    public partial class MainMenu : Form
    {
        string _className;

        struct Variables
        {
            public string Name;
            public string Type;
            public int VariableSize;
            public bool AllowNulls;
        }

        public MainMenu()
        {
            InitializeComponent();
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            List<Variables> vList = new List<Variables>();
            
            for (int i = 0; i < DGVProperties.Rows.Count - 1; i++)
            {
                Variables v = new Variables();
                v.Name =  DGVProperties.Rows[i].Cells[0].Value.ToString();
                v.Type = DGVProperties.Rows[i].Cells[1].Value.ToString();
                if (DGVProperties.Rows[i].Cells[2].Value != null && DGVProperties.Rows[i].Cells[2].Value.ToString() != "")
                    v.VariableSize = Convert.ToInt32(DGVProperties.Rows[i].Cells[2].Value.ToString());
                else
                    v.VariableSize = 0;
                v.AllowNulls = Convert.ToBoolean(DGVProperties.Rows[i].Cells[3].Value);
                vList.Add(v);
            }

            WriteProperties(vList);
            WriteData(vList);
        }

        private void WriteData(List<Variables> vList)
        {
            PropertiesGenerator.DataProperties dp = new PropertiesGenerator.DataProperties(System.Configuration.ConfigurationManager.AppSettings["DataNamespace"].ToString(), _className);

            foreach (Variables v in vList)
            {
                PropertiesGenerator.DataProps dProps = new PropertiesGenerator.DataProps();
                dProps.PName = v.Name;
                dProps.PDataType = v.Type;
                dProps.CanBeNull = v.AllowNulls;
                dProps.Size = v.VariableSize;
                dp.Prop.Add(dProps);
            }

            StreamWriter sw = new StreamWriter(dp.FileName);
            sw.Write(dp.GetAll);
            sw.Close();
        }

        private void WriteProperties(List<Variables> vList)
        {
            PropertiesGenerator.PropertiesProperties pp = new PropertiesGenerator.PropertiesProperties(System.Configuration.ConfigurationManager.AppSettings["PropertiesNamespace"].ToString(), _className);

            foreach (Variables v in vList)
            {
                PropertiesGenerator.PropertiesProps pProps = new PropertiesGenerator.PropertiesProps();
                pProps.PName = v.Name;
                pProps.PDataType = v.Type;
                pProps.AllowNulls = v.AllowNulls;
                pp.Prop.Add(pProps);
            }

            StreamWriter sw = new StreamWriter(pp.FileName);
            sw.Write(pp.GetAll);
            sw.Close();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {

        }

        private void TBoxClassName_Validating(object sender, CancelEventArgs e)
        {
            _className = TBoxClassName.Text;
        }
    }
}
