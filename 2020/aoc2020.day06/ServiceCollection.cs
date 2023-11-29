using AoC.Core;
using aoc2020.day06.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2020.day06
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay06Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day06Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
