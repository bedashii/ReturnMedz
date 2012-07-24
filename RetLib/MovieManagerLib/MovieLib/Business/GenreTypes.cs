using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MovieLib.Business
{
    public partial class GenreTypes : Data.GenreTypesData
    {

        public GenreTypes()
        {
        }

        public GenreTypes(int id)
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

        public void Refresh(int id)
        {
            base.LoadItemData(id);
        }

        public void SetProperties(MovieLib.Business.GenreTypes properties)
        {
            this.ID = properties.ID;
            this.Description = properties.Description;
        }

        internal virtual void PreConstructionTasks()
        {
        }

        internal virtual void PostConstructionTasks()
        {
        }
    }
}