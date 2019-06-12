using Microsoft.Extensions.DependencyInjection;
using ZMS.BLL.Abstracts;
using ZMS.BLL.Infrastructure;
using ZMS.BLL.Services;

namespace ZMS.WebApp.Infrastructure
{
    public static class WebServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, string connectionString)
        {
            services.Configure(connectionString);

            // Services
            services.AddScoped<IAnimalService, AnimalService>();

            return services;
        }
    }
}
