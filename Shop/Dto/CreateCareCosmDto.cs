﻿using Microsoft.AspNetCore.Http;
using Shop.Data.Enums;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Dto
{
    public class CreateCareCosmDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IFormFile Image { get; set; }
        public CareCosmeticCategory CareCosmeticCategory { get; set; }
        public IEnumerable<Brands> Brands { get; set; }
        public int BrandId { get; set; }
        public string? AppUserId { get; set; }
        public Address Address { get; set; }
        public int Price { get; set; }
        public string HowToUse { get; set; }



    }
}
