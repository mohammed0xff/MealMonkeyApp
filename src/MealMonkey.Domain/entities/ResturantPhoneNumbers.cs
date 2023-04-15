using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class ResturantPhoneNumbers
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }

        //relationships
        public Guid ResturantId { get; set; }
        public Resturant Resturant { get; set; }
    }
}
