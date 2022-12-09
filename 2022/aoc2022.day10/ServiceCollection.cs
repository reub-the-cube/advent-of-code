using AoC.Core;
using aoc2022.day10.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day10
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay10Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day10Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
