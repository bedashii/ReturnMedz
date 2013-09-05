using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlusPlayDBGenLib.Business;
using PlusPlayDBGenLib.Lists;


namespace PlusPlayProcessors
{
    public class ModelViewerProcessor
    {
        public Models CurrentModel;
        public GalleriesList ModelGalleries;

        public ModelViewerProcessor(Models model)
        {
            CurrentModel = model;

            ModelGalleries = new GalleriesList();
            ModelGalleries.GetByModel(model.ID);
        }

        public void UpdateModelCoverPhoto(string filepath)
        {
            CurrentModel.CoverPhoto = filepath;
            CurrentModel.Update();
        }
    }
}
