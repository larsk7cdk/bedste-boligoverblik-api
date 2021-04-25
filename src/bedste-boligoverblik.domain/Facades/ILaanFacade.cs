using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using bedste_boligoverblik.storage.Entities;

namespace bedste_boligoverblik.domain.Facades
{
    public interface ILaanFacade
    {
        IEnumerable<LaanEntity> GetByBoligKeyAsync(string boligKey);
        Task<Response<LaanEntity>> GetByRowKeyAsync(string rowKey);
        Task<Response> CreateAsync(LaanEntity entity);
        Task<Response> UpdateAsync(LaanEntity entity);
        Task<Response> DeleteAsync(string rowKey);
    }
}