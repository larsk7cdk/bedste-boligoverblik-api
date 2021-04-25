using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using bedste_boligoverblik.storage.Entities;
using bedste_boligoverblik.storage.Repositories;

namespace bedste_boligoverblik.domain.Facades
{
    public class LaanFacade : ILaanFacade
    {
        private readonly IRepository<LaanEntity> _repository;

        public LaanFacade(IRepository<LaanEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<LaanEntity> GetByBoligKeyAsync(string boligKey) =>
            _repository.QueryAsync(entity => entity.BoligKey == boligKey)
                .ToListAsync().Result
                .OrderBy(o => o.Produkt);

        public Task<Response<LaanEntity>> GetByRowKeyAsync(string rowKey) => _repository.GetByRowKeyAsync(rowKey);

        public Task<Response> CreateAsync(LaanEntity entity) => _repository.CreateAsync(entity);

        public Task<Response> UpdateAsync(LaanEntity entity) => _repository.UpdateAsync(entity);

        public Task<Response> DeleteAsync(string rowkey) => _repository.DeleteAsync(rowkey);
    }
}