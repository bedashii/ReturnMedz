using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Properties
{
    public partial class InfoFileProperties : PropertiesBase
    {

        public InfoFileProperties()
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

        partial void OnFileNameChanging();
        partial void OnFileNameChanged();
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                OnFileNameChanging();
                _fileName = value;
                base.HasChanged = true;
                OnFileNameChanged();
            }
        }

        partial void OnFullFileNameChanging();
        partial void OnFullFileNameChanged();
        private string _fullFileName;
        public string FullFileName
        {
            get { return _fullFileName; }
            set
            {
                OnFullFileNameChanging();
                _fullFileName = value;
                base.HasChanged = true;
                OnFullFileNameChanged();
            }
        }

        partial void OnExtensionChanging();
        partial void OnExtensionChanged();
        private byte _extension;
        public byte Extension
        {
            get { return _extension; }
            set
            {
                OnExtensionChanging();
                _extension = value;
                base.HasChanged = true;
                OnExtensionChanged();
            }
        }

        partial void OnAudioLanguage1Changing();
        partial void OnAudioLanguage1Changed();
        private short? _audioLanguage1;
        public short? AudioLanguage1
        {
            get { return _audioLanguage1; }
            set
            {
                OnAudioLanguage1Changing();
                _audioLanguage1 = value;
                base.HasChanged = true;
                OnAudioLanguage1Changed();
            }
        }

        partial void OnAudioLanguage2Changing();
        partial void OnAudioLanguage2Changed();
        private short? _audioLanguage2;
        public short? AudioLanguage2
        {
            get { return _audioLanguage2; }
            set
            {
                OnAudioLanguage2Changing();
                _audioLanguage2 = value;
                base.HasChanged = true;
                OnAudioLanguage2Changed();
            }
        }

        partial void OnAudioLanguage3Changing();
        partial void OnAudioLanguage3Changed();
        private short? _audioLanguage3;
        public short? AudioLanguage3
        {
            get { return _audioLanguage3; }
            set
            {
                OnAudioLanguage3Changing();
                _audioLanguage3 = value;
                base.HasChanged = true;
                OnAudioLanguage3Changed();
            }
        }

        partial void OnFileSizeChanging();
        partial void OnFileSizeChanged();
        private decimal _fileSize;
        public decimal FileSize
        {
            get { return _fileSize; }
            set
            {
                OnFileSizeChanging();
                _fileSize = value;
                base.HasChanged = true;
                OnFileSizeChanged();
            }
        }

        partial void OnDurationChanging();
        partial void OnDurationChanged();
        private int _duration;
        public int Duration
        {
            get { return _duration; }
            set
            {
                OnDurationChanging();
                _duration = value;
                base.HasChanged = true;
                OnDurationChanged();
            }
        }
    }
}