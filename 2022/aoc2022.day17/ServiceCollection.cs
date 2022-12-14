using AoC.Core;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day17
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay17Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day17Solver>()
                .AddScoped<IParser<string>, Parser>();
        }
    }
}
