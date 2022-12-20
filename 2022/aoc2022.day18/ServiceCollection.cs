using AoC.Core;
using aoc2022.day18.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day18
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay18Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day18Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
