using AoC.Core;
using aoc2023.day14.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2023.day14
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay14Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day14Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
