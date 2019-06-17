using ZMS.DAL.Abstracts;
using ZMS.DAL.Context;
using ZMS.Models;

namespace ZMS.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataBase;

        public IRepository<Animal> Animals { get; }
        public IRepository<AnimalClass> AnimalClasses { get; }
        public IRepository<Employee> Employees { get; }

        public UnitOfWork(
            DataContext dataContext,
            IRepository<Animal> animalRepository,
            IRepository<AnimalClass> animalClassRepository,
            IRepository<Employee> employeeRepository)
        {
            _dataBase = dataContext;
            Animals = animalRepository;
            AnimalClasses = animalClassRepository;
            Employees = employeeRepository;
        }

        public void Dispose()
        {
            _dataBase.SaveChanges();
        }

        public void Save()
        {
            _dataBase.SaveChanges();
        }
    }
}
