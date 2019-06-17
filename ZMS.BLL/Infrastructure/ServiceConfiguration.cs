using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZMS.DAL;
using ZMS.DAL.Abstracts;
using ZMS.DAL.Context;
using ZMS.DAL.Repositories;
using ZMS.Models;

namespace ZMS.BLL.Infrastructure
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection Configure(this IServiceCollection services, string connectionString)
        {
            // Context
            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(connectionString));

            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IRepository<Animal>, AnimalRepository>();
            services.AddScoped<IRepository<AnimalClass>, AnimalClassRepository>();
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();

            return services;
        }
    }
}
