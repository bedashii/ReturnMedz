using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MovieLib.Business
{
    public partial class VideoQualityType : Data.VideoQualityTypeData
    {

        public VideoQualityType()
        {
        }

        public VideoQualityType(int id)
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

        public void SetProperties(MovieLib.Business.VideoQualityType properties)
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

        public int GetVideoQualityType(string videoHeight)
        {
            if (videoHeight != null)
            {
                int vh = Convert.ToInt32(videoHeight);
                if (vh < 720)
                    return 1;
                else if (vh >= 720 && vh < 1080)
                    return 2;
                else if (vh >= 1080)
                    return 3;
            }
            
            return 0;
        }
    }
}