using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class ResturantAddresses
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Details { get; set; }

        // relationships
        public Guid CityId{ get; set; }
        public City City{ get; set; }

        public Guid ResturantId { get; set; }
        public Resturant Resturant { get; set; }

    }
}
