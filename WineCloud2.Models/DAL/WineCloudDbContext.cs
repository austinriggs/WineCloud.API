using Microsoft.EntityFrameworkCore;

namespace WineCloud2.Models.DAL
{
    public class WineCloudDbContext : DbContext
    {
        public WineCloudDbContext(DbContextOptions<WineCloudDbContext> options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<CellarUser> CellarUsers { get; set; }
        public DbSet<BottleType> BottleTypes { get; set; }
        public DbSet<Bottle> Bottles { get; set; }
        public DbSet<Cellar> Cellars { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<RackRow> RackRows { get; set; }
        public DbSet<RackColumn> RackColumns { get; set; }
    }
}
