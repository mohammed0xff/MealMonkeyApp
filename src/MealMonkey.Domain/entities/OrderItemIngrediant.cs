using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class OrderItemIngrediant
    {
        public Guid OrderItemId { get; set; }
        public Guid IngrediantId { get; set; }
    }
}
