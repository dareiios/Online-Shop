using Shop.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class CareCosmetic
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }

        [ForeignKey("BrandId")]
        public Brands Brand { get; set; }
        public int BrandId { get; set; }

        public string? Description { get; set; }
        public string? Image { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public CareCosmeticCategory CareCosmeticCategory { get; set; }
        public int Price { get; set; }
        public string HowToUse { get; set; }
    }
}
