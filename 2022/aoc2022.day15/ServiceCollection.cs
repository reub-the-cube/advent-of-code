using AoC.Core;
using aoc2022.day15.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day15
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay15Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day15Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
