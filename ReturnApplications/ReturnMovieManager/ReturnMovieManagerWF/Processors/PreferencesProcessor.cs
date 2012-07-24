using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieLib;
using MovieLib.Business;
using MovieLib.List;

namespace ReturnMovieManagerWF.Processors
{
    public class PreferencesProcessor
    {
        private UniList UniList;
        public AgeRatingTypeList AgeRatingTypeList;
        public AudioQualityTypeList AudioQualityTypeList;
        public ExtensionTypeList ExtensionTypeList;
        public GenreTypesList GenreTypesList;
        public VideoQualityTypeList VideoQualityTypeList;

        public PreferencesProcessor()
        {
            AgeRatingTypeList = new AgeRatingTypeList();
            AudioQualityTypeList = new AudioQualityTypeList();
            ExtensionTypeList = new ExtensionTypeList();
            GenreTypesList = new GenreTypesList();
            VideoQualityTypeList = new VideoQualityTypeList();
            SetDictionary();
        }

        private void SetDictionary()
        {
            UniList = new UniList();
            UniList.UniDictionary.Add("AgeRating", AgeRatingTypeList);
            UniList.UniDictionary.Add("AudioQuality", AudioQualityTypeList);
            UniList.UniDictionary.Add("Extension", ExtensionTypeList);
            UniList.UniDictionary.Add("Genre", GenreTypesList);
            UniList.UniDictionary.Add("VideoQuality", VideoQualityTypeList);
        }

        public void UpdateLists(string whichList)
        {
            whichList = whichList.Replace("Save", "");
            whichList = whichList.Replace("Button", "");
            UniList.UpdateList(UniList.UniDictionary[whichList]);
        }

        #region GetListMethods

        public void RefreshAllLists()
        {
            foreach (KeyValuePair<string, object> kvp in UniList.UniDictionary)
                UniList.RefreshList(kvp.Value);
        }

        public void RefreshAgeRatingTypeList()
        {
            if (AgeRatingTypeList.Count == 0)
                AgeRatingTypeList.GetAll();
            else
                AudioQualityTypeList.Refresh();
        }

        public void RefreshAudioQualityList()
        {
            if (AudioQualityTypeList.Count == 0)
                AudioQualityTypeList.GetAll();
            else
                AudioQualityTypeList.Refresh();
        }

        public void RefreshExtensionTypeList()
        {
            if (ExtensionTypeList.Count == 0)
                ExtensionTypeList.GetAll();
            else
                ExtensionTypeList.Refresh();
        }

        public void RefreshGenreTypeList()
        {
            if (GenreTypesList.Count == 0)
                GenreTypesList.GetAll();
            else
                GenreTypesList.Refresh();
        }

        public void RefreshVideoTypeList()
        {
            if (VideoQualityTypeList.Count == 0)
                VideoQualityTypeList.GetAll();
            else
                VideoQualityTypeList.Refresh();
        }

        #endregion GetListMethods
    }

    public class UniList
    {
        public Dictionary<string, object> UniDictionary { get; set; }

        public UniList()
        {
            UniDictionary = new Dictionary<string, object>();
        }

        internal void UpdateList(object obj)
        {
            if (obj.GetType() == typeof(AgeRatingTypeList))
                (obj as AgeRatingTypeList).UpdateAll();
            else if (obj.GetType() == typeof(AudioQualityTypeList))
                (obj as AudioQualityTypeList).UpdateAll();
            else if (obj.GetType() == typeof(ExtensionTypeList))
                (obj as ExtensionTypeList).UpdateAll();
            else if (obj.GetType() == typeof(GenreTypesList))
                (obj as GenreTypesList).UpdateAll();
            else if (obj.GetType() == typeof(VideoQualityTypeList))
                (obj as VideoQualityTypeList).UpdateAll();
        }

        internal void RefreshList(object obj)
        {
            if (obj.GetType() == typeof(AgeRatingTypeList))
            {
                AgeRatingTypeList x = (AgeRatingTypeList)obj;
                if (x.Count > 0)
                    x.Refresh();
                else
                    x.GetAll();
            }
            else if (obj.GetType() == typeof(AudioQualityTypeList))
            {
                AudioQualityTypeList x = (AudioQualityTypeList)obj;
                if (x.Count > 0)
                    x.Refresh();
                else
                    x.GetAll();
            }
            else if (obj.GetType() == typeof(ExtensionTypeList))
            {
                ExtensionTypeList x = (ExtensionTypeList)obj;
                if (x.Count > 0)
                    x.Refresh();
                else
                    x.GetAll();
            }
            else if (obj.GetType() == typeof(GenreTypesList))
            {
                GenreTypesList x = (GenreTypesList)obj;
                if (x.Count > 0)
                    x.Refresh();
                else
                    x.GetAll();
            }
            else if (obj.GetType() == typeof(VideoQualityTypeList))
            {
                VideoQualityTypeList x = (VideoQualityTypeList)obj;
                if (x.Count > 0)
                    x.Refresh();
                else
                    x.GetAll();
            }
        }
    }
}
