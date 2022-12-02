using AoC.Core;
using aoc._2022.day02.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc._2022.day02
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay02Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day02Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
