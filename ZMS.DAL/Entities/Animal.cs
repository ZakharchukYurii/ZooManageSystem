namespace ZMS.DAL.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public Sex Sex { get; set; }
        public bool IsHungry { get; set; }

        public int? ClassId { get; set; }
        public AnimalClass Class { get; set; }

        public int? CaretakerId { get; set; }
        public Employee Caretaker { get; set; }
    }
}
