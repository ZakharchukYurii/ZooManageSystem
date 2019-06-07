using ZMS.DAL.Abstracts;
using ZMS.DAL.Context;

namespace ZMS.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataBase;

        public IAnimalRepository Animals { get; }
        public IAnimalClassRepository AnimalClasses { get; }
        public IEmployeeRepository Employees { get; }

        public UnitOfWork(
            DataContext dataContext,
            IAnimalRepository animalRepository,
            IAnimalClassRepository animalClassRepository,
            IEmployeeRepository employeeRepository)
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
