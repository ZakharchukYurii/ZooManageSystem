using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ZMS.DAL.Abstracts;
using ZMS.DAL.Context;
using ZMS.Models;
using ZMS.Exceptions;

namespace ZMS.DAL.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly DataContext _dataBase;

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
            var result = _dataBase.Animals.Where(predicate).ToList();

            if (result.Count < 1)
                throw new NullDataException();

            return result;
        }

        public Animal Get(int id)
        {
            var result = _dataBase.Animals.Find(id);

            if (result == null)
                throw new NullDataException();

            return result;
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
