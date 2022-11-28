using AoC.Core;
using AoC.Day01;
using AoC.Day02;
using AoC.Day03;
using aoc.day04;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Console
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDayServices(this IServiceCollection services)
        {
            return services
                .ConfigureDay1Services()
                .ConfigureDay2Services()
                .ConfigureDay3Services()
                .ConfigureDay4Services()
                .AddScoped<Func<int, IDay>>(dayServiceProvider => dayNumber =>
                {
                    return dayNumber switch
                    {
                        1 => dayServiceProvider.GetService<Day1>() ?? throw new InvalidOperationException(),
                        2 => dayServiceProvider.GetService<Day2>() ?? throw new InvalidOperationException(),
                        3 => dayServiceProvider.GetService<Day3>() ?? throw new InvalidOperationException(),
                        4 => dayServiceProvider.GetService<Day4>() ?? throw new InvalidOperationException(),
                        _ => throw new InvalidOperationException()
                    };
                });
        }
    }
}
