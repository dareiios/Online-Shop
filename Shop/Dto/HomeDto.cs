using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Dto
{
    public class HomeDto
    {
        public IEnumerable<Brands> Brands { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
    }
}
