using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Entities;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Employee> CreateEmployee(int storeId,string name,string position,int salary)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(item => item.Id == storeId);
            if (store == null)
            {
                return null;
            }

            var employee = new Employee(name,position,salary);
            store.AddEmployee(employee);
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        [HttpGet]
        public async Task<List<Employee>> Get()
            => await _context.Employees.ToListAsync();

        [HttpPut]
        public async Task<Employee?> UpdateEmployeeAsync(int id, string name,string position,int salary)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(item => item.Id == id);

            if (employee != null)
            {
                employee.Name = name;
                employee.Position = position;
                employee.Salary = salary;
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        [HttpDelete]
        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
            if (employee is not null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

    }
}