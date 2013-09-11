using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotaDbGenLib.Properties;

namespace DotaDbGenLib.Lists
{
    public partial class SpecialRequestsList : List<Business.SpecialRequests>
    {
        public SpecialRequestsList()
        {

        }

        public void GetSpecialRequest()
        {
            _data.GetSpecialRequest(this);
        }
    }
}