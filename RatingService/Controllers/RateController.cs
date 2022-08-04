using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RatingService.Model;

namespace RatingService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly RatingRepository repository;
        public RateController(RatingRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Rating> Get()
        {
            return repository.RetrieveAll();
        }


        [HttpPost]
        public void Post([FromBody] Rating rate)
        {
            repository.CreateRating(rate);
            
        }

        [HttpPut]
        public void Put([FromBody] Rating rate)
        {
            repository.UpdateRate(rate);
        }

    }
}