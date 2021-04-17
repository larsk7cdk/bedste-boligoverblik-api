using bedste_boligoverblik.api.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace bedste_boligoverblik.api.Configuration
{
    public static class ConfigureServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureSwaggerServices();

            services.AddAutoMapper(
                typeof(AdresseMapperProfile),
                typeof(BeregnMapperProfile),
                typeof(BoligMapperProfile),
                typeof(LaanberegningMapperProfile));

            services.AddCors();

            services.AddControllers();
        }
    }
}