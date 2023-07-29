using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Entities;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : Controller
    {
        private readonly AppDbContext _context;
        public PhoneController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Phone> CreatePhone(int storeId, string? brand, string? name, string? color, decimal? cost, decimal? price)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(item => item.Id == storeId);
            if (store == null)
            {
                return null;
            }

            var phone = new Phone(brand, name, color, cost, price);
            store.AddPhone(phone);
            await _context.Phones.AddAsync(phone);
            await _context.SaveChangesAsync();
            return phone;
        }

        [HttpGet]
        public async Task<List<Phone>> Get()
            => await _context.Phones.ToListAsync();

        [HttpPut]
        public async Task<Phone?> UpdatePhoneAsync(int id, string? brand, string? name, string? color, decimal? cost, decimal? price)
        {
            var phone = await _context.Phones.FirstOrDefaultAsync(item => item.Id == id);

            if (phone != null)
            {
                phone.Brand = brand;
                phone.Price = price;
                phone.Name = name;
                phone.Color = color;
                phone.Cost = cost;
                _context.Phones.Update(phone);
                await _context.SaveChangesAsync();
            }
            return phone;
        }

        [HttpDelete]
        public async Task DeletePhone(int id)
        {
            var phone = await _context.Phones.FirstOrDefaultAsync(phone => phone.Id == id);
            if (phone is not null)
            {
                _context.Phones.Remove(phone);
                await _context.SaveChangesAsync();
            }
        }

    }
}