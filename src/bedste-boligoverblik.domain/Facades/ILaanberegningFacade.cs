using System.Threading.Tasks;
using Azure;
using bedste_boligoverblik.storage.Entities;

namespace bedste_boligoverblik.domain.Facades
{
    public interface ILaanberegningFacade
    {
        AsyncPageable<LaanBeregningEntity> GetByBoligKeyAsync(string userKey);
        Task<Response<LaanBeregningEntity>> GetByRowKeyAsync(string rowKey);
        Task<Response> CreateAsync(LaanBeregningEntity entity);
        Task<Response> UpdateAsync(LaanBeregningEntity entity);
        Task<Response> DeleteAsync(string rowKey);
    }
}