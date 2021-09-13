using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepository
{
    public interface IRepository
    {
        Task<IEnumerable<T>> FindAll<T>() where T : class;

        IQueryable<T> FindAllQueryable<T>() where T : class;

        Task<IEnumerable<T>> FindByConditionAsync<T>(Expression<Func<T, bool>> expression) where T : class;

        Task<IEnumerable<T>> FindByConditionNoTrackingAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<T> FindById<T>(int id) where T : class;
        Task<T> FindById<T>(Int64 id) where T : class;
        Task<T> FindById<T>(string id) where T : class;
        Task<T> FindById<T>(Guid id) where T : class;
        Task<T> FindByIAsdNoTrackingAsync<T>(int id) where T : class;
        Task<T> FindByIAsdNoTrackingAsync<T>(Int64 id) where T : class;
        Task<T> FindByIAsdNoTrackingAsync<T>(string id) where T : class;
        Task<T> FindByIAsdNoTrackingAsync<T>(Guid id) where T : class;
        Task<T> CreateAsync<T>(T entity) where T : class;
        Task CreateRangeAsync<T>(IEnumerable<T> entities) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
        Task DeleteRangeAsync<T>(IEnumerable<T> entities) where T : class;
    }
}