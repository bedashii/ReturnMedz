using System.Data.Entity;

namespace MapperLibs.Models.DBContexts
{
    public class MapType : DbContext
    {
        public DbSet<MapType> MapTypes { get; set; }
    }
}