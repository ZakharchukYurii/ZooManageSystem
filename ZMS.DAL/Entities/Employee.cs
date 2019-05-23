using System.Collections.Generic;

namespace ZMS.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }

        public IEnumerable<Animal> CareAnimals { get; set; }

        public Employee()
        {
            CareAnimals = new List<Animal>();
        }
    }

    public enum Sex
    {
        Male,
        Female
    }
}
