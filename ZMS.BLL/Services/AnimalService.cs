using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = _database.Animals.Get(id);

            return _mapper.Map<AnimalDTO>(result);
        }

        public IEnumerable<AnimalDTO> GetAll()
        {
            var result = _database.Animals.GetAll();

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
                throw new Exception("Id is not valid");
            }

            var itemToUpdate = _database.Animals.Get(id);

            itemToUpdate.Name = item.Name;
            itemToUpdate.Age = item.Age;

            if (item.Food.FirstOrDefault() != null)
            {
                (itemToUpdate.Food as List<string>).AddRange(item.Food);
            }

            _database.Animals.Update(itemToUpdate);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
