using Microsoft.EntityFrameworkCore;
using Heroes.Domain.Entities;

namespace Heroes.Infrastructure.Data
{
    public class HeroesDbContext : DbContext
    {
        public HeroesDbContext(DbContextOptions<HeroesDbContext> options)
            : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }
        public DbSet<HeroSuperPower> HeroSuperPowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroSuperPower>()
                .HasKey(hs => new { hs.HeroId, hs.SuperPowerId });
        }
    }
}
