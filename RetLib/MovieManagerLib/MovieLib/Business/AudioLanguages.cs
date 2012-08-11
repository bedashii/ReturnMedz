using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MovieLib.Business
{
    public partial class AudioLanguages : Data.AudioLanguagesData
    {

        public AudioLanguages()
        {
        }

        public AudioLanguages(short id)
        {
            PreConstructionTasks();
            this.LoadItemData(id);
            PostConstructionTasks();
        }

        public void LoadItem(short id)
        {
            this.ID = id;
            base.LoadItemData(id);
        }

        public void Refresh(short id)
        {
            base.LoadItemData(id);
        }

        public void SetProperties(MovieLib.Business.AudioLanguages properties)
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