using PropertyManApi.DBContext;
using PropertyManApi.IRepository;
using PropertyManApi.Models;

namespace PropertyManApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //dependency injection 
        private readonly AppDbContext _context;
        // add all the instances of classes/models
        private IGenericRepository<Property> _properties;
        private IGenericRepository<Unit> _units;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Property> Properties => _properties ??= new GenericRepository<Property>(_context);
        public IGenericRepository<Unit> Units => _units ??= new GenericRepository<Unit>(_context);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }

}