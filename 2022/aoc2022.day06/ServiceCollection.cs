using Microsoft.Extensions.DependencyInjection;

namespace aoc2022.day06
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigureDay06Services(this IServiceCollection services)
        {
            return services
                .AddScoped<Day06Solver>();
        }
    }
}
