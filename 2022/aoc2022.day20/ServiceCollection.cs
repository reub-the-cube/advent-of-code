using AoC.Core;
using aoc2022.day20.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day20
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay20Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day20Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
