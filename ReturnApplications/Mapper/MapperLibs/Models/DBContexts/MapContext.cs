using System.Data.Entity;

namespace MapperLibs.Models.DBContexts
{
    public class MapContext : DbContext
    {
        public DbSet<Map> Maps { get; set; }
    }
}
