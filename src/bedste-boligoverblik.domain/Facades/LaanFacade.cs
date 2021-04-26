using Azure;
using bedste_boligoverblik.storage.Entities;
using bedste_boligoverblik.storage.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bedste_boligoverblik.domain.Facades
{
    public class LaanFacade : ILaanFacade
    {
        private readonly IRepository<LaanEntity> _repository;

        public LaanFacade(IRepository<LaanEntity> repository)
        {
            _repository = repository;
        }

        public IAsyncEnumerable<LaanEntity> GetByBoligKeyAsync(string boligKey) =>
            _repository.QueryAsync(entity => entity.BoligKey == boligKey);

        public Task<Response<LaanEntity>> GetByRowKeyAsync(string rowKey) => _repository.GetByRowKeyAsync(rowKey);

        public Task<Response> CreateAsync(LaanEntity entity) => _repository.CreateAsync(entity);

        public Task<Response> UpdateAsync(LaanEntity entity) => _repository.UpdateAsync(entity);

        public Task<Response> DeleteAsync(string rowkey) => _repository.DeleteAsync(rowkey);
    }
}