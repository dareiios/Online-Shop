using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Email { get; set; }
        public int Sum { get; set; }
        //public string UserId { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }

        //[ForeignKey("BasketId")]
        //public Basket Baskets { get; set; }
        //public int BasketId { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }


    }
}
