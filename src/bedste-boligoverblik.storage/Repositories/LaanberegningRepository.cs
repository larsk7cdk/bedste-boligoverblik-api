using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;

namespace bedste_boligoverblik.storage.Repositories
{
    internal class LaanberegningRepository<T> : IRepository<T> where T : class, ITableEntity, new()
    {
        const string PARTITION_KEY = "laanberegning";
        private readonly TableClient _tableClient;

        public LaanberegningRepository(string storageConnection)
        {
            _tableClient = new TableClient(storageConnection, PARTITION_KEY);
        }

        public Response<T> GetByRowKey(string rowKey) => _tableClient.GetEntity<T>(PARTITION_KEY, rowKey);

        public Task<Response<T>> GetByRowKeyAsync(string rowKey) => _tableClient.GetEntityAsync<T>(PARTITION_KEY, rowKey);

        public Pageable<T> Query(Expression<Func<T, bool>> filter) => _tableClient.Query(filter);

        public AsyncPageable<T> QueryAsync(Expression<Func<T, bool>> filter) => _tableClient.QueryAsync(filter);

        public Response Create(T entity) => _tableClient.AddEntity(entity);

        public Task<Response> CreateAsync(T entity) => _tableClient.AddEntityAsync(entity);

        public Response Update(T entity) => _tableClient.UpdateEntity(entity, ETag.All);

        public Task<Response> UpdateAsync(T entity) => _tableClient.UpdateEntityAsync(entity, ETag.All);

        public Response Delete(string rowKey) => _tableClient.DeleteEntity(PARTITION_KEY, rowKey);

        public Task<Response> DeleteAsync(string rowKey) => _tableClient.DeleteEntityAsync(PARTITION_KEY, rowKey);
    }
}