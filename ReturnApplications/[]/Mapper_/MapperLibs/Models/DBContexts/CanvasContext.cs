using System.Data.Entity;

namespace MapperLibs.Models.DBContexts
{
    public class CanvasContext : DbContext
    {
        public DbSet<CanvasContext> CanvasContexts { get; set; }
    }
}
