using System;
using System.Collections.Generic;
using AutoMapper;
using ZMS.BLL.Abstracts;
using ZMS.BLL.DTO;
using ZMS.DAL.Abstracts;
using ZMS.DAL.Entities;

namespace ZMS.BLL.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public AnimalService(IUnitOfWork uow, IMapper mapper)
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
            var newItem = _mapper.Map<Animal>(item);

            _database.Animals.Create(newItem);
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

        public IEnumerable<AnimalDTO> Filter(AnimalDTO animal)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
