using System.Threading.Tasks;
using Azure;
using bedste_boligoverblik.storage.Entities;
using bedste_boligoverblik.storage.Repositories;

namespace bedste_boligoverblik.domain.Facades
{
    public class LaanberegningFacade : ILaanberegningFacade
    {
        private readonly IRepository<LaanBeregningEntity> _repository;

        public LaanberegningFacade(IRepository<LaanBeregningEntity> repository)
        {
            _repository = repository;
        }

        public AsyncPageable<LaanBeregningEntity> GetByBoligKeyAsync(string boligKey) => _repository.QueryAsync(entity => entity.BoligKey == boligKey);

        public Task<Response<LaanBeregningEntity>> GetByRowKeyAsync(string rowKey) => _repository.GetByRowKeyAsync(rowKey);

        public Task<Response> CreateAsync(LaanBeregningEntity entity) => _repository.CreateAsync(entity);

        public Task<Response> UpdateAsync(LaanBeregningEntity entity) => _repository.UpdateAsync(entity);

        public Task<Response> DeleteAsync(string rowkey) => _repository.DeleteAsync(rowkey);
    }
}