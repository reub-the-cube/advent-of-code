using AoC.Core;
using aoc2020.day01;
using aoc2020.day02;
using aoc2020.day03;
using aoc2020.day04;
using aoc2020.day05;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Console
{
    public static class ServiceCollection2020
    {
        public static IServiceCollection Configure2020Services(this IServiceCollection services)
        {
            return services
                .ConfigureDay01Services()
                .ConfigureDay02Services()
                .ConfigureDay03Services()
                .ConfigureDay04Services()
                .ConfigureDay05Services();
        }

        public static IDaySolver ResolveDayFor2020(this IServiceProvider serviceProvider, int day)
        {
            return day switch
            {
                1 => serviceProvider.GetService<Day01Solver>() ?? throw new InvalidOperationException(),
                2 => serviceProvider.GetService<Day02Solver>() ?? throw new InvalidOperationException(),
                3 => serviceProvider.GetService<Day03Solver>() ?? throw new InvalidOperationException(),
                4 => serviceProvider.GetService<Day04Solver>() ?? throw new InvalidOperationException(),
                5 => serviceProvider.GetService<Day05Solver>() ?? throw new InvalidOperationException(),
                _ => throw new NotImplementedException($"Day service provider has not been configured for day {day} this year.")
            };
        }
    }
}
