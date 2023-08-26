using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Dto;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderController(IOrderRepository orderRepository, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Create()
        {
            CreateOrderDto dto = new CreateOrderDto();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderDto dto)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            //sum=репозиторий получение суммы из баскета

            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    Name = dto.Name,
                    SureName = dto.SureName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    City = dto.City,
                    Street = dto.Street,
                    Phone = dto.Phone,
                    Sum = dto.Sum,
                    AppUserId = currentUserId
                };
                _orderRepository.Add(order);
                return RedirectToAction("Index");
            }
            return View(dto);
        }


        public async Task<IActionResult> Index()
        {
            var oreders = await _orderRepository.GetlAll();
            return View(oreders);
        }



    }
}
