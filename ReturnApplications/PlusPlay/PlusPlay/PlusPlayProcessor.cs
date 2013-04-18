using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlusPlayLib;
using PlusPlayLib.Bus;
using PlusPlayLib.List;
using System.IO;

namespace PlusPlay
{
    public class PlusPlayProcessor
    {
        public int ModelCount
        {
            get
            {
                if (_modelList == null)
                    return 0;

                return _modelList.Count;
            }
        }

        DirectoryInfo workingDirectory;
        ModelList _modelList;

        public PlusPlayProcessor()
        {
            _modelList = new ModelList();
            workingDirectory = new DirectoryInfo(System.Configuration.ConfigurationManager.AppSettings.Get("DirectoryPath"));
        }

        public void SetModelList()
        {
            foreach (DirectoryInfo model in workingDirectory.GetDirectories())
                if (!Char.IsNumber(Convert.ToChar(model.Name.Substring(0, 1))))
                {
                    Model newModel = new Model();
                    newModel.ModelName = model.Name;
                    newModel.Location = new DirectoryInfo(model.FullName);

                    SetModelGalleries(newModel);

                    _modelList.Add(newModel);
                }
        }

        private void SetModelGalleries(Model newModel)
        {
            FileInfo[] galleries = newModel.Location.GetFiles();

            if (galleries.Count() > 0)
                foreach (FileInfo galleryFile in galleries)
                {
                    string galleryName = ExtractGalleryName(galleryFile);

                    if (!newModel.ModelGalleries.Exists(x => x.GalleryName == galleryName))
                        newModel.ModelGalleries.Add(new Gallery(galleryName, galleryFile.Directory));

                    newModel.ModelGalleries.Find(x => x.GalleryName == galleryName).Files.Add(galleryFile);
                }
        }

        public static string ExtractGalleryName(FileInfo galleryFile)
        {
            return (ExtractGalleryName(galleryFile.Name));
        }

        public static string ExtractGalleryName(string galleryFileName)
        {
            return galleryFileName.Substring(galleryFileName.IndexOf(" - ") + 3, galleryFileName.IndexOf(" [") - galleryFileName.IndexOf(" - ") - 3);
        }

        internal ModelList GetModelList()
        {
            return _modelList;
        }

        internal GalleryList GetGalleryList(Model Model)
        {
            if (_modelList.Exists(x => x.ModelName == Model.ModelName))
                return _modelList.Find(x => x.ModelName == Model.ModelName).ModelGalleries;

            return null;
        }
    }
}
