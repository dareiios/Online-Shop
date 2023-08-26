using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shop.Dto;
using Shop.Helpers;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBrandsRepository _brandsRepository;

        public HomeController(ILogger<HomeController> logger, IBrandsRepository brandsRepository)
        {
            _logger = logger;
            _brandsRepository = brandsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ipInfo = new IPInfo();
            var dto = new HomeDto();
            try
            {
                string url = "http://ipinfo.io?token=03800f5b89e8ed";
                var info = new WebClient().DownloadString(url);//скачиваем данные с сайта в json формате
                ipInfo = JsonConvert.DeserializeObject<IPInfo>(info); //from json to object
                RegionInfo myRegionInfo = new RegionInfo(ipInfo.Country);//берем название страны(RU)
                ipInfo.Country = myRegionInfo.NativeName;//получапем полное название страны
                dto.City = ipInfo.City;//указываем что сити из модели это сити из сайта
                dto.Region = ipInfo.Region;
                if (dto.City != null)
                {
                    dto.Brands = await _brandsRepository.GetBrandByCity(dto.City);//чтобы показать на стр клубы именно твоего города
                }
                else
                {
                    dto.Brands = null;
                }
                return View(dto);
            }
            catch (Exception ex)
            {
                dto.Brands = null;
            }
            return View(dto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
