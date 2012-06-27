using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetLib.Lists
{
    public class FormatList : List<Business.Format>
    {
        Data.FormatData _data = new Data.FormatData();

        public void GetAll()
        {
            _data.LoadAll(this);
        }
    }
}
