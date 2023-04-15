using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class Resturant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumpUrl { get; set; }
        public string PhotoUrl { get; set; }

        // relationships
        public Guid AddressId { get; set; }
        public ResturantAddresses Address { get; set; }
    }
}
