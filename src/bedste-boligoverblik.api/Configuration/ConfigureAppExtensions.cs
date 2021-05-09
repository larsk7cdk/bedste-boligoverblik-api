using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace bedste_boligoverblik.api.Configuration
{
    public static class ConfigureAppExtensions
    {
        public static void ConfigureApp(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cultureInfo = new CultureInfo("da-DK");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.ConfigureSwaggerApp();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseCors(options =>
            {
                options.WithOrigins("https://bedste-boligoverblik.azurewebsites.net", "http://localhost:4200");
                options.WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS");
                options.AllowCredentials();
                options.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
