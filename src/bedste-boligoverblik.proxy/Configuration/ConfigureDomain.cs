using bedste_boligoverblik.proxy.Proxies;
using Microsoft.Extensions.DependencyInjection;

namespace bedste_boligoverblik.proxy.Configuration
{
    public static class ConfigureProxy
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IJyskeBankProxy, JyskeBankProxy>();
        }
    }
}