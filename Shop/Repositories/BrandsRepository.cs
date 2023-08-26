using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Brands brand)
        {
            _context.Brands.Add(brand);
            return Save();
        }

        public bool Delete(Brands brand)
        {
            _context.Brands.Remove(brand);
            return Save();
        }

        public async Task<IEnumerable<Brands>> GetBrandByCity(string city)
        {
            return await _context.Brands.Where(x => x.Address.City.Contains(city)).ToListAsync();
            
        }

        public async Task<Brands> GetByIdAsync(int id)
        {
            return await _context.Brands.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<IEnumerable<CareCosmetic>> GetCosmeticsByBrand(string brand)
        {
            return await _context.CareCosmetics.Where(x => x.Brand.Title == brand).ToListAsync();
        }

        public async Task<Brands> GetByIdAsyncTracking(int id)
        {
            return await _context.Brands.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Brands>> GetlAll()
        {
            return _context.Brands;
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Brands brand)
        {
            _context.Brands.Update(brand);
            return Save();
        }

        
    }
}
