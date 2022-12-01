using aoc._2022.day01;
using aoc._2022.day02;
using AoC.Core;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Console
{
    public static class ServiceCollection2022
    {
        public static IServiceCollection Configure2022Services(this IServiceCollection services)
        {
            return services
                .ConfigureDay01Services()
                .ConfigureDay02Services();
        }

        public static IDay ResolveDayFor2022(this IServiceProvider serviceProvider, int day)
        {
            IDay daySolver = day switch
            {
                1 => serviceProvider.GetService<Day01Solver>() ?? throw new InvalidOperationException(),
                2 => serviceProvider.GetService<Day02Solver>() ?? throw new InvalidOperationException(),
                _ => throw new NotImplementedException($"Day service provider has not been configured for day {day} this year.")
            };
            return daySolver;
        }
    }
}