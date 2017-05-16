using System.Data.Entity;

namespace MapperLibs.Models.DBContexts
{
    public class ImageCanvasContext : DbContext
    {
        public DbSet<ImageCanvas> ImageCanvases { get; set; }
    }
}
