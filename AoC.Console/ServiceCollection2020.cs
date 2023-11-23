using AoC.Core;
using AoC.Day01;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Console
{
    public static class ServiceCollection2020
    {
        public static IServiceCollection Configure2020Services(this IServiceCollection services)
        {
            return services
                .ConfigureDay1Services();
        }

        public static IDaySolver ResolveDayFor2020(this IServiceProvider serviceProvider, int day)
        {
            return day switch
            {
                1 => serviceProvider.GetService<Day1>() ?? throw new InvalidOperationException(),
                _ => throw new NotImplementedException($"Day service provider has not been configured for day {day} this year.")
            };
        }
    }
}
