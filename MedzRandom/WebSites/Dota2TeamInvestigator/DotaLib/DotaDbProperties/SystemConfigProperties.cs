using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DotaDbGenLib.Properties;

namespace DotaDbGenLib.Properties
{
    public partial class SystemConfigProperties : PropertiesBase
    {
        public SystemConfigProperties()
        {
            // Defaults to IsActive = true.
            IsActive = true;
        }
    }
}
