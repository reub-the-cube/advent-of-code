using AoC.Core;
using aoc2022.day19.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day19
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay19Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day19Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
