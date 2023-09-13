using Microsoft.AspNetCore.Mvc;
using Shop.Data.Enums;
using Shop.Dto;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandsRepository _brandsRepository;
        private readonly IPhotoService _photoService;

        public BrandsController(IBrandsRepository brandsRepository,
            IPhotoService photoService)
        {
            _brandsRepository = brandsRepository;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _brandsRepository.GetlAll();
            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto dto)
        {
            if (ModelState.IsValid)
            {
                var img = await _photoService.AddPhotoAsync(dto.Image);                

                var brand = new Brands()
                {                    
                    Title = dto.Title,
                    Image = img.Url.ToString(),
                    Description = dto.Description,
                    Address = new Address()
                    {
                        City = dto.Address.City,
                        Region = dto.Address.Region,
                        Street = dto.Address.Street
                    }                    
                };
                _brandsRepository.Add(brand);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public async Task<IActionResult> Details(int id)
        {
            var brand = await _brandsRepository.GetByIdAsync(id);
            var cosmetics = await _brandsRepository.GetCosmeticsByBrand(brand.Title);
            return View(cosmetics);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _brandsRepository.GetByIdAsync(id);
             _brandsRepository.Delete(brand);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _brandsRepository.GetByIdAsync(id);
            var brandDto = new EditBrandDto()
            {
                Title = brand.Title,
                ImgUrl = brand.Image,
                Description = brand.Description,
                Address = new Address()
                {
                    City = brand.Address.City,
                    Region = brand.Address.Region,
                    Street = brand.Address.Street
                }
            };
            return View(brandDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBrandDto dto)
        {
            if (ModelState.IsValid)
            {
                var brand = await _brandsRepository.GetByIdAsyncTracking(dto.Id);

                await _photoService.DeletePhotoAsync(brand.Image);
                var photo = await _photoService.AddPhotoAsync(dto.Image);

                var brandNew = new Brands()
                {
                    Id = dto.Id,
                    Title = dto.Title,
                    Description = dto.Description,
                    Image = photo.Url.ToString(),
                    Address = dto.Address              
                };

                _brandsRepository.Update(brandNew);
                return RedirectToAction("Index");
            }
            return View(dto);
        }
    }
}
