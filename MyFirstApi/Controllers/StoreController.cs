using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MyFirstApi.Data;
using MyFirstApi.Entities;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {

        private readonly AppDbContext _context;
        public StoreController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Store> CreateStore(string name, string location)
        {

            var store = new Store(name, location);
            await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
            return store;
        }

        [HttpGet]
        public async Task<List<Store>> Get()
            => await _context.Stores.ToListAsync();

        [HttpPut]
        public async Task<Store?> UpdateStoreAsync(int id, string name, string location)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(item => item.Id == id);

            if (store != null)
            {
                store.Name = name;
                store.Location = location;
                _context.Stores.Update(store);
                await _context.SaveChangesAsync();
            }
            return store;
        }

        [HttpDelete]
        public async Task DeleteStore(int id)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(store => store.Id == id);
            if (store is not null)
            {
                _context.Stores.Remove(store);
                await _context.SaveChangesAsync();
            }
        }

    }
}