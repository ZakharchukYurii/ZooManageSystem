namespace ZMS.BLL.DTO
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public Sex Sex { get; set; }
        public bool IsHungry { get; set; }

        public AnimalClassDTO Class { get; set; }

        public EmployeeDTO Caretaker { get; set; }
    }
}
