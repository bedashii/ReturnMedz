using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MovieLib.Business
{
    public partial class SysConfig : Data.SysConfigData
    {
        private string p;

        public SysConfig()
        {
        }

        public SysConfig(int id)
        {
            PreConstructionTasks();
            this.LoadItemData(id);
            PostConstructionTasks();
        }

        public SysConfig(string setting)
        {
            PreConstructionTasks();
            this.LoadItemData(setting);
            PostConstructionTasks();
        }

        public void LoadItem(int id)
        {
            this.ID = id;
            base.LoadItemData(id);
        }

        public void LoadItem(string setting)
        {
            this.Setting = setting;
            base.LoadItemData(setting);
        }

        public void Refresh(int id)
        {
            base.LoadItemData(id);
        }

        public void SetProperties(MovieLib.Business.SysConfig properties)
        {
            this.ID = properties.ID;
            this.Setting = properties.Setting;
            this.Config = properties.Config;
        }

        internal virtual void PreConstructionTasks()
        {
        }

        internal virtual void PostConstructionTasks()
        {
        }
    }
}