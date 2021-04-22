using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;

namespace bedste_boligoverblik.storage.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class, ITableEntity, new()
    {
        private readonly string _partitionKey;
        private readonly TableClient _tableClient;

        public Repository(string storageConnection, string partitionKey)
        {
            _partitionKey = partitionKey;
            _tableClient = new TableClient(storageConnection, partitionKey);
        }

        public Response<T> GetByRowKey(string rowKey) => _tableClient.GetEntity<T>(_partitionKey, rowKey);

        public Task<Response<T>> GetByRowKeyAsync(string rowKey) => _tableClient.GetEntityAsync<T>(_partitionKey, rowKey);

        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            var enumerator = _tableClient.Query(filter).GetEnumerator();
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public async IAsyncEnumerable<T> QueryAsync(Expression<Func<T, bool>> filter)
        {
            var enumerator = _tableClient.QueryAsync<T>(filter).GetAsyncEnumerator();
            while (await enumerator.MoveNextAsync())
                yield return enumerator.Current;
        }

        public Response Create(T entity) => _tableClient.AddEntity(entity);

        public Task<Response> CreateAsync(T entity) => _tableClient.AddEntityAsync(entity);

        public Response Update(T entity) => _tableClient.UpdateEntity(entity, ETag.All);

        public Task<Response> UpdateAsync(T entity) => _tableClient.UpdateEntityAsync(entity, ETag.All);

        public Response Delete(string rowKey) => _tableClient.DeleteEntity(_partitionKey, rowKey);

        public Task<Response> DeleteAsync(string rowKey) => _tableClient.DeleteEntityAsync(_partitionKey, rowKey);
    }
}