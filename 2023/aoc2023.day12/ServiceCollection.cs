using AoC.Core;
using aoc2023.day12.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2023.day12
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay12Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day12Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
