using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieLib.Business;
using MovieLib.List;

namespace ReturnMovieManagerWF.Processors
{
    public class MovieAddProcessor
    {
        MediaInfoLib.MediaInfo _mediaInfo;
        File _file;

        public MovieAddProcessor()
        {
            _mediaInfo = new MediaInfoLib.MediaInfo();
            _file = new File();
        }

        public void GetInfo()
        {
            string s = _mediaInfo.Get(MediaInfoLib.StreamKind.General, 1, 53);
        }

        #region Properties

        private string _fileName;
        public string FileName
        {
            get
            { return _fileName; }
            set
            {
                _fileName = value;
                _mediaInfo.Open(_fileName);
                SetFileProperties();
            }
        }

        #endregion Properties

        #region SetMethods

        private void SetFileProperties()
        {
            _file.Name = _mediaInfo.Get(MediaInfoLib.StreamKind.General, 1, 49);
            _file.VideoHeight = _mediaInfo.Get(MediaInfoLib.StreamKind.Video, 1, 25);
        }

        #endregion SetMethods




    }
}
