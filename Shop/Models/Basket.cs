using Shop.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Basket
    {
        //public List<CareCosmetic> CareCosmetics { get; set; }
        //public List<DecorativeCosmetic> DecorativeCosmetics { get; set; }

        public int? CareCosmeticId { get; set; }

        [ForeignKey("CareCosmeticId")]
        public CareCosmetic CareCosmetic { get; set; }

        public int Count { get; set; }
        public int Id { get; set; }
        public int Sum { get; set; }

        //[Key]
        //public int Id { get; set; }
        //public string? Title { get; set; }
        //public string? Description { get; set; }
        //public string? Image { get; set; }

        //[ForeignKey("Address")]
        //public int? AddressId { get; set; }
        //public Address? Address { get; set; }
        //public CareCosmeticCategory CareCosmeticCategory { get; set; }
        //public DecCosmeticCategory DecCosmeticCategory { get; set; }
        //public Brand brand { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        //public int Price { get; set; }
        //public int Count { get; set; }

    }
}
