using bedste_boligoverblik.domain.Facades;
using bedste_boligoverblik.domain.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace bedste_boligoverblik.domain.Configuration
{
    public static class ConfigureDomain
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AdresseMapperProfile), typeof(BeregnMapperProfile));
            services.AddSingleton<IBeregnMapper, BeregnMapper>();

            services.AddSingleton<IAdresseFacade, AdresseFacade>();
            services.AddSingleton<IBoligFacade, BoligFacade>();
            services.AddSingleton<IBeregnFacade, BeregnFacade>();
            services.AddSingleton<ILaanProdukterFacade, LaanProdukterFacade>();
        }
    }
}