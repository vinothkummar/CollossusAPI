using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Colossus.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Get();

        Task<T> FilterBY(Expression<Func<T, bool>> predicate);

        Task<T> Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        void SaveChanges();

    }
}
