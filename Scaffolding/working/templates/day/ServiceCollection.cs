﻿using AoC.Core;
using day.models;
using Microsoft.Extensions.DependencyInjection;

namespace day
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDayXServices(this IServiceCollection services)
        {
            return services
                .AddScoped<DayX>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}