using bedste_boligoverblik.api.Configuration;
using bedste_boligoverblik.core.Configuration;
using bedste_boligoverblik.domain.Configuration;
using bedste_boligoverblik.proxy.Configuration;
using bedste_boligoverblik.storage.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

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
            // Adds Microsoft Identity platform (AAD v2.0) support to protect this Api
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(options =>
                    {
                        Configuration.Bind("AzureAdB2C", options);
                        
                        options.TokenValidationParameters.NameClaimType = "name";
                    },
                    options => { Configuration.Bind("AzureAdB2C", options); });

            ConfigureCore.Configure(services);
            ConfigureStorage.Configure(services, Configuration);
            ConfigureDomain.Configure(services);
            ConfigureProxy.Configure(services);

            services.ConfigureServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureApp(env);
        }
    }
}