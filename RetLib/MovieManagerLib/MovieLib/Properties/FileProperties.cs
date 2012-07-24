using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MovieLib.Properties
{
    public partial class FileProperties : PropertiesBase
    {

        public FileProperties()
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

        partial void OnNameChanging();
        partial void OnNameChanged();
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                OnNameChanging();
                _name = value;
                base.HasChanged = true;
                OnNameChanged();
            }
        }

        partial void OnSizeChanging();
        partial void OnSizeChanged();
        private decimal _size;
        public decimal Size
        {
            get { return _size; }
            set
            {
                OnSizeChanging();
                _size = value;
                base.HasChanged = true;
                OnSizeChanged();
            }
        }

        partial void OnExtensionIDChanging();
        partial void OnExtensionIDChanged();
        private short _extensionID;
        public short ExtensionID
        {
            get { return _extensionID; }
            set
            {
                OnExtensionIDChanging();
                _extensionID = value;
                base.HasChanged = true;
                OnExtensionIDChanged();
            }
        }

        partial void OnVideoQualityChanging();
        partial void OnVideoQualityChanged();
        private byte? _videoQuality;
        public byte? VideoQuality
        {
            get { return _videoQuality; }
            set
            {
                OnVideoQualityChanging();
                _videoQuality = value;
                base.HasChanged = true;
                OnVideoQualityChanged();
            }
        }

        partial void OnAudioQualityChanging();
        partial void OnAudioQualityChanged();
        private byte _audioQuality;
        public byte AudioQuality
        {
            get { return _audioQuality; }
            set
            {
                OnAudioQualityChanging();
                _audioQuality = value;
                base.HasChanged = true;
                OnAudioQualityChanged();
            }
        }
    }
}