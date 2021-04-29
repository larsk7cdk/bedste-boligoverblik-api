using bedste_boligoverblik.domain.Facades;
using bedste_boligoverblik.domain.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace bedste_boligoverblik.domain.Configuration
{
    public static class ConfigureDomain
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AdresseMapperProfile), typeof(LaanberegningMapperProfile));
            services.AddSingleton<ILaanberegningMapper, LaanberegningMapper>();

            services.AddSingleton<IAdresseFacade, AdresseFacade>();
            services.AddSingleton<IBoligFacade, BoligFacade>();
            services.AddSingleton<ILaanberegningFacade, LaanberegningFacade>();
            services.AddSingleton<ILaanproduktFacade, LaanproduktFacade>();
            services.AddSingleton<ILaanFacade, LaanFacade>();
        }
    }
}