using AoC.Core;
using aoc2021.day05.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2021.day05
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay05Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day05Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
