using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Entities;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : Controller
    {
        private readonly AppDbContext _context;
        public LaptopController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Laptop> CreateLaptop(int storeId, string? brand, string? name, string? color, decimal? cost, decimal? price)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(item => item.Id == storeId);
            if (store == null)
            {
                return null;
            }

            var laptop= new Laptop(brand, name, color, cost, price);
            store.AddLaptop(laptop);
            await _context.Laptops.AddAsync(laptop);
            await _context.SaveChangesAsync();
            return laptop;
        }

        [HttpGet]
        public async Task<List<Laptop>> Get()
            => await _context.Laptops.ToListAsync();

        [HttpPut]
        public async Task<Laptop?> UpdateLaptopAsync(int id, string? brand, string? name, string? color, decimal? cost, decimal? price)
        {
            var laptop = await _context.Laptops.FirstOrDefaultAsync(item => item.Id == id);

            if (laptop != null)
            {
                laptop.Brand = brand;
                laptop.Price = price;
                laptop.Name = name;
                laptop.Color = color;
                laptop.Cost = cost;
                _context.Laptops.Update(laptop);
                await _context.SaveChangesAsync();
            }
            return laptop;
        }

        [HttpDelete]
        public async Task DeleteLaptop(int id)
        {
            var laptop = await _context.Laptops.FirstOrDefaultAsync(laptop => laptop.Id == id);
            if (laptop is not null)
            {
                _context.Laptops.Remove(laptop);
                await _context.SaveChangesAsync();
            }
        }

    }
}