using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Properties
{
    public partial class MovieProperties : PropertiesBase
    {
        public MovieProperties()
        {
        }

        partial void OnIDChanging();
        partial void OnIDChanged();
        private int _id;
        public int ID
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
        
        partial void OnTitleChanging();
        partial void OnTitleChanged();
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                OnTitleChanging();
                _title = value;
                base.HasChanged = true;
                OnTitleChanged();
            }
        }

        partial void OnSubtitleChanging();
        partial void OnSubtitleChanged();
        private string _subtitle;
        public string Subtitle
        {
            get { return _subtitle; }
            set
            {
                OnSubtitleChanging();
                _subtitle = value;
                base.HasChanged = true;
                OnSubtitleChanged();
            }
        }


        partial void OnSequenceNumberChanging();
        partial void OnSequenceNumberChanged();
        private int? _sequenceNumber;
        public int? SequenceNumber
        {
            get { return _sequenceNumber; }
            set
            {
                OnSequenceNumberChanging();
                _sequenceNumber = value;
                base.HasChanged = true;
                OnSequenceNumberChanged();
            }
        }

        partial void OnSynopsisChanging();
        partial void OnSynopsisChanged();
        private string _synopsis;
        public string Synopsis
        {
            get { return _synopsis; }
            set
            {
                OnSynopsisChanging();
                _synopsis = value;
                base.HasChanged = true;
                OnSynopsisChanged();
            }
        }


        partial void OnReleaseDateChanging();
        partial void OnReleaseDateChanged();
        private DateTime? _releaseDate;
        public DateTime? ReleaseDate
        {
            get { return _releaseDate; }
            set
            {
                OnReleaseDateChanging();
                _releaseDate = value;
                base.HasChanged = true;
                OnReleaseDateChanged();
            }
        }


        partial void OnRunningTimeChanging();
        partial void OnRunningTimeChanged();
        private int? _runningTime;
        public int? RunningTime
        {
            get { return _runningTime; }
            set
            {
                OnRunningTimeChanging();
                _runningTime = value;
                base.HasChanged = true;
                OnRunningTimeChanged();
            }
        }


        partial void OnIMDBRatingChanging();
        partial void OnIMDBRatingChanged();
        private decimal? _iMDBRating;
        public decimal? IMDBRating
        {
            get { return _iMDBRating; }
            set
            {
                OnIMDBRatingChanging();
                _iMDBRating = value;
                base.HasChanged = true;
                OnIMDBRatingChanged();
            }
        }


        partial void OnFormatTypeChanging();
        partial void OnFormatTypeChanged();
        private int _formatType;
        public int FormatType
        {
            get { return _formatType; }
            set
            {
                OnFormatTypeChanging();
                _formatType = value;
                base.HasChanged = true;
                OnFormatTypeChanged();
            }
        }


        partial void OnQualityTypeChanging();
        partial void OnQualityTypeChanged();
        private int _qualityType;
        public int QualityType
        {
            get { return _qualityType; }
            set
            {
                OnQualityTypeChanging();
                _qualityType = value;
                base.HasChanged = true;
                OnQualityTypeChanged();
            }
        }


        partial void OnGenre1Changing();
        partial void OnGenre1Changed();
        private int _genre1;
        public int Genre1
        {
            get { return _genre1; }
            set
            {
                OnGenre1Changing();
                _genre1 = value;
                base.HasChanged = true;
                OnGenre1Changed();
            }
        }


        partial void OnGenre2Changing();
        partial void OnGenre2Changed();
        private int? _genre2;
        public int? Genre2
        {
            get { return _genre2; }
            set
            {
                OnGenre2Changing();
                _genre2 = value;
                base.HasChanged = true;
                OnGenre2Changed();
            }
        }


        partial void OnGenre3Changing();
        partial void OnGenre3Changed();
        private int? _genre3;
        public int? Genre3
        {
            get { return _genre3; }
            set
            {
                OnGenre3Changing();
                _genre3 = value;
                base.HasChanged = true;
                OnGenre3Changed();
            }
        }
    }
}
