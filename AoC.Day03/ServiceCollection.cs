using AoC.Core;
using AoC.Day03.Models;
using Microsoft.Extensions.DependencyInjection;

namespace AoC.Day03
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay3Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day3>()
                .AddScoped<IParser<Input>, Parser>();
        }
    }
}
