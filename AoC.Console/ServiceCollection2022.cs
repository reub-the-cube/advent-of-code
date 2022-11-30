using aoc._2022.day01;
using AoC.Core;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Console
{
    public static class ServiceCollection2022
    {
        public static IServiceCollection Configure2022Services(this IServiceCollection services)
        {
            return services
                .ConfigureDay01Services();
        }

        public static IDay ResolveDayFor2022(this IServiceProvider serviceProvider, int day)
        {
            Day01Solver daySolver = day switch
            {
                1 => serviceProvider.GetService<Day01Solver>() ?? throw new InvalidOperationException(),
                _ => throw new NotImplementedException($"Day service provider has not been configured for day {day} this year.")
            };
            return daySolver;
        }
    }
}