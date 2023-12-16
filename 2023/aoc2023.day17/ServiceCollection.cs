using AoC.Core;
using aoc2023.day17.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2023.day17
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay17Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day17Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
