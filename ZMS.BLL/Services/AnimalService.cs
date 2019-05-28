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
                throw new ValidationException("Item is undefined");
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
                throw new NullDataException("Item does not exist");
            }

            itemToUpdate.Name = item.Name;
            itemToUpdate.Age = item.Age;
            itemToUpdate.Food = item.Food;

            _database.Animals.Update(itemToUpdate);
            _database.Save();
        }

        public void Feed(int id, string food)
        {
            if (id < 1)
            {
                throw new ValidationException("Id is not valid");
            }

            var itemToUpdate = _database.Animals.Get(id);

            if (itemToUpdate == null)
            {
                throw new NullDataException("Item does not exist");
            }

            itemToUpdate.Food = food;

            _database.Animals.Update(itemToUpdate);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
