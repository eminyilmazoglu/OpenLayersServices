using Microsoft.EntityFrameworkCore;
using OpenLayersServices.Model;

namespace OpenLayersServices.MyDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<Point> Points { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Coordinates)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Coordinate>()
                .HasMany(c => c.Points)
                .WithOne(p => p.Coordinate)
                .HasForeignKey(p => p.CoordinateId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
