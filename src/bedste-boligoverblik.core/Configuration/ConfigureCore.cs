using bedste_boligoverblik.core.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace bedste_boligoverblik.core.Configuration
{
    public static class ConfigureCore
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddSingleton<IHttpClientHelper, HttpClientHelper>();
        }
    }
}