using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class OrderStatus
    {
        public Guid Id { get; set; }
        public DateTime At { get; set; }

        // relationships
        public Guid OrderId { get; set; }

        public Guid StatusId { get; set; }
        public Status Status { get; set; }
    }
}
