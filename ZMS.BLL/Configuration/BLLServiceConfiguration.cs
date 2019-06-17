using Microsoft.Extensions.DependencyInjection;
using ZMS.BLL.Services;
using ZMS.WebApplication.Abstracts;

namespace ZMS.BLL.Configuration
{
    public static class BLLServiceConfiguration
    {
        public static IServiceCollection Configure(this IServiceCollection services, string connectionString)
        {
            // Services
            services.AddScoped<IAnimalService, AnimalService>();

            return services;
        }
    }
}
