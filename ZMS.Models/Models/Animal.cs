using System;

namespace ZMS.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public Sex Sex { get; set; }
        public bool IsHungry { get; set; }

        public int? AnimalClassId { get; set; }
        public AnimalClass AnimalClass { get; set; }
        public int? CaretakerId { get; set; }
        public Employee Caretaker { get; set; }

        public Func<Animal, bool> Filter { get; set; }

        public Animal()
        {
            IsHungry = true;
        }

        public bool IsValid()
        {
            if (Age < 0 ||
               Age == null ||
               Name == null ||
               AnimalClass == null)
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
