using AoC.Core;
using aoc2023.day01;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Console
{
    public static class ServiceCollection2023
    {
        public static IServiceCollection Configure2023Services(this IServiceCollection services)
        {
            return services
                .ConfigureDay01Services();
        }

        public static IDaySolver ResolveDayFor2023(this IServiceProvider serviceProvider, int day)
        {
            return day switch
            {
                1 => serviceProvider.GetService<Day01Solver>() ?? throw new InvalidOperationException(),
                _ => throw new NotImplementedException($"Day service provider has not been configured for day {day} this year.")
            };
        }
    }
}