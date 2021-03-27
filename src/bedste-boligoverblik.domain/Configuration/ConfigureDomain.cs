﻿using bedste_boligoverblik.domain.Facades;
using bedste_boligoverblik.domain.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace bedste_boligoverblik.domain.Configuration
{
    public static class ConfigureDomain
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BeregnMapperProfile));
            services.AddSingleton<IBeregnMapper, BeregnMapper>();

            services.AddSingleton<IBeregnFacade, BeregnFacade>();
        }
    }
}