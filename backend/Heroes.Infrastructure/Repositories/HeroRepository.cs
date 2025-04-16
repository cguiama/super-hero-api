using Heroes.Application.Interfaces;
using Heroes.Domain.Entities;
using Heroes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Heroes.Infrastructure.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly HeroesDbContext _context;

        public HeroRepository(HeroesDbContext context)
        {
            _context = context;
        }

        public async Task<Hero?> GetByIdAsync(Guid id)
        {
            return await _context.Heroes
                .Include(h => h.HeroSuperPowers)
                    .ThenInclude(hs => hs.SuperPower)
                .FirstOrDefaultAsync(h => h.Id == id);
        }
        public async Task AddAsync(Hero hero)
        {
            await _context.Heroes.AddAsync(hero);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Heroes.AnyAsync(h => h.Name.ToLower() == name.ToLower());
        }
        public async Task<List<Hero>> GetAllAsync()
        {
            return await _context.Heroes
                .Include(h => h.HeroSuperPowers)
                .ThenInclude(hs => hs.SuperPower)
                .ToListAsync();
        }
    }
}
