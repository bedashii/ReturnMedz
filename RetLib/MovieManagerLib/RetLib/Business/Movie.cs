using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace RetLib.Business
{
    public partial class Movie : RetLib.Data.MovieData
    {
        public Movie()
        {
        }

        public Movie(int id)
        {
            PreConstructionTasks();
            this.LoadItemData(id);
            PostConstructionTasks();
        }

        public Movie(XmlDocument movieXML, string formatExtension)
        {
            PreConstructionTasks();
            XmlNode node = movieXML["Title"];
            Business.Format format = new Format();
            format.CheckExtension(formatExtension);

            //this = new Movie(node["LocalTitle"], node["Description"], movieXML["Type"], 
        }

        public Movie(string title, string synposis, int formatType, int qualityType, int genre1)
        {
            PreConstructionTasks();

            this.Title = title;
            this.Synopsis = synposis;
            this.FormatType = formatType;
            this.QualityType = qualityType;
            this.Genre1 = genre1;

            PostConstructionTasks();
        }

        public void LoadItem(int id)
        {
            this.ID = id;
            base.LoadItemData(id);
        }

        public void Refresh()
        {
            base.LoadItemData(this.ID);
        }

        private void SetProperties(RetLib.Properties.MovieProperties properties)
        {
            this.Title = properties.Title;
            this.Subtitle = properties.Subtitle;
            this.SequenceNumber = properties.SequenceNumber;
            this.Synopsis = properties.Synopsis;
            this.ReleaseDate = properties.ReleaseDate;
            this.RunningTime = properties.RunningTime;
            this.IMDBRating = properties.IMDBRating;
            this.FormatType = properties.FormatType;
            this.QualityType = properties.QualityType;
            this.Genre1 = properties.Genre1;
            this.Genre2 = properties.Genre2;
            this.Genre3 = properties.Genre3;
            this.Exists = properties.Exists;
        }

        internal virtual void PreConstructionTasks()
        {
        }

        internal virtual void PostConstructionTasks()
        {
        }

        
    }
}
