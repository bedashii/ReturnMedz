using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieLib;
using MovieLib.Business;
using MovieLib.List;

namespace ReturnMovieManagerWF.Processors
{
    public class PreferencesProcessor2
    {
        AgeRatingTypeList _ageRatingList;
        AudioLanguagesList _audioLanguagesList;
        AudioQualityTypeList _audioQualityList;
        ExtensionTypeList _extensionList;
        GenreTypesList _genreList;
        VideoQualityTypeList _videoQualityList;

        public PreferencesProcessor2()
        {
            _ageRatingList = new AgeRatingTypeList();
            _ageRatingList.GetAll();
            _audioLanguagesList = new AudioLanguagesList();
            _audioLanguagesList.GetAll();
            _audioQualityList = new AudioQualityTypeList();
            _audioQualityList.GetAll();
            _extensionList = new ExtensionTypeList();
            _extensionList.GetAll();
            _genreList = new GenreTypesList();
            _genreList.GetAll();
            _videoQualityList = new VideoQualityTypeList();
            _videoQualityList.GetAll();
        }

        public byte GetAgeRatingID(string ageRating)
        {
            try
            {
                if (ageRating == "" || ageRating == null)
                    return _ageRatingList.Find(x => x.AgeRating.ToLower() == "unknown").ID;
                else
                    return _ageRatingList.Find(x => x.AgeRating.Replace("-", "") == ageRating.Replace("_", "")).ID;
            }
            catch (Exception)
            {
                return _ageRatingList.Find(x => x.AgeRating.ToLower() == "unknown").ID;
            }
        }

        public short GetAudioLanguageID(string audioLanguage)
        {
            try
            {
                return _audioLanguagesList.Find(x => x.Description == audioLanguage).ID;
            }
            catch (Exception)
            {
                return _audioLanguagesList.Find(x => x.Description.ToLower() == "unknown").ID;
            }
        }

        public byte GetAudioQualityID(string audioQuality)
        {
            return _audioQualityList.Find(x => x.Description == audioQuality).ID;
        }

        public byte GetExtensionID(string extension)
        {
            return _extensionList.Find(x => x.Extension == extension).ID;
        }

        public short GetGenreID(string genre)
        {
            return _genreList.Find(x => x.Description == genre).ID;
        }

        public byte GetVideoQualityID(int videoHeight)
        {
            if (videoHeight <= 480)
                return _videoQualityList.Find(x => x.Description == "480p").ID;
            else if (videoHeight >= 720 && videoHeight < 1080)
                return _videoQualityList.Find(x => x.Description == "720p").ID;
            else if (videoHeight >= 1080)
                return _videoQualityList.Find(x => x.Description == "1080p").ID;
            else
                return _videoQualityList.Find(x => x.Description == "UNKNOWN").ID;
        }
    }
}
