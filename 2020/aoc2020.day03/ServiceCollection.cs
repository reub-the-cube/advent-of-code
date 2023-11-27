using AoC.Core;
using aoc2020.day03.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2020.day03
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay03Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day03Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
