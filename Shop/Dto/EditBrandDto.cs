using Microsoft.AspNetCore.Http;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Dto
{
    public class EditBrandDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public string ImgUrl { get; set; }

        [ForeignKey("CareCosmeticId")]
        public CareCosmetic CareCosmetic { get; set; }

        [ForeignKey("Address")]
        public Address? Address { get; set; }
    }
}
