using Microsoft.AspNetCore.Http;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Dto
{
    public class CreateBrandDto
    {
        public string Title { get; set; }

        public CareCosmetic CareCosmetic { get; set; }
        public Address? Address { get; set; }
        public IFormFile Image { get; set; }

    }
}
