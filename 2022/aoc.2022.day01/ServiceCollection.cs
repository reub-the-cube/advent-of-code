using AoC.Core;
using aoc._2022.day01.models;
using Microsoft.Extensions.DependencyInjection;

namespace aoc._2022.day01
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay01Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day01Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
