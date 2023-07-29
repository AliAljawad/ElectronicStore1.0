using MyFirstApi.Shared;

namespace MyFirstApi.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Employee> Employees { get; set; } = new();
        public List<Phone> Phones { get; set; } = new();
        public List<Laptop> Laptops { get; set; } = new();

        public Store(string name, string location)
        {
            Name = name;
            Location = location;
        }
        public void AddEmployee(Employee employee)
            => Employees.Add(employee);

        public void AddPhone(Phone phone)
            => Phones.Add(phone);

        public void AddLaptop(Laptop laptop)
            => Laptops.Add(laptop);
    }
}
