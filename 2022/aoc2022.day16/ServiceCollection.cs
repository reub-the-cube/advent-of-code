using AoC.Core;
using aoc2022.day16.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day16
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay16Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day16Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
