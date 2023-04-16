using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class Meal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ThumpUrl { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public decimal AverageRating { get; set; }


        // relationships
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public string ResturantId { get; set; }
        public Resturant Resturant { get; set; }

        public ICollection<Offer> Offers { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
