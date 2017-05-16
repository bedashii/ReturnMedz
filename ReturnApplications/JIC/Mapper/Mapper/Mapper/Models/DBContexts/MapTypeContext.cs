using System.Data.Entity;

namespace Mapper.Models.DBContexts
{
    public class MapType : DbContext
    {
        public DbSet<MapType> MapTypes { get; set; }
    }
}