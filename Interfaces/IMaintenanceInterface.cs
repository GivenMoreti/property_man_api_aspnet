using PropertyManApi.Models;

namespace PropertyManApi.Interfaces
{
    public interface IMaintenanceInterface
    {
        Task<IEnumerable<MaintenanceRequest>> GetAllAsync();
        Task<MaintenanceRequest> GetByIdAsync(int id);
        Task AddAsync(MaintenanceRequest maintenanceRequest);
        Task UpdateAsync(MaintenanceRequest maintenanceRequesty);
        Task DeleteAsync(int id);
    }

}