using HotelListing.Data;
using HotelListing.IRepository;
using System;
using System.Threading.Tasks;

namespace HotelListing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotel;

        public UnitOfWork(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_databaseContext);

        public IGenericRepository<Hotel> Hotels => _hotel ??= new GenericRepository<Hotel>(_databaseContext);

        public void Dispose()
        {
            _databaseContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
