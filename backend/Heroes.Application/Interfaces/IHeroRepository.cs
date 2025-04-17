using Heroes.Domain.Entities;

namespace Heroes.Application.Interfaces
{
    public interface IHeroRepository
    {
        Task<Hero?> GetByIdAsync(Guid id);
        Task AddAsync(Hero hero);
        Task<bool> ExistsByNameAsync(string name);
        Task<List<Hero>> GetAllAsync();
        Task UpdateAsync(Hero hero);
        Task<Hero?> GetByNameAsync(string name);
        Task DeleteAsync(Hero hero);


    }
}
