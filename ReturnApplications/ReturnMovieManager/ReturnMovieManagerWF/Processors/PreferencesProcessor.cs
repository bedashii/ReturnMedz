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
        private UniversalList UniList;
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
            UniList = new UniversalList();
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

        public void DeleteItem(string whichList, int id)
        {
            whichList = whichList.Replace("Delete", "");
            whichList = whichList.Replace("Button", "");
            UniList.DeleteItem(UniList.UniDictionary[whichList], id);
        }

        public void RefreshAllLists()
        {
            foreach (KeyValuePair<string, object> kvp in UniList.UniDictionary)
                UniList.RefreshList(kvp.Value);
        }
    }

    public class UniversalList
    {
        public Dictionary<string, object> UniDictionary { get; set; }

        public UniversalList()
        {
            UniDictionary = new Dictionary<string, object>();
        }

        internal void DeleteItem(object obj, int id)
        {
            if (obj.GetType() == typeof(AgeRatingTypeList))
                (obj as AgeRatingTypeList).DeleteItem(id);
            else if (obj.GetType() == typeof(AudioQualityTypeList))
                (obj as AudioQualityTypeList).DeleteItem(id);
            else if (obj.GetType() == typeof(ExtensionTypeList))
                (obj as ExtensionTypeList).DeleteItem(id);
            else if (obj.GetType() == typeof(GenreTypesList))
                (obj as GenreTypesList).DeleteItem(id);
            else if (obj.GetType() == typeof(VideoQualityTypeList))
                (obj as VideoQualityTypeList).DeleteItem(id);

            RefreshList(obj);
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
