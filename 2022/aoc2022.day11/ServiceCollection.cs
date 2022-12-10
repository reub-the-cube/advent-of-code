using AoC.Core;
using aoc2022.day11.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day11
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay11Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day11Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
