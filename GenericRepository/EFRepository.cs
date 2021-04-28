using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepository
{
    public class EFRepository<TDbContext> : IRepository where TDbContext : DbContext
    {
        protected DbContext dbContext;

        public EFRepository(TDbContext context)
        {
            dbContext = context;
        }

        public async Task<T> CreateAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Add(entity);

            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Remove(entity);

            _ = await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAll<T>() where T : class
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public IQueryable<T> FindAllQueryable<T>() where T : class
        {
            return dbContext.Set<T>().AsQueryable();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> FindById<T>(int id) where T : class
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            dbContext.Set<T>().Update(entity);

            _ = await dbContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            this.dbContext.Set<T>().RemoveRange(entities);

            _ = await dbContext.SaveChangesAsync();
        }

        async Task<IEnumerable<T>> IRepository.FindByConditionNoTrackingAsync<T>(Expression<Func<T, bool>> expression)
        {
            return await dbContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        async Task IRepository.CreateRangeAsync<T>(IEnumerable<T> entities)
        {
            this.dbContext.Set<T>().AddRange(entities);

            _ = await dbContext.SaveChangesAsync();
        }

        async Task IRepository.UpdateRangeAsync<T>(IEnumerable<T> entities)
        {
            dbContext.Set<T>().UpdateRange(entities);

            _ = await dbContext.SaveChangesAsync();
        }
    }
}