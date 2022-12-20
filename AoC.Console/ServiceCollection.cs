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
                .Configure2021Services()
                .Configure2022Services()
                .AddScoped<Func<(int Year, int Day), IDaySolver>>(dayServiceProvider => options =>
                {
                    return options.Year switch
                    {
                        2021 => dayServiceProvider.ResolveDayFor2021(options.Day),
                        2022 => dayServiceProvider.ResolveDayFor2022(options.Day),
                        _ => throw new NotImplementedException($"Service provider has not been configured for year {options.Year}.")
                    };
                });
        }
    }

}
