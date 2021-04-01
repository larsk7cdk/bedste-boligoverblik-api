using System.Threading.Tasks;
using Azure;
using bedste_boligoverblik.storage.Entities;

namespace bedste_boligoverblik.domain.Facades
{
    public interface IBoligFacade
    {
        AsyncPageable<BoligEntity> GetByUserKeyAsync(string userKey);
        Task<Response<BoligEntity>> GetByRowKeyAsync(string rowKey);
        Task<Response> CreateAsync(BoligEntity entity);
        Task<Response> UpdateAsync(BoligEntity entity);
        Task<Response> DeleteAsync(string rowKey);
    }
}