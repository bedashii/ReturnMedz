using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaInfoLib;

namespace MovieLib.Magic
{
    public class File
    {
        #region Declarations

        MediaInfo _mediaInfo;

        #endregion Declarations

        public File()
        {
            _mediaInfo = new MediaInfo();
            VideoCodecs = new List<string>();
            AudioCodecs = new List<string>();
            AudioLanguages = new List<string>();
        }


        #region Properties

        public string FullFileName
        {
            get { return FileName + "." + Extension; }
        }

        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Format { get; set; }
        public List<string> VideoCodecs { get; set; }   
        public List<string> AudioCodecs { get; set; }
        public List<string> AudioLanguages { get; set; }
        public long FileSizeB { get; set; }
        
        public decimal FileSizeMB
        {
            get { return Decimal.Round(FileSizeB / 1048576, 2); }
        }

        public decimal FileSizeGB
        {
            get { return Decimal.Round(FileSizeB / 1073741824, 2); }
        }

        public long DurationMS { get; set; }

        public int DurationM
        {
            get { return Convert.ToInt32(Decimal.Round(Convert.ToDecimal(DurationMS * 0.0000166667), 0)); }
        }

        public long BitRateOverallbps { get; set; }

        public decimal BitRateOverallmbps
        {
            get { return Decimal.Round(Convert.ToDecimal(BitRateOverallbps * 0.000001), 2); }
            }

        #endregion Properties

        #region Public Methods

        public void Open(string fullFileName)
        {
            try
            {
                _mediaInfo.Open(fullFileName);
                SetMovieMagicProperties();
            }
            catch (Exception aDogABone)
            {
                throw aDogABone;
            }
        }

        private void SetMovieMagicProperties()
        {
            FileName = _mediaInfo.Get(StreamKind.General, 0, 48);
            Extension = _mediaInfo.Get(StreamKind.General, 0, 49);
            Format = _mediaInfo.Get(StreamKind.General, 0, 50);
            _mediaInfo.Get(StreamKind.General, 0, 22).Split('\n').ToList().ForEach(x => VideoCodecs.Insert(VideoCodecs.Count, x));
            _mediaInfo.Get(StreamKind.General, 0, 28).Split('\n').ToList().ForEach(x => AudioCodecs.Insert(AudioCodecs.Count, x));
            _mediaInfo.Get(StreamKind.General, 0, 29).Split('\n').ToList().ForEach(x => AudioLanguages.Insert(AudioLanguages.Count, x));
            FileSizeB = Convert.ToInt64(_mediaInfo.Get(StreamKind.General, 0, 76));
            DurationMS = Convert.ToInt64(_mediaInfo.Get(StreamKind.General, 0, 82));
            BitRateOverallbps = Convert.ToInt64(_mediaInfo.Get(StreamKind.General, 0, 91));
        }
        
        #endregion Public Methods
    }
}
