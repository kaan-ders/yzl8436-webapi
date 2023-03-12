using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entity;

namespace WebApi
{
    public class YemekContext : DbContext
    {
        public YemekContext(DbContextOptions<YemekContext> options)
            : base(options)
        {
        }

        public DbSet<Yemek> Yemek { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Restoran> Restoran { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Yemek>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Kategori>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Restoran>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        }
    }
}
