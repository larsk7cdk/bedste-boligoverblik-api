using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using bedste_boligoverblik.domain.Models;
using bedste_boligoverblik.storage.Entities;
using bedste_boligoverblik.storage.Repositories;

namespace bedste_boligoverblik.domain.Facades
{
    public class BoligFacade : IBoligFacade
    {
        private readonly IAdresseFacade _adresseFacade;
        private readonly IRepository<BoligEntity> _repository;

        public BoligFacade(IAdresseFacade adresseFacade, IRepository<BoligEntity> repository)
        {
            _adresseFacade = adresseFacade;
            _repository = repository;
        }

        public IEnumerable<BoligEntity> GetByUserKeyAsync(string userKey) =>
            _repository.QueryAsync(entity => entity.UserKey == userKey).ToListAsync().Result.OrderBy(o => o.Adresse);

        public Task<Response<BoligEntity>> GetByRowKeyAsync(string rowKey) => _repository.GetByRowKeyAsync(rowKey);

        public async Task<Response> CreateAsync(BoligEntity entity)
        {
            var adresseQuery = new AdresseQuery()
            {
                Vejnavn = entity.Vejnavn,
                Husnr = entity.Husnummer,
                Postnr = entity.Postnummer
            };

            var adresse = await _adresseFacade.Soeg(adresseQuery);

            if (adresse != null)
            {
                entity.X = adresse.X;
                entity.Y = adresse.Y;
                entity.Adresse = adresse.Betegnelse;
            }
            else
            {
                entity.Adresse = $"{entity.Vejnavn} {entity.Husnummer}, {entity.Postnummer}";
            }

            return await _repository.CreateAsync(entity);
        }

        public Task<Response> UpdateAsync(BoligEntity entity) => _repository.UpdateAsync(entity);

        public Task<Response> DeleteAsync(string rowkey) => _repository.DeleteAsync(rowkey);
    }
}