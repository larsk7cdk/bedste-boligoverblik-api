using bedste_boligoverblik.api.Configuration;
using bedste_boligoverblik.core.Configuration;
using bedste_boligoverblik.domain.Configuration;
using bedste_boligoverblik.proxy.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bedste_boligoverblik.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCore.Configure(services);
            ConfigureDomain.Configure(services);
            ConfigureProxy.Configure(services);

            services.ConfigureServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureApp(env);
        }
    }
}