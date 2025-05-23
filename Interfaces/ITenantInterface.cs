using PropertyManApi.Models;

namespace PropertyManApi.Interfaces
{
    public interface ITenantInterface
    {
        Task<IEnumerable<Tenant>> GetAllAsync();
        Task<Tenant> GetByIdAsync(int id);
        Task AddAsync(Tenant tenant);
        Task UpdateAsync(Tenant tenant);
        Task DeleteAsync(int id);
    }
}