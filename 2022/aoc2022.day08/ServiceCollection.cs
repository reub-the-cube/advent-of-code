using AoC.Core;
using aoc2022.day08.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day08
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay08Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day08Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
