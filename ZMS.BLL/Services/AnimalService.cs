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
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AnimalService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnimalDTO, Animal>().ReverseMap()).CreateMapper();
        }

        public AnimalDTO Get(int id)
        {
            var result = _unitOfWork.Animals.Get(id);

            return _mapper.Map<AnimalDTO>(result);
        }

        public IEnumerable<AnimalDTO> GetAll()
        {
            var result = _unitOfWork.Animals.GetAll();

            return _mapper.Map<IEnumerable<AnimalDTO>>(result);
        }

        public void Update(int id, AnimalDTO item)
        {
            throw new System.NotImplementedException();
        }
    }
}
