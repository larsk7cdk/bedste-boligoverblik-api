using bedste_boligoverblik.api.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bedste_boligoverblik.api.Configuration
{
    public static class ConfigureServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureSwaggerServices();

            services.AddAutoMapper(typeof(BeregnMapperProfile));

            services.AddControllers();
        }
    }
}