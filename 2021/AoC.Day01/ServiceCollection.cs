using Microsoft.Extensions.DependencyInjection;

namespace AoC.Day01
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay1Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day1>();
        }
    }
}
