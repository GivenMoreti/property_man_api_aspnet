using PropertyManApi.Models;

namespace PropertyManApi.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Property> Properties { get; }
        IGenericRepository<Unit> Units { get; }
        Task Save();

    }
}