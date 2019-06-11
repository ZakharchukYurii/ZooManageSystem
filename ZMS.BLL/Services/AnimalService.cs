using System;
using System.Collections.Generic;
using ZMS.BLL.Abstracts;
using ZMS.DAL.Abstracts;
using ZMS.Models;

namespace ZMS.BLL.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _database;

        public AnimalService(IUnitOfWork uow)
        {
            _database = uow;
        }

        public Animal Get(int id)
        {
            var result = _database.Animals.Get(id);

            return result;
        }

        public IEnumerable<Animal> GetAll()
        {
            var result = _database.Animals.GetAll();

            return result;
        }

        public void AddNew(Animal item)
        {
            _database.Animals.Create(item);
            _database.Save();
        }

        public void Feed(int id)
        {
            var animal = _database.Animals.Get(id);

            animal.IsHungry = false;

            _database.Animals.Update(animal);
            _database.Save();
        }

        public void AttachCaretaker(int animalId, int caretakerId)
        {
            var animal = _database.Animals.Get(animalId);
            var caretaker = _database.Employees.Get(caretakerId);

            animal.CaretakerId = caretaker.Id;

            _database.Animals.Update(animal);
            _database.Save();
        }

        public IEnumerable<Animal> Filter(Animal animal)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
