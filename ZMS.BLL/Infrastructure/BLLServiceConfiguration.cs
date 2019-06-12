using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZMS.DAL;
using ZMS.DAL.Abstracts;
using ZMS.DAL.Context;
using ZMS.DAL.Repositories;

namespace ZMS.BLL.Infrastructure
{
    public static class BLLServiceConfiguration
    {
        public static IServiceCollection Configure(this IServiceCollection services, string connectionString)
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

            return services;
        }
    }
}
