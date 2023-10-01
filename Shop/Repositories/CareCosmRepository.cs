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
    public class CareCosmRepository : ICareCosmRepository
    {
        private readonly ApplicationDbContext _context;

        public CareCosmRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(CareCosmetic cosmetic)
        {
            _context.CareCosmetics.Add(cosmetic);
            return Save();
        }

        public bool Delete(CareCosmetic cosmetic)
        {
            _context.CareCosmetics.Remove(cosmetic);
            return Save();
        }

        public async Task<CareCosmetic> GetByIdAsync(int id)
        {
           return await _context.CareCosmetics.Include(x => x.Address).Include(x => x.Brand).FirstOrDefaultAsync(y=>y.Id == id);
        }

        public async Task<CareCosmetic> GetByIdAsyncTracking(int id)
        {
            return await _context.CareCosmetics.Include(x => x.Address).Include(x => x.Brand).AsNoTracking().FirstOrDefaultAsync(y=>y.Id == id);
        }

        public async Task<IEnumerable<CareCosmetic>> GetCosmByCity(string city)
        {
            return await _context.CareCosmetics.Where(x => x.Address.City == city).ToListAsync();//мб неверно
        }

        public async Task<IEnumerable<CareCosmetic>> GetlAll()
        {
            return _context.CareCosmetics.Include(x=>x.Brand);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0;
        }

        public bool Update(CareCosmetic cosmetic)
        {
            _context.CareCosmetics.Update(cosmetic);
            return Save();
        }


        public async Task<List<string>> GetAllBrandsNames()
        {
            var brands = _context.Brands;
            List<string> names = new List<string>();
            foreach(var brand in brands)
            {
                names.Add(brand.Title);
            }
            return names;
        }
    }
}
