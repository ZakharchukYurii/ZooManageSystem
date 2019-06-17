using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZMS.BLL.Abstracts;
using ZMS.BLL.Services;
using ZMS.DAL.Context;
using ZMS.DAL.Repositories;
using ZMS.Models;
using ZMS.WebApplication.Abstracts;

namespace ZMS.DAL.Configuration
{
    public static class DALServiceConfiguration
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
