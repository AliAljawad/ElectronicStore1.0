using MyFirstApi.Shared;

namespace MyFirstApi.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public Employee(string name, string position, decimal salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }
    }
}