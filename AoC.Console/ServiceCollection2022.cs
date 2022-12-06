using aoc._2022.day01;
using aoc._2022.day02;
using aoc._2022.day03;
using aoc._2022.day04;
using aoc2022.day05;
using aoc2022.day06;
using aoc2022.day07;
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
                .ConfigureDay02Services()
                .ConfigureDay03Services()
                .ConfigureDay04Services()
                .ConfigureDay05Services()
                .ConfigureDay06Services()
                .ConfigureDay07Services();
        }

        public static IDaySolver ResolveDayFor2022(this IServiceProvider serviceProvider, int day)
        {
            IDaySolver daySolver = day switch
            {
                1 => serviceProvider.GetService<Day01Solver>() ?? throw new InvalidOperationException(),
                2 => serviceProvider.GetService<Day02Solver>() ?? throw new InvalidOperationException(),
                3 => serviceProvider.GetService<Day03Solver>() ?? throw new InvalidOperationException(),
                4 => serviceProvider.GetService<Day04Solver>() ?? throw new InvalidOperationException(),
                5 => serviceProvider.GetService<Day05Solver>() ?? throw new InvalidOperationException(),
                6 => serviceProvider.GetService<Day06Solver>() ?? throw new InvalidOperationException(),
                7 => serviceProvider.GetService<Day07Solver>() ?? throw new InvalidOperationException(),
                _ => throw new NotImplementedException($"Day service provider has not been configured for day {day} this year.")
            };
            return daySolver;
        }
    }
}