using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal SupTotal { get; set; }
        public Guid CartId { get; set; }


        // relationships
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
