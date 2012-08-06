using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MovieLib.Business
{
    public partial class File : Data.FileData
    {

        public File()
        {
        }

        public File(int id)
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

        public void SetProperties(MovieLib.Business.File properties)
        {
            this.ID = properties.ID;
            this.Name = properties.Name;
            this.Size = properties.Size;
            this.ExtensionID = properties.ExtensionID;
            this.VideoQuality = properties.VideoQuality;
            this.AudioQuality = properties.AudioQuality;
        }

        internal virtual void PreConstructionTasks()
        {
        }

        internal virtual void PostConstructionTasks()
        {
        }


        private string _videoHeight;
        public string VideoHeight
        {
            get
            {
                return _videoHeight;
            }
            set
            {
                _videoHeight = value;

                
                    
            }
        }
    }
}