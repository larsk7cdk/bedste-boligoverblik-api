using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

namespace bedste_boligoverblik.api.Configuration
{
    public static class ConfigureAzureB2CExtensions
    {
        public static void ConfigureAzureB2C(this IServiceCollection services, IConfiguration configuration)
        {
            // Adds Microsoft Identity platform (AAD v2.0) support to protect this Api
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(options => { configuration.Bind("AzureAdB2C", options); },
                    options => { configuration.Bind("AzureAdB2C", options); });
        }
    }
}