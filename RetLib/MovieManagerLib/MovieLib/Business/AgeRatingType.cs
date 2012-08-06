using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MovieLib.Business
{
    public partial class AgeRatingType : Data.AgeRatingTypeData
    {

        public AgeRatingType()
        {
        }

        public AgeRatingType(byte id)
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

        public void SetProperties(MovieLib.Business.AgeRatingType properties)
        {
            this.ID = properties.ID;
            this.AgeRating = properties.AgeRating;
            this.AgeRatingDescription = properties.AgeRatingDescription;
        }

        internal virtual void PreConstructionTasks()
        {
        }

        internal virtual void PostConstructionTasks()
        {
        }
    }
}