using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingService.Model
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Guid productId { get; set; }
        public float rating { get; set; }
        public Guid raterId { get; set; }
    }
}
