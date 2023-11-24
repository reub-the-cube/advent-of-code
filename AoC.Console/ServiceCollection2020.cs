using AoC.Core;
using aoc2020.day01;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Console
{
    public static class ServiceCollection2020
    {
        public static IServiceCollection Configure2020Services(this IServiceCollection services)
        {
            return services
                .ConfigureDay01Services();
        }

        public static IDaySolver ResolveDayFor2020(this IServiceProvider serviceProvider, int day)
        {
            return day switch
            {
                1 => serviceProvider.GetService<Day01Solver>() ?? throw new InvalidOperationException(),
                _ => throw new NotImplementedException($"Day service provider has not been configured for day {day} this year.")
            };
        }
    }
}
