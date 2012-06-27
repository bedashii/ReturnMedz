using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Business
{
    public partial class Format: Data.FormatData
    {
        static Lists.FormatList FormatList = new Lists.FormatList();

        public Format()
        {
        }

        public Format(int id)
        {
            PreConstructionTasks();
            this.LoadItemData(id);
            PostConstructionTasks();
        }

        public Format(string formatName, string formatExtension)
        {
            PreConstructionTasks();
            this.FormatName = formatName;
            this.FormatExtension = formatExtension;
            PostConstructionTasks();
        }

        public void LoadItem(int id)
        {
            this.ID = id;
            base.LoadItemData(id);
        }

        private void SetProperties(RetLib.Properties.FormatProperties properties)
        {
            this.FormatName = properties.FormatName;
            this.FormatExtension = properties.FormatExtension;
        }

        public void Refresh()
        {
            base.LoadItemData(this.ID);
        }

        internal virtual void PreConstructionTasks()
        {
        }

        internal virtual void PostConstructionTasks()
        {
        }

        internal void CheckExtension(string formatExtension)
        {
            if (FormatList == null)
            {
                FormatList = new Lists.FormatList();
                FormatList.GetAll();
            }

            if (FormatList.Exists(x => x.FormatExtension == formatExtension) == false)
            {
                FormatList.Add(new Format("", formatExtension));
                //FormatList.
            }
        }
    }
}
