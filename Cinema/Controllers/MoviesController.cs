using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        
        private readonly CinemaDbContext ctx;

        public MoviesController(CinemaDbContext ctx)
        {
             this.ctx = ctx;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var items = ctx.Movies.ToList();

            return Ok(items);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
             if (id < 0)
                 return BadRequest("Id can not be negative!");

             var item = ctx.Movies.Find(id);

             if (item == null)
                return NotFound("Product not found!");

             return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(Movie model)
        {
            // TODO: reference (class) vs value (structures)

            //}
            // model validation
            if (!ModelState.IsValid)
                return BadRequest(GetErrorMessages());

            //public IActionResult Edit()
            //{
            // logic...
            ctx.Movies.Add(model);
            ctx.SaveChanges(); // generate id (execute INSERT SQL command)

            //}
            // 201
            return CreatedAtAction(
                nameof(Get),            // The action to get a single product
                new { id = model.Id },  // Route values for that action
                model                   // Response body
            );
        }

        [HttpPut]
        public IActionResult Edit(Movie model)
        {
            // model validation
            if (!ModelState.IsValid)
                return BadRequest(GetErrorMessages());

            // logic...
            ctx.Movies.Update(model);
            ctx.SaveChanges();

            return Ok(); // 200
        }
        private IEnumerable<string> GetErrorMessages()
        {
            return ModelState.Values.SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage);
        }


    }
}
