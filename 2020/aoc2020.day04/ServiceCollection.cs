using AoC.Core;
using aoc2020.day04.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2020.day04
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay04Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day04Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
