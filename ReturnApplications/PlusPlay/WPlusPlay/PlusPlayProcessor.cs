using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlusPlayLib;
using PlusPlayLib.Bus;
using PlusPlayLib.List;
using System.IO;
using System.Globalization;
using System.Threading;

namespace WPlusPlay
{
    public enum Keyword { Model, Gallery };
    public class PlusPlayProcessor
    {
        #region Variables
        public int ModelCount
        {
            get
            {
                if (_modelList == null)
                    return 0;

                return _modelList.Count;
            }
        }
        DirectoryInfo _workingDirectory;
        ModelListB _modelList;
        #endregion Variables

        #region Construction
        public PlusPlayProcessor()
        {
            _modelList = new ModelListB();
            _workingDirectory = new DirectoryInfo(System.Configuration.ConfigurationManager.AppSettings.Get("DirectoryPath"));
        }
        #endregion Construction

        #region Methods
        private void SetModelList()
        {
            _modelList.Clear();

            foreach (DirectoryInfo model in _workingDirectory.GetDirectories())
                if (!Char.IsNumber(Convert.ToChar(model.Name.Substring(0, 1))))
                {
                    ModelB newModel = new ModelB();
                    newModel.ModelName = model.Name;
                    newModel.Location = new DirectoryInfo(model.FullName);

                    SetModelGalleries(newModel);

                    _modelList.Add(newModel);
                }
        }

        private void SetModelGalleries(ModelB newModel)
        {
            FileInfo[] galleries = newModel.Location.GetFiles();

            if (galleries.Count() > 0)
                foreach (FileInfo galleryFile in galleries)
                {
                    string galleryName = WPlusPlay.PlusPlayTools.StringManipulator.ExtractGalleryName(galleryFile);
                    bool galleryExists = false;

                    foreach (Gallery gallery in newModel.ModelGalleries)
                        if (gallery.GalleryName == galleryName)
                            galleryExists = true;

                    if (!galleryExists)
                        newModel.ModelGalleries.Add(new Gallery(galleryName, galleryFile.Directory));

                    newModel.ModelGalleries.Single(x => x.GalleryName == galleryName).Files.Add(galleryFile);
                }
        }
        #endregion Methods

        #region Static Methods
        public static bool CleanUpTempFiles()
        {
            bool cleanupSuccessful = true;

            DirectoryInfo tempDirectory = new DirectoryInfo("TEMP");
            try
            {
                if (tempDirectory.Exists)
                {
                    DirectoryInfo[] tempDirectories = tempDirectory.GetDirectories();

                    foreach (DirectoryInfo directory in tempDirectories)
                    {
                        FileInfo[] files = directory.GetFiles();

                        try
                        {
                            foreach (FileInfo file in files)
                                File.Delete(file.FullName);

                            Directory.Delete(directory.FullName);
                        }
                        catch (Exception) { cleanupSuccessful = false; }
                    }

                    Directory.Delete(tempDirectory.FullName);
                }
            }
            catch (Exception) { cleanupSuccessful = false; }

            return cleanupSuccessful;
        }
        #endregion Static Methods

        #region ImportGalleryMethods
        private DirectoryInfo ImportGallery_CheckIfModelExists(string modelName)
        {
            DirectoryInfo modelDinfo = new DirectoryInfo(_workingDirectory + @"\" + modelName);

            if (modelDinfo.Exists == false)
                Directory.CreateDirectory(_workingDirectory + @"\" + modelName);

            return modelDinfo;
        }

        private int ImportGallery_CheckIfGalleryExists(DirectoryInfo modelDinfo, string galleryName)
        {
            int nextAvailableNumber = 0;
            FileInfo[] galleryFinfo = modelDinfo.GetFiles("*" + galleryName + "*");

            foreach (FileInfo photo in galleryFinfo)
            {
                int photoNumber = Convert.ToInt32(photo.Name.Substring(photo.Name.IndexOf('[') + 1, 2));

                if (nextAvailableNumber < photoNumber)
                    nextAvailableNumber = photoNumber;
            }

            return nextAvailableNumber + 1;
        }
        #endregion ImportGalleryMethods

        #region PublicMethods
        internal ModelListB GetModelList(bool refresh)
        {
            if (refresh)
                SetModelList();

            return _modelList;
        }

        internal GalleryListB GetGalleryList(ModelB Model)
        {
            foreach (ModelB model in _modelList)
                if (model.ModelName == Model.ModelName)
                    return model.ModelGalleries;

            return null;
        }

        internal GalleryListB GetGalleryList(string Model)
        {
            foreach (ModelB model in _modelList)
                if (model.ModelName == Model)
                    return model.ModelGalleries;

            return null;
        }

        internal void ExtractArchive(string archivePath)
        {
            new PlusPlayTools.ArchiveExtractor().ExtractArchive(archivePath);
        }

        internal void SetGalleryStatus(Gallery gallery, bool posted)
        {
            List<string> filesToDelete = new List<string>();

            foreach (FileInfo file in gallery.Files)
                if (posted)
                {
                    if (file.Name.Contains('}'))
                    {
                        File.Copy(file.FullName, file.FullName.Replace('}', ']'));
                        filesToDelete.Add(file.FullName);
                    }
                }
                else
                {
                    if (file.Name.Contains(']'))
                    {
                        File.Copy(file.FullName, file.FullName.Replace(']', '}'));
                        filesToDelete.Add(file.FullName);
                    }
                }

            foreach (string deleting in filesToDelete)
                File.Delete(deleting);
        }

        /// <summary>
        /// Copies files from TEMP/All folder into gallery folder. Checks whether model and gallery exists before importing.
        /// Also creates appropriate folders if folders do not exists.
        /// </summary>
        /// <param name="selectedItems"></param>
        /// <param name="galleryInfo"></param>
        internal void ImportGallery(List<UIControls.UIPictureBoxDetailsStruct> selectedItems, Dictionary<Keyword, string> galleryInfo)
        {
            try
            {
                DirectoryInfo modelDinfo = ImportGallery_CheckIfModelExists(galleryInfo[Keyword.Model]);
                int startingPosition = ImportGallery_CheckIfGalleryExists(modelDinfo, galleryInfo[Keyword.Gallery]);

                foreach (UIControls.UIPictureBoxDetailsStruct item in selectedItems)
                    File.Move(item.FilePath, modelDinfo.FullName + @"\" + WPlusPlay.PlusPlayTools.StringManipulator.GenerateModelName(galleryInfo[Keyword.Model], galleryInfo[Keyword.Gallery], startingPosition++));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error Importing Gallery: " + ex.Message);
            }
        }
        /// <summary>
        /// Re-reads the gallery from hard drive and checks for an updated filename
        /// (The purpose of this is determine whether or not it's a "posted" gallery or not)
        /// </summary>
        /// <param name="gallery"></param>
        internal void RefreshGallery(Gallery gallery)
        {
            gallery.Files.Clear();
            gallery.Files = gallery.Location.GetFiles("*" + gallery.GalleryName + "*").ToList();
        }
        #endregion PublicMethods
    }
}
