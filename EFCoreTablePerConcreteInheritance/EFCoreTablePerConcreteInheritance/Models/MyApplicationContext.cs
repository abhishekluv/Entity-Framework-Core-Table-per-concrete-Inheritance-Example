using Microsoft.EntityFrameworkCore;

namespace EFCoreTablePerConcreteInheritance.Models
{
    public class MyApplicationContext : DbContext
    {
        public MyApplicationContext(DbContextOptions<MyApplicationContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Using TPC mapping strategy with EF Core
            modelBuilder.Entity<Vehicle>().UseTpcMappingStrategy();

            modelBuilder.Entity<Motorcycle>().ToTable("Motorcycles");
            modelBuilder.Entity<Car>().ToTable("Cars");

            base.OnModelCreating(modelBuilder);
        }
    }
}
