using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Dto
{
    public class CreateOrderDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Email { get; set; }
        public int Sum { get; set; }
        public AppUser? AppUser { get; set; }
        public string Name { get; set; }
        public string SureName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
    }
}
