using System;
using System.Collections.Generic;
using AutoMapper;
using ZMS.BLL.Abstracts;
using ZMS.BLL.DTO;
using ZMS.BLL.Infrastructure;
using ZMS.DAL.Abstracts;
using ZMS.DAL.Entities;

namespace ZMS.BLL.Services
{
    public class AnimalService : IAnimalService
    {
        private IUnitOfWork _database;
        private IMapper _mapper;

        public AnimalService(IUnitOfWork uow)
        {
            _database = uow;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnimalDTO, Animal>().ReverseMap()).CreateMapper();
        }

        public AnimalDTO Get(int id)
        {
            if (id < 1)
            {
                throw new ValidationException("Id is not valid");
            }

            var result = _database.Animals.Get(id);

            if(result == null)
            {
                throw new NullDataException("Item not found");
            }

            return _mapper.Map<AnimalDTO>(result);
        }

        public IEnumerable<AnimalDTO> GetAll()
        {
            var result = _database.Animals.GetAll();

            if (result == null)
            {
                throw new NullDataException("Items does not exist");
            }

            return _mapper.Map<IEnumerable<AnimalDTO>>(result);
        }

        public void AddNew(AnimalDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Animal is undefined");
            }

            var newItem = _mapper.Map<Animal>(item);

            _database.Animals.Create(newItem);
            _database.Save();
        }

        public void Update(int id, AnimalDTO item)
        {
            if (id < 1)
            {
                throw new ValidationException("Id is not valid");
            }

            var itemToUpdate = _database.Animals.Get(id);

            if (itemToUpdate == null)
            {
                throw new NullDataException("Animal does not exist");
            }

            itemToUpdate.Name = item.Name;
            itemToUpdate.IsHungry = item.IsHungry;

            if (item.Age >= 0)
            {
                itemToUpdate.Age = item.Age;
            }

            if (item.Class != null)
            {
                if (item.Class.Id < 1)
                {
                    throw new ValidationException("AnimalClassId is not valid");
                }

                var animalClass = _database.AnimalClasses.Get(item.Class.Id);

                if (animalClass != null)
                {
                    itemToUpdate.ClassId = item.Class.Id;
                }
                else
                {
                    throw new NullDataException("AnimalClass does not exist");
                }
            }

            _database.Animals.Update(itemToUpdate);
            _database.Save();
        }

        public void Feed(int id)
        {
            if (id < 1)
            {
                throw new ValidationException("Id is not valid");
            }

            var animal = _database.Animals.Get(id);

            if (animal == null)
            {
                throw new NullDataException("Animal does not exist");
            }

            animal.IsHungry = false;

            _database.Animals.Update(animal);
            _database.Save();
        }

        public void AttachCaretaker(int animalId, int caretakerId)
        {
            if (animalId < 1)
            {
                throw new ValidationException("AnimalId is not valid");
            }
            if (caretakerId < 1)
            {
                throw new ValidationException("CaretakerId is not valid");
            }

            var animal = _database.Animals.Get(animalId);

            if (animal == null)
            {
                throw new NullDataException("Animal does not exist");
            }

            var caretaker = _database.Employees.Get(caretakerId);

            if (caretaker == null)
            {
                throw new NullDataException("Caretaker does not exist");
            }

            animal.CaretakerId = caretaker.Id;

            _database.Animals.Update(animal);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
