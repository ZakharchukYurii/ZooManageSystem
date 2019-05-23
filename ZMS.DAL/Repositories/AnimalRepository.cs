using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ZMS.DAL.Abstracts;
using ZMS.DAL.Context;
using ZMS.DAL.Entities;

namespace ZMS.DAL.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private DataContext _dataBase;

        public AnimalRepository(DataContext dataContext)
        {
            _dataBase = dataContext;
        }

        public void Create(Animal item)
        {
            _dataBase.Animals.Add(item);
        }

        public void Delete(int id)
        {
            var animal = _dataBase.Animals.Find(id);

            if (animal != null)
            {
                _dataBase.Animals.Remove(animal);
            }
        }

        public IEnumerable<Animal> Find(Func<Animal, bool> predicate)
        {
            return _dataBase.Animals.Where(predicate).ToList();
        }

        public Animal Get(int id)
        {
            return _dataBase.Animals.Find(id);
        }

        public IEnumerable<Animal> GetAll()
        {
            return _dataBase.Animals.ToList();
        }

        public void Update(Animal item)
        {
            _dataBase.Entry(item).State = EntityState.Modified;
        }
    }
}
