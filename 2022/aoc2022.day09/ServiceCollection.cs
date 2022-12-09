using AoC.Core;
using aoc2022.day09.domain;
using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day09
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay09Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day09Solver>()
                .AddScoped<IParser<Instruction[]>, Parser>();
        }
    }
}
