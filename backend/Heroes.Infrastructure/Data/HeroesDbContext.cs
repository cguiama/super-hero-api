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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HeroSuperPower>()
                .HasKey(hs => new { hs.HeroId, hs.SuperPowerId });

            modelBuilder.Entity<HeroSuperPower>()
                .HasOne(hs => hs.Hero)
                .WithMany(h => h.HeroSuperPowers)
                .HasForeignKey(hs => hs.HeroId);

            modelBuilder.Entity<HeroSuperPower>()
                .HasOne(hs => hs.SuperPower)
                .WithMany(sp => sp.HeroSuperPowers)
                .HasForeignKey(hs => hs.SuperPowerId);
        }
    }
}
