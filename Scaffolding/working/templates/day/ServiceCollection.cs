using AoC.Core;
using day.domain;
using Microsoft.Extensions.DependencyInjection;

namespace day
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDayXServices(this IServiceCollection services)
        {
            return services
                .AddScoped<DayXSolver>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
