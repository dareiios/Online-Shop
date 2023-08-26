using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Dto;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class BasketController : Controller
    {

        private readonly ICareCosmRepository _careCosmRepository;
        private readonly ApplicationDbContext _context;
        private readonly IPhotoService _photoService;
        private readonly IBasketRepository _basketRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;




        public BasketController(ICareCosmRepository careCosmRepository, ApplicationDbContext context, IPhotoService photoService, IBasketRepository basketRepository, IHttpContextAccessor httpContextAccessor)
        {
            _careCosmRepository = careCosmRepository;
            _context = context;
            _photoService = photoService;
            _basketRepository = basketRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var baskets = _basketRepository.GetlAll();
            //var baskets = _context.Baskets.Include(x => x.CareCosmetic).Include(x => x.DecorativeCosmetic);
            return View(baskets);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)//+
        {
            var cosmCard = await _careCosmRepository.GetByIdAsyncTracking(id);
           _basketRepository.AddCareCosmeticToBasket(cosmCard);//if !=null
            //_basketRepository.AddBasketToUser(basket);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Decrement(int id)
        {
            _basketRepository.DecrimentCareCosmeticToBasket(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Increment(int id)
        {
            _basketRepository.IncrementCareCosmeticToBasket(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var basket = await _basketRepository.GetByIdAsync(id);
            _basketRepository.Delete(basket);
            return RedirectToAction("Index");
        }
    }
}
