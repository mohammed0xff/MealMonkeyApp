using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class CartItemIngrediant
    {
        public Guid CartItemId { get; set; }
        public Guid IngrediantId { get; set; }
    }
}
