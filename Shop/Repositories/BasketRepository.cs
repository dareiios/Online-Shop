using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Data;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories
{
    public class BasketRepository : IBasketRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;



        public BasketRepository(ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }



        public void AddCareCosmeticToBasket(CareCosmetic cosmetic)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var basket = _context.Baskets.Where(x=>x.AppUser.Id == currentUserId)
                .FirstOrDefault(x=>x.CareCosmeticId == cosmetic.Id);//где юзер айди
            if(basket == null)
            {
                 _context.Baskets.Add(new Basket()
                 {
                    CareCosmeticId = cosmetic.Id,
                    Count = 1,
                    AppUserId = currentUserId
                 });
                Save();

            }
            else
            {
                basket.Count++;
                Update(basket);
            }
        }
        public void AddBasketToUser(Basket basket)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userBd = _userRepository.GetUserById(currentUserId);
            var newUser = new AppUser()
            {
                ProfileImgUrl = userBd.ProfileImgUrl,
                City = userBd.City,
                State = userBd.State,
                Adress = userBd.Adress,
                AddressId = userBd.AddressId,
                careCosmetics = userBd.careCosmetics,
                BasketId = basket.Id,
                Basket = basket
            };
            _userRepository.Update(newUser);
        }

        public void DecrimentCareCosmeticToBasket(int id)
        {
            var cosmetic = GetByIdAsync(id).Result;
            if (cosmetic.Count > 1)
            {
                cosmetic.Count--;
                Update(cosmetic);
            };
        }

        public void IncrementCareCosmeticToBasket(int id)
        {
            var cosmetic = GetByIdAsync(id).Result;
            cosmetic.Count++;
            Update(cosmetic);

        }


      
        public IEnumerable<Basket> GetlAll()//все корзины пользователя
        {
            var currentUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var baskets = _context.Baskets.Include(c=>c.CareCosmetic).Where(x => x.AppUser.Id == currentUser);//Include(d=>d.DecCosmeticId).
            return baskets;
        }


        public async Task<Basket> GetByIdAsync(int id)
        {
            return await _context.Baskets.FirstOrDefaultAsync(x => x.Id == id);

        }
       

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0;
        }

        public bool Update(Basket basket)
        {
            _context.Baskets.Update(basket);
            return Save();
        }


        public bool Delete(Basket basket)
        {
            _context.Baskets.Remove(basket);
            return Save();
        }


    }
}
