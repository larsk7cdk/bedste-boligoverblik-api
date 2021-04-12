using bedste_boligoverblik.storage.Entities;
using bedste_boligoverblik.storage.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bedste_boligoverblik.storage.Configuration
{
    public static class ConfigureStorage
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var storageConnection = configuration.GetConnectionString("storageConnection");

            services.AddSingleton<IRepository<BoligEntity>>(_ => new Repository<BoligEntity>(storageConnection, "bolig"));
            services.AddSingleton<IRepository<LaanberegningEntity>>(_ => new Repository<LaanberegningEntity>(storageConnection, "laanberegning"));
            
        }
    }
}