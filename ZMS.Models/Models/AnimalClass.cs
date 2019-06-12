using System;
using System.Collections.Generic;

namespace ZMS.Models
{
    public class AnimalClass
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Family { get; set; }
        public string Class { get; set; }

        public IEnumerable<Animal> Animals { get; set; }

        public AnimalClass()
        {
            Animals = new List<Animal>();
        }

        public bool IsValid()
        {
            if(Species == null ||
               Family == null ||
               Class == null)
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