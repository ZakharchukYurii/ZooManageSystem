using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS.BLL.DTO
{
    class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }

        public IEnumerable<AnimalDTO> CareAnimals { get; set; }

        public EmployeeDTO()
        {
            CareAnimals = new List<AnimalDTO>();
        }
    }
}
