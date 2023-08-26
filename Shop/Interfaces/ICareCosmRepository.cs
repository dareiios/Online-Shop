using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface ICareCosmRepository
    {
        Task<IEnumerable<CareCosmetic>> GetlAll();
        Task<CareCosmetic> GetByIdAsync(int id);
        Task<CareCosmetic> GetByIdAsyncTracking(int id);
        Task<IEnumerable<CareCosmetic>> GetCosmByCity(string city);
        bool Add(CareCosmetic cosmetic);
        bool Update(CareCosmetic cosmetic);
        bool Delete(CareCosmetic cosmetic);
        bool Save();

        Task<List<string>> GetAllBrandsNames();
    }
}
