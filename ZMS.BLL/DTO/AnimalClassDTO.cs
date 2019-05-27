using System.Collections.Generic;

namespace ZMS.BLL.DTO
{
    public class AnimalClassDTO
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Family { get; set; }
        public string Class { get; set; }

        public IEnumerable<AnimalDTO> Animals { get; set; }

        public AnimalClassDTO()
        {
            Animals = new List<AnimalDTO>();
        }
    }
}