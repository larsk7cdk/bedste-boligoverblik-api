using bedste_boligoverblik.api.Mappers;
using Microsoft.Extensions.DependencyInjection;
using AdresseMapperProfile = bedste_boligoverblik.api.Mappers.AdresseMapperProfile;
using LaanberegningMapperProfile = bedste_boligoverblik.domain.Mappers.LaanberegningMapperProfile;

namespace bedste_boligoverblik.api.Configuration
{
    public static class ConfigureServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureSwaggerServices();

            services.AddAutoMapper(
                typeof(AdresseMapperProfile),
                typeof(LaanberegningMapperProfile),
                typeof(BoligMapperProfile),
                typeof(LaanMapperProfile));

            services.AddCors();

            services.AddControllers();
        }
    }
}