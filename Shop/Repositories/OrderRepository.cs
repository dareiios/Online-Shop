using Microsoft.AspNetCore.Http;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool Add(Order order)
        {
            _context.Add(order);
            return Save();
        }

        public bool Delete(Order order)
        {
            _context.Remove(order);
            return Save();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(y => y.Id == id);
        }

        public async Task<Order> GetByIdAsyncTracking(int id)
        {
            return await _context.Orders.AsNoTracking().FirstOrDefaultAsync(y => y.Id == id);
        }

        public async Task<IEnumerable<Order>> GetlAll()
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            return await _context.Orders.Where(x=>x.AppUserId==currentUserId).ToListAsync();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(Order order)
        {
            _context.Update(order);
            return Save();
        }

        //public async Task<int> GetBasketSum(Basket basket)
        //{
        //    var basketDb = _context.Baskets.Where(x=>x.Id == basket.Id);
        //    var r = basketDb.Contains()
        //}

    }
}
