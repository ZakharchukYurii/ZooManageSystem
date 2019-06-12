using Microsoft.EntityFrameworkCore;
using ZMS.Models;

namespace ZMS.DAL.Context
{
    public sealed class DataContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalClass> AnimalClasses { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DataContext(DbContextOptions<DataContext> dbContextOptions)
            : base(dbContextOptions)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.AnimalClass)
                .WithMany(a => a.Animals);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Caretaker)
                .WithMany(a => a.CareAnimals);

            SeedData.Initialize(modelBuilder);
        }
    }
}
