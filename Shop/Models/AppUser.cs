using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class AppUser : IdentityUser
    {        
        public string? ProfileImgUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public Address? Adress { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public ICollection<CareCosmetic> careCosmetics { get; set; }

        public int? BasketId { get; set; }

        [ForeignKey("BasketId")]
        public Basket Basket { get; set; }


    }
}
