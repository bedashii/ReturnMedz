using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlusPlayDBGenLib.Properties;

namespace PlusPlayDBGenLib.Lists
{
    public partial class GalleriesList : List<Business.Galleries>
    {
        public GalleriesList()
        {

        }

        public void GetByModel(int model)
        {
            _data.LoadByModel(this,model);
        }
    }
}