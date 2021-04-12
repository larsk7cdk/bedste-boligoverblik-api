using System.Threading.Tasks;
using Azure;
using bedste_boligoverblik.storage.Entities;
using bedste_boligoverblik.storage.Repositories;

namespace bedste_boligoverblik.domain.Facades
{
    public class LaanberegningFacade : ILaanberegningFacade
    {
        private readonly IRepository<LaanberegningEntity> _repository;

        public LaanberegningFacade(IRepository<LaanberegningEntity> repository)
        {
            _repository = repository;
        }

        public AsyncPageable<LaanberegningEntity> GetByBoligKeyAsync(string boligKey) => _repository.QueryAsync(entity => entity.BoligKey == boligKey);

        public Task<Response<LaanberegningEntity>> GetByRowKeyAsync(string rowKey) => _repository.GetByRowKeyAsync(rowKey);

        public Task<Response> CreateAsync(LaanberegningEntity entity) => _repository.CreateAsync(entity);

        public Task<Response> UpdateAsync(LaanberegningEntity entity) => _repository.UpdateAsync(entity);

        public Task<Response> DeleteAsync(string rowkey) => _repository.DeleteAsync(rowkey);
    }
}