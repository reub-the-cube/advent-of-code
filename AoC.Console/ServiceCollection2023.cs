using AoC.Core;
using aoc2023.day01;
using aoc2023.day02;
using aoc2023.day03;
using aoc2023.day04;
using aoc2023.day05;
using aoc2023.day06;
using aoc2023.day07;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Console
{
    public static class ServiceCollection2023
    {
        public static IServiceCollection Configure2023Services(this IServiceCollection services)
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

        public static IDaySolver ResolveDayFor2023(this IServiceProvider serviceProvider, int day)
        {
            return day switch
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
        }
    }
}
