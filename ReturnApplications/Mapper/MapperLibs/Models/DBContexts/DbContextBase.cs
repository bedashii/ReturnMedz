using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibs.Models.DBContexts
{
    public interface IDBContext
    {
        DbContext Context { get; set; }
    }
}
