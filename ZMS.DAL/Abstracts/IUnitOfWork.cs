using System;

namespace ZMS.DAL.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAnimalRepository Animals { get; }
        IAnimalClassRepository AnimalClasses { get; }
        IEmployeeRepository Employees { get; }
        void Save();
    }
}
