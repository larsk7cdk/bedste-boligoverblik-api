using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;

namespace bedste_boligoverblik.storage.Repositories
{
    public interface IRepository<T> where T : class, ITableEntity, new()
    {
        Response<T> GetByRowKey(string rowKey);
        Task<Response<T>> GetByRowKeyAsync(string rowKey);

        IEnumerable<T> Query(Expression<Func<T, bool>> filter);
        IAsyncEnumerable<T> QueryAsync(Expression<Func<T, bool>> filter);

        Response Create(T entity);
        Task<Response> CreateAsync(T entity);

        Response Update(T entity);
        Task<Response> UpdateAsync(T entity);

        Response Delete(string rowKey);
        Task<Response> DeleteAsync(string rowKey);
    }
}