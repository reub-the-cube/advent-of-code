using aoc.day04;
using AoC.Core;
using AoC.Day01;
using AoC.Day02;
using AoC.Day03;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Console
{
    public static class ServiceCollection2021
    {
        public static IServiceCollection Configure2021Services(this IServiceCollection services)
        {
            return services
                .ConfigureDay1Services()
                .ConfigureDay2Services()
                .ConfigureDay3Services()
                .ConfigureDay4Services();
        }

        public static IDay ResolveDayFor2021(this IServiceProvider serviceProvider, int day)
        {
            return day switch
            {
                1 => serviceProvider.GetService<Day1>() ?? throw new InvalidOperationException(),
                2 => serviceProvider.GetService<Day2>() ?? throw new InvalidOperationException(),
                3 => serviceProvider.GetService<Day3>() ?? throw new InvalidOperationException(),
                4 => serviceProvider.GetService<Day4>() ?? throw new InvalidOperationException(),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
