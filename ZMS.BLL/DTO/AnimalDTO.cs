using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS.BLL.DTO
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private int _age;
        public int Age
        {
            get => _age;
            set => _age = value >= 0 ? value : 0;
        }

        public Sex Sex { get; set; }
        public bool IsHungry { get; set; }

        public AnimalClassDTO Class { get; set; }

        public EmployeeDTO Caretaker { get; set; }
    }
}
