using System;
using ZMS.Models;

namespace ZMS.DAL.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Animal> Animals { get; }
        IRepository<AnimalClass> AnimalClasses { get; }
        IRepository<Employee> Employees { get; }
        void Save();
    }
}
