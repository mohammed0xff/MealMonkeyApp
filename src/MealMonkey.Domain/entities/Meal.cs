using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealMonkey.Domain.Entities
{
    public class Meal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ThumpUrl { get; set; }
        public string PhotoUrl { get; set; }
        public decimal AverageRating { get; set; }

        // Forign Key
        public Guid CategoryId { get; set; }
        public Guid ResturantId { get; set; }
        public Guid MealTypeId { get; set; }

        // Navigation Properties
        public Category Category { get; set; }
        public MealType MealType { get; set; }
        public Resturant Resturant { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<MealOffer> MealOffers { get; set; }
    }
}
