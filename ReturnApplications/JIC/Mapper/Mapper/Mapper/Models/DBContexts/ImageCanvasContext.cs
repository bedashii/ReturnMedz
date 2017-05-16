using System.Data.Entity;

namespace Mapper.Models.DBContexts
{
    public class ImageCanvasContext : DbContext
    {
        public DbSet<ImageCanvas> ImageCanvases { get; set; }
    }
}
