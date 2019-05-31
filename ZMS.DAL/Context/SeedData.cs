using Microsoft.EntityFrameworkCore;
using ZMS.DAL.Entities;

namespace ZMS.DAL.Context
{
    public static class SeedData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            var owls = new AnimalClass()
            {
                Id = 1,
                Class = "Bird",
                Family = "Strigiformes",
                Species = "owl",
            };

            var john = new Employee()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Silver",
                Age = 34,
                Sex = Sex.Male
            };

            var phil = new Animal()
            {
                Id = 1,
                Name = "Phil",
                Age = 3,
                Sex = Sex.Male,
                ClassId = 1,
                CaretakerId = 1,
                IsHungry = true
            };

            var lona = new Animal()
            {
                Id = 2,
                Name = "Lona",
                Age = 3,
                Sex = Sex.Female,
                ClassId = 1,
                CaretakerId = 1,
                IsHungry = true
            };

            modelBuilder.Entity<AnimalClass>().HasData(owls);
            modelBuilder.Entity<Employee>().HasData(john);
            modelBuilder.Entity<Animal>().HasData(phil, lona);
        }
    }
}
