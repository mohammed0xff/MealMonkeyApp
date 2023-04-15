using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class Rate
    {
        public Guid Id { get; set; }
        public Decimal Stars { get; set; }


        // relationships
        public Guid CommentId { get; set; }
        public Comment Comment { get; set; }

        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
