using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlusPlayLib.Bus
{
    public class ModelB : Prop.ModelProperties
    {
        public List.GalleryListB ModelGalleries { get; set; }

        public ModelB()
        {
            ModelGalleries = new List.GalleryListB();
        }
    }
}
