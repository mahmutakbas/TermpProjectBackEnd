using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class TermProjectDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseNpgsql("User ID=term@termproject34;Password=159753+J*;Server=termproject34.postgres.database.azure.com;Port=5432;Database=termproject;Pooling=true;Ssl Mode=Require;", x => x.UseNetTopologySuite());
            
            optionsBuilder.UseNpgsql("User ID=postgres;Password=12345;Server=localhost;Port=5432;Database=Term;Integrated Security=true;Pooling=true;", x => x.UseNetTopologySuite());

           
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("postgis");
            modelBuilder.Entity<RouteOfUser>().Property(b => b.firstpoint).HasColumnType("geography (point,4326)");
            modelBuilder.Entity<RouteOfUser>().Property(b => b.lastpoint).HasColumnType("geography (point,4326)");
        }
        public DbSet<RouteOfUser> RouteOfUsers { get; set; }
        public DbSet<RouteOfUserDetail> RouteOfUserDetails { get; set; }
        public DbSet<UserofFriend> UserofFriends { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
