using System.Data.Entity;

namespace Mapper.Models.DBContexts
{
    public class MapContext : DbContext
    {
        public DbSet<Map> Maps { get; set; }
    }
}
