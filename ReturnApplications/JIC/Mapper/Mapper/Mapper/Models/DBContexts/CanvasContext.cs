using System.Data.Entity;

namespace Mapper.Models.DBContexts
{
    public class CanvasContext : DbContext
    {
        public DbSet<CanvasContext> CanvasContexts { get; set; }

        public System.Data.Entity.DbSet<Mapper.Models.Canvas> Canvas { get; set; }
    }
}
