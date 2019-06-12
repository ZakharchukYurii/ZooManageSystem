using System;
using System.Collections.Generic;

namespace ZMS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public Sex Sex { get; set; }

        public IEnumerable<Animal> CareAnimals { get; set; }

        public Employee()
        {
            CareAnimals = new List<Animal>();
        }

        public bool IsValid()
        {
            if(FirstName == null ||
               LastName == null ||
               Age == null ||
               Age < 16)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
