using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZMS.BLL.Abstracts;
using ZMS.BLL.Services;
using ZMS.DAL;
using ZMS.DAL.Abstracts;
using ZMS.DAL.Context;
using ZMS.DAL.Repositories;

namespace ZMS.BLL.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, string connectionString)
        {
            // Context
            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(connectionString));

            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IAnimalClassRepository, AnimalClassRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Services
            services.AddScoped<IAnimalService, AnimalService>();

            return services;
        }
    }
}
