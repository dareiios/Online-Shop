using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetlAll();
        Task<Order> GetByIdAsync(int id);
        Task<Order> GetByIdAsyncTracking(int id);
        bool Add(Order order);
        bool Update(Order order);
        bool Delete(Order order);
        bool Save();
    }
}
