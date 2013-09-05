using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PlusPlayDBGenLib;
using PlusPlayDBGenLib.Business;
using PlusPlayDBGenLib.Lists;

namespace PlusPlayWF.Processors
{
    public class MainProcessor
    {
        private string _initialDirectory = null;
        public string InitialDirectory
        {
            get
            {
                if (_initialDirectory == null)
                    _initialDirectory = System.Configuration.ConfigurationManager.AppSettings.Get("DirectoryPath");

                return _initialDirectory;
            }
        }

        internal ModelsList ModelsList;

        public MainProcessor()
        {
            ModelsList = new ModelsList();
        }

        public void LoadModels()
        {
            ModelsList.GetAll();
        }

        internal Models AddModel(string selectedPath)
        {
            var di = new DirectoryInfo(selectedPath);
            var model = new Models();
            model.ModelName = di.Name;
            model.ModelDirectory = di.FullName;
            ModelsList.Add(model);
            ModelsList.UpdateAll();
            return model;
        }
    }
}
