using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class UserAddresses
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Details { get; set; }


        // relationships
        public Guid CityId { get; set; }
        public City City { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
