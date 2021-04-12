using System.Threading.Tasks;
using Azure;
using bedste_boligoverblik.storage.Entities;

namespace bedste_boligoverblik.domain.Facades
{
    public interface ILaanberegningFacade
    {
        AsyncPageable<LaanberegningEntity> GetByBoligKeyAsync(string userKey);
        Task<Response<LaanberegningEntity>> GetByRowKeyAsync(string rowKey);
        Task<Response> CreateAsync(LaanberegningEntity entity);
        Task<Response> UpdateAsync(LaanberegningEntity entity);
        Task<Response> DeleteAsync(string rowKey);
    }
}