using AoC.Core;
using aoc2022.day21.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day21
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay21Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day21Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
