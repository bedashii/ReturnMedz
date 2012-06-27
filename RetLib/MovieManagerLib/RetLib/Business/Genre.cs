using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Business
{
    public partial class Genre : Data.GenreData
    {
        public Genre()
        {
        }

        public Genre(int id)
        {
            PreConstructionTasks();
            this.LoadItemData(id);
            PostConstructionTasks();
        }

        public Genre(string genreName)
        {
            PreConstructionTasks();
            this.GenreName = genreName;
            PostConstructionTasks();
        }

        public void LoadItem(int id)
        {
            this.ID = id;
            base.LoadItemData(id);
        }

        private void SetProperties(RetLib.Properties.GenreProperties properties)
        {
            this.GenreName = properties.GenreName;
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
    }
}
