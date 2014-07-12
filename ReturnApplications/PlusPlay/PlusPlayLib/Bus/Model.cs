using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusPlayLib.Bus
{
    public class Model : Prop.ModelProperties
    {
        public List.GalleryList ModelGalleries { get; set; }
        
        public Model()
        {
            ModelGalleries = new List.GalleryList();
        }
    }
}
