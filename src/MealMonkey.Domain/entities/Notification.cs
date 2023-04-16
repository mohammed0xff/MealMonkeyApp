using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMonkey.Domain.Entities
{
    public class Notification
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public bool Seen { get; set; }

        // relationships
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
