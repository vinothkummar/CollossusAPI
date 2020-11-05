using Colossus.Data;
using Colossus.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Colossus.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public GenericRepository(DataContext dataContext) => _dataContext = dataContext;

        public async Task<T> Create(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task Delete(T entity)
        {
            if (entity != null)
            {
                _dataContext.Set<T>().Remove(entity);
                await _dataContext.SaveChangesAsync().ConfigureAwait(false);
            }

        }

        public async Task<T> FilterBY(Expression<Func<T, bool>> predicate)
        {
            return await _dataContext.Set<T>().Where(predicate).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public IQueryable<T> Get()
        {
            return _dataContext.Set<T>();
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public async Task Update(T entity)
        {

            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.Set<T>().Update(entity);
            await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
