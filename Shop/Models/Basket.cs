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

        public int? CareCosmeticId { get; set; }

        [ForeignKey("CareCosmeticId")]
        public CareCosmetic CareCosmetic { get; set; }

        public int Count { get; set; }
        public int Id { get; set; }
        public int Sum { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
