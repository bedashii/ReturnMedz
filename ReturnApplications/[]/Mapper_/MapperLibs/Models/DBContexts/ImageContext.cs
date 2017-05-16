using System.Data.Entity;

namespace MapperLibs.Models.DBContexts
{
    public class ImageContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
    }
}