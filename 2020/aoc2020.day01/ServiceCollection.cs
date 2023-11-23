using AoC.Core;
using aoc2020.day01.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2020.day01
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay01Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day01Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
