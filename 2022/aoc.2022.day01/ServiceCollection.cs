using AoC.Core;
using aoc._2022.day01.models;
using Microsoft.Extensions.DependencyInjection;

namespace aoc._2022.day01
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
