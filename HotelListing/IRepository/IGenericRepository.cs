using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelListing.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll(
            Expression<Func<T,bool>> expression=null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            List<string> includes=null
            );
        Task<T> Get(
            Expression<Func<T, bool>> expression = null,
            List<string> includes = null
            );
        Task Insert(T entity);
        void Update(T entity);
        Task Delete(int id);
        Task InsertRange(IEnumerable<T> entities);
        void DeleteRange(IEnumerable<T> entities);

    }
}
