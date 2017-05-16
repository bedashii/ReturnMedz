using System.Data.Entity;

namespace Mapper.Models.DBContexts
{
    public class ImageContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
    }
}