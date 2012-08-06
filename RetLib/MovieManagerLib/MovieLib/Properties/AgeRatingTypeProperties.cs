using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Properties
{
    public partial class AgeRatingTypeProperties : PropertiesBase
    {

        public AgeRatingTypeProperties()
        {
        }

        partial void OnIDChanging();
        partial void OnIDChanged();
        private byte _id;
        public byte ID
        {
            get { return _id; }
            set
            {
                OnIDChanging();
                _id = value;
                base.HasChanged = true;
                OnIDChanged();
            }
        }

        partial void OnAgeRatingChanging();
        partial void OnAgeRatingChanged();
        private string _ageRating;
        public string AgeRating
        {
            get { return _ageRating; }
            set
            {
                OnAgeRatingChanging();
                _ageRating = value;
                base.HasChanged = true;
                OnAgeRatingChanged();
            }
        }

        partial void OnAgeRatingDescriptionChanging();
        partial void OnAgeRatingDescriptionChanged();
        private string _ageRatingDescription;
        public string AgeRatingDescription
        {
            get { return _ageRatingDescription; }
            set
            {
                OnAgeRatingDescriptionChanging();
                _ageRatingDescription = value;
                base.HasChanged = true;
                OnAgeRatingDescriptionChanged();
            }
        }
    }
}