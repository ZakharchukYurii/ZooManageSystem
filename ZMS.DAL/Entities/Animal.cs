namespace ZMS.DAL.Entities
{
    public class Animal
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

        public int? ClassId { get; set; }
        public AnimalClass Class { get; set; }

        public int? CaretakerId { get; set; }
        public Employee Caretaker { get; set; }
    }
}
