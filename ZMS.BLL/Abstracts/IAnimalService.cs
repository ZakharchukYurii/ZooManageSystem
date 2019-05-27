using System.Collections.Generic;
using ZMS.BLL.DTO;

namespace ZMS.BLL.Abstracts
{
    public interface IAnimalService
    {
        IEnumerable<AnimalDTO> GetAll();
        void Update(int id, AnimalDTO item);
    }
}
