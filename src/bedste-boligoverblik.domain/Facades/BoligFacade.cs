using System.Threading.Tasks;
using Azure;
using bedste_boligoverblik.storage.Entities;
using bedste_boligoverblik.storage.Repositories;

namespace bedste_boligoverblik.domain.Facades
{
    public class BoligFacade : IBoligFacade
    {
        private readonly IRepository<BoligEntity> _repository;

        public BoligFacade(IRepository<BoligEntity> repository)
        {
            _repository = repository;
        }

        public AsyncPageable<BoligEntity> GetByUserKeyAsync(string userKey) => _repository.QueryAsync(entity => entity.UserKey == userKey);

        public Task<Response<BoligEntity>> GetByRowKeyAsync(string rowKey) => _repository.GetByRowKeyAsync(rowKey);

        public Task<Response> CreateAsync(BoligEntity entity) => _repository.CreateAsync(entity);

        public Task<Response> UpdateAsync(BoligEntity entity) => _repository.UpdateAsync(entity);

        public Task<Response> DeleteAsync(string rowkey) => _repository.DeleteAsync(rowkey);
    }
}