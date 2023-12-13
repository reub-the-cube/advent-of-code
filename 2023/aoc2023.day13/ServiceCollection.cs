using AoC.Core;
using aoc2023.day13.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2023.day13
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay13Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day13Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
