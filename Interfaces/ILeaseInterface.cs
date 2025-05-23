using PropertyManApi.Models;

namespace PropertyManApi.Interfaces
{
    public interface ILeaseInterface
    {
        Task<IEnumerable<Lease>> GetAllAsync();
        Task<Lease> GetByIdAsync(int id);
        Task AddAsync(Lease lease);
        Task UpdateAsync(Lease lease);
        Task DeleteAsync(int id);
    }

}