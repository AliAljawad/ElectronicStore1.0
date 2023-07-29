using Microsoft.EntityFrameworkCore;
using MyFirstApi.Entities;

namespace MyFirstApi.Data
{
    public class AppDbContext : DbContext
    {
        public string DbPath { get; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Laptop> Laptops { get; set; }


        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "ElectronicStore.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite($"Data Source={DbPath}");

    }
}
