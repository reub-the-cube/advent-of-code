using aoc._2022.day01;
using aoc._2022.day02;
using aoc._2022.day03;
using aoc._2022.day04;
using aoc2022.day05;
using aoc2022.day06;
using aoc2022.day07;
using aoc2022.day08;
using aoc2022.day09;
using aoc2022.day10;
using aoc2022.day11;
using aoc2022.day12;
using aoc2022.day13;
using aoc2022.day14;
using aoc2022.day15;
using aoc2022.day16;
using aoc2022.day17;
using aoc2022.day18;
using aoc2022.day19;
using aoc2022.day20;
using aoc2022.day21;
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
                .ConfigureDay07Services()
                .ConfigureDay08Services()
                .ConfigureDay09Services()
                .ConfigureDay10Services()
                .ConfigureDay11Services()
                .ConfigureDay12Services()
                .ConfigureDay13Services()
                .ConfigureDay14Services()
                .ConfigureDay15Services()
                .ConfigureDay16Services()
                .ConfigureDay17Services()
                .ConfigureDay18Services()
                .ConfigureDay19Services()
                .ConfigureDay20Services()
                .ConfigureDay21Services();
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
                8 => serviceProvider.GetService<Day08Solver>() ?? throw new InvalidOperationException(),
                9 => serviceProvider.GetService<Day09Solver>() ?? throw new InvalidOperationException(),
                10 => serviceProvider.GetService<Day10Solver>() ?? throw new InvalidOperationException(),
                11 => serviceProvider.GetService<Day11Solver>() ?? throw new InvalidOperationException(),
                12 => serviceProvider.GetService<Day12Solver>() ?? throw new InvalidOperationException(),
                13 => serviceProvider.GetService<Day13Solver>() ?? throw new InvalidOperationException(),
                14 => serviceProvider.GetService<Day14Solver>() ?? throw new InvalidOperationException(),
                15 => serviceProvider.GetService<Day15Solver>() ?? throw new InvalidOperationException(),
                16 => serviceProvider.GetService<Day16Solver>() ?? throw new InvalidOperationException(),
                17 => serviceProvider.GetService<Day17Solver>() ?? throw new InvalidOperationException(),
                18 => serviceProvider.GetService<Day18Solver>() ?? throw new InvalidOperationException(),
                19 => serviceProvider.GetService<Day19Solver>() ?? throw new InvalidOperationException(),
                20 => serviceProvider.GetService<Day20Solver>() ?? throw new InvalidOperationException(),
                21 => serviceProvider.GetService<Day21Solver>() ?? throw new InvalidOperationException(),
                _ => throw new NotImplementedException($"Day service provider has not been configured for day {day} this year.")
            };
            return daySolver;
        }
    }
}