using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Dto;
using Shop.Interfaces;
using Shop.Models;
using Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CareCosmeticController : Controller
    {
        private readonly ICareCosmRepository _careCosmRepository;
        private readonly IPhotoService _photoService;
        private readonly IBasketRepository _basketRepository;
        private readonly ApplicationDbContext _context;


        public CareCosmeticController(ICareCosmRepository careCosmRepository, IPhotoService photoService, IBasketRepository basketRepository = null, ApplicationDbContext context = null)
        {
            _careCosmRepository = careCosmRepository;
            _photoService = photoService;
            _basketRepository = basketRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cosmetics = await _careCosmRepository.GetlAll();
            return View(cosmetics);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cosm = await _careCosmRepository.GetByIdAsync(id);
            return View(cosm);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var cosmetic = await _careCosmRepository.GetByIdAsync(id);
             _careCosmRepository.Delete(cosmetic);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            var brands = _context.Brands.ToList();
            return View(new CreateCareCosmDto()
            {
                Brands = brands
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCareCosmDto dto)
        {
            if (ModelState.IsValid)
            {

                var img = await _photoService.AddPhotoAsync(dto.Image);

                var carecosm = new CareCosmetic()
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    Image = img.Url.ToString(),
                    CareCosmeticCategory = dto.CareCosmeticCategory,
                    BrandId = dto.BrandId,
                    Price = dto.Price,
                    Address =  new Address()
                    {
                        City = dto.Address.City,
                        Region = dto.Address.Region,
                        Street = dto.Address.Street
                    }                    
                };
                _careCosmRepository.Add(carecosm);
                return RedirectToAction("Index");
            }
            return View(dto);
        }



        public async Task<IActionResult> Edit(int id)
        {
            var brands = _context.Brands.ToList();
            var cosm = await _careCosmRepository.GetByIdAsync(id);
            var cosmDto = new EditCareCosmDto()
            {
                Title = cosm.Title,
                Description = cosm.Description,
                ImgUrl = cosm.Image,
                CareCosmeticCategory = cosm.CareCosmeticCategory,
                BrandId = cosm.BrandId,
                Address = cosm.Address,
                Price = cosm.Price,
                Brands = brands
            };
            return View(cosmDto);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditCareCosmDto dto)
        {
            if (ModelState.IsValid)
            {
                //находим что за объект и удляем его картинку, преобразуем
                var cosm = await _careCosmRepository.GetByIdAsyncTracking(dto.Id);
                
                try
                {
                    await _photoService.DeletePhotoAsync(cosm.Image);
                }
                catch 
                {
                    ModelState.AddModelError("", "не получилось удалить фото");
                    return View(dto);
                }

                var img = await _photoService.AddPhotoAsync(dto.Image);

                var newCosm = new CareCosmetic()
                {
                    Id = dto.Id,
                    Title = dto.Title,
                    Description = dto.Description,
                    Image = img.Url.ToString(),
                    CareCosmeticCategory = dto.CareCosmeticCategory,
                    BrandId = dto.BrandId,
                    Address = dto.Address,
                    Price = dto.Price
                };
                _careCosmRepository.Update(newCosm);
                return RedirectToAction("Index");
                
            }
            return View(dto);
        }

    }
}
