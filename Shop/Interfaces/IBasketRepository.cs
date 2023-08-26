using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IBasketRepository
    {
        IEnumerable<Basket> GetlAll();
        Task<Basket> GetByIdAsync(int id);
        //Basket GetBasketCareCosmetic();
        //Task<Basket> GetByIdAsyncTracking(int id);

        void AddCareCosmeticToBasket(CareCosmetic cosmetic);//был бул
        void AddBasketToUser(Basket basket);
        void DecrimentCareCosmeticToBasket(int id);
        void IncrementCareCosmeticToBasket(int id);

        bool Update(Basket basket);
        bool Delete(Basket basket);
        bool Save();
    }
}
