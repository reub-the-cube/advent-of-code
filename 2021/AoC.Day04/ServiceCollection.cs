using AoC.Core;
using aoc.day04.models;
using Microsoft.Extensions.DependencyInjection;

namespace aoc.day04
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay4Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day4>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
