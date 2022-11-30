using AoC.Core;
using AoC.Day02.Models;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Day02
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay2Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day2>()
                .AddScoped<IParser<MachineReadout>, Parser>();
        }
    }
}
