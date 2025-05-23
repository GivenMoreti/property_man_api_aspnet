using PropertyManApi.Models;

namespace PropertyManApi.Interfaces
{
    public interface IUnitInterface
    {
        Task<IEnumerable<Unit>> GetAllAsync();
        Task<Unit> GetByIdAsync(int id);
        Task AddAsync(Unit unit);
        Task UpdateAsync(Unit unit);
        Task DeleteAsync(int id);
    }
}