using AoC.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AoC.Console
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDayServices(this IServiceCollection services)
        {
            return services
                .AddLogging(loggingBuilder => loggingBuilder.AddConsole())
                .AddLogging(loggingBuilder => loggingBuilder.AddDebug())
                .Configure2020Services()
                .Configure2021Services()
                .Configure2022Services()
                .Configure2023Services()
                .AddScoped<Func<(int Year, int Day), IDaySolver>>(dayServiceProvider => options =>
                {
                    return options.Year switch
                    {
                        2020 => dayServiceProvider.ResolveDayFor2020(options.Day),
                        2021 => dayServiceProvider.ResolveDayFor2021(options.Day),
                        2022 => dayServiceProvider.ResolveDayFor2022(options.Day),
                        2023 => dayServiceProvider.ResolveDayFor2023(options.Day),
                        _ => throw new NotImplementedException($"Service provider has not been configured for year {options.Year}.")
                    };
                });
        }
    }

}
