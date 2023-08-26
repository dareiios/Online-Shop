using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
     public interface IBrandsRepository
     {
        Task<IEnumerable<Brands>> GetlAll();
        Task<Brands> GetByIdAsync(int id);
        Task<Brands> GetByIdAsyncTracking(int id);
        Task<IEnumerable<Brands>> GetBrandByCity(string city);
        Task<IEnumerable<CareCosmetic>> GetCosmeticsByBrand(string brand);
        bool Add(Brands brand);
        bool Update(Brands brand);
        bool Delete(Brands brand);
        bool Save();
    }
}
