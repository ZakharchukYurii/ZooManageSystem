using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ZMS.DAL.Abstracts;
using ZMS.DAL.Context;
using ZMS.DAL.Entities;
using ZMS.Shared.Exceptions;

namespace ZMS.DAL.Repositories
{
    public class AnimalClassRepository : IAnimalClassRepository
    {
        private DataContext _dataBase;

        public AnimalClassRepository(DataContext dataContext)
        {
            _dataBase = dataContext;
        }

        public void Create(AnimalClass item)
        {
            _dataBase.AnimalClasses.Add(item);
        }

        public void Delete(int id)
        {
            var animalClass = _dataBase.AnimalClasses.Find(id);

            if (animalClass != null)
            {
                _dataBase.AnimalClasses.Remove(animalClass);
            }
        }

        public IEnumerable<AnimalClass> Find(Func<AnimalClass, bool> predicate)
        {
            var result = _dataBase.AnimalClasses.Where(predicate).ToList();

            if(result != null)
            {
                return result;
            }
            else
            {
                throw new NullDataException();
            }
        }

        public AnimalClass Get(int id)
        {
            var result = _dataBase.AnimalClasses.Find(id);

            if(result != null)
            {
                return result;
            }
            else
            {
                throw new NullDataException();
            }
        }

        public IEnumerable<AnimalClass> GetAll()
        {
            return _dataBase.AnimalClasses.ToList();
        }

        public void Update(AnimalClass item)
        {
            _dataBase.Entry(item).State = EntityState.Modified;
        }
    }
}
