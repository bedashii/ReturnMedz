using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MovieLib.Business
{
    public partial class ExtensionType : Data.ExtensionTypeData
    {

        public ExtensionType()
        {
        }

        public ExtensionType(byte id)
        {
            PreConstructionTasks();
            this.LoadItemData(id);
            PostConstructionTasks();
        }

        public void LoadItem(byte id)
        {
            this.ID = id;
            base.LoadItemData(id);
        }

        public void Refresh(byte id)
        {
            base.LoadItemData(id);
        }

        public void SetProperties(MovieLib.Business.ExtensionType properties)
        {
            this.ID = properties.ID;
            this.Extension = properties.Extension;
            this.ExtensionDescription = properties.ExtensionDescription;
        }

        internal virtual void PreConstructionTasks()
        {
        }

        internal virtual void PostConstructionTasks()
        {
        }
    }
}