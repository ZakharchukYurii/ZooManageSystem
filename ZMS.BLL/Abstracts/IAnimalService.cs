using System;
using System.Collections.Generic;
using ZMS.BLL.DTO;

namespace ZMS.BLL.Abstracts
{
    public interface IAnimalService : IDisposable
    {
        AnimalDTO Get(int id);
        IEnumerable<AnimalDTO> GetAll();
        void AddNew(AnimalDTO item);
        void Feed(int id);
        void AttachCaretaker(int animalId, int caretakerId);
        IEnumerable<AnimalDTO> Filter(AnimalDTO animal);
    }
}
