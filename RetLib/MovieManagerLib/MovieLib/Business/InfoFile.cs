using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MovieLib.Business
{
    public partial class InfoFile : Data.InfoFileData
    {

        public InfoFile()
        {
        }

        public InfoFile(int id)
        {
            PreConstructionTasks();
            this.LoadItemData(id);
            PostConstructionTasks();
        }

        public void LoadItem(int id)
        {
            this.ID = id;
            base.LoadItemData(id);
        }

        public void Refresh(int id)
        {
            base.LoadItemData(id);
        }

        public void SetProperties(MovieLib.Business.InfoFile properties)
        {
            this.ID = properties.ID;
            this.FileName = properties.FileName;
            this.FullFileName = properties.FullFileName;
            this.Extension = properties.Extension;
            this.AudioLanguage1 = properties.AudioLanguage1;
            this.AudioLanguage2 = properties.AudioLanguage2;
            this.AudioLanguage3 = properties.AudioLanguage3;
            this.FileSize = properties.FileSize;
            this.Duration = properties.Duration;
        }

        internal virtual void PreConstructionTasks()
        {
        }

        internal virtual void PostConstructionTasks()
        {
        }

        #region ExtendedProperties

        //private MovieLib.Business.ExtensionType _extensionTypeMember;
        //public MovieLib.Business.ExtensionType ExtensionTypeMember
        //{
        //    get
        //    {
        //        if (_extensionTypeMember == null)
        //            _extensionTypeMember = new ExtensionType(this.Extension);

        //        return _extensionTypeMember;
        //    }
        //}



        //private List<string> _audioLanguageNames;
        //public List<string> AudioLanguageNames
        //{
        //    get
        //    {
        //        if (_audioLanguageNames != null)
        //            SetAudioLanguageNames();

        //        return _audioLanguageNames;
        //    }
        //}

        //private string _audioLanguage1Name;
        //public string AudioLanguage1Name
        //{
        //    get
        //    {
        //        if (_audioLanguage1Name == null)
        //            SetAudioLanguageNames();

        //        return _audioLanguage1Name;
        //    }
        //}

        //private string _audioLanguage2Name;
        //public string AudioLanguage2Name
        //{
        //    get
        //    {
        //        if (_audioLanguage2Name == null)
        //            SetAudioLanguageNames();

        //        return _audioLanguage2Name;
        //    }
        //}

        //private string _audioLanguage3Name;
        //public string AudioLanguage3Name 
        //{
        //    get
        //    {
        //        if (_audioLanguage3Name == null)
        //            SetAudioLanguageNames();

        //        return _audioLanguage3Name;
        //    }
        //}


        //private void SetAudioLanguageNames()
        //{
        //    MovieLib.List.AudioLanguagesList list = new List.AudioLanguagesList();
        //    list.GetAll();

        //    if (this.AudioLanguage1 != null)
        //    {
        //        _audioLanguage1Name = list.Find(x => x.ID == this.AudioLanguage1).Description;
        //        _audioLanguageNames.Add(_audioLanguage1Name);
        //    }

        //    if (this.AudioLanguage2 != null)
        //    {
        //        _audioLanguage2Name = list.Find(x => x.ID == this.AudioLanguage2).Description;
        //        _audioLanguageNames.Add(_audioLanguage2Name);
        //    }

        //    if (this.AudioLanguage3 != null)
        //    {
        //        _audioLanguage3Name = list.Find(x => x.ID == this.AudioLanguage3).Description;
        //        _audioLanguageNames.Add(_audioLanguage3Name);
        //    }
        //}

        #endregion ExtendedProperties
    }
}