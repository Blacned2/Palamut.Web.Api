using Microsoft.EntityFrameworkCore;
using MyWebApi.Model;

namespace MyWebApi.Context
{
    public class PalamutContext : DbContext
    {
        public PalamutContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Satici> Saticilar { get; set; }
        public DbSet<Alici> Alicilar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        
    }
}
