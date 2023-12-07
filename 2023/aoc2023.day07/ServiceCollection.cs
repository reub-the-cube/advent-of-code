using AoC.Core;
using aoc2023.day07.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2023.day07
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay07Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day07Solver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
