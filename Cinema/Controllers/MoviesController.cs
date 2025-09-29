using AutoMapper;
using BuisnessLogic.DTOs;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        
        private readonly CinemaDbContext ctx;
        private readonly IMapper mapper;

        public MoviesController(CinemaDbContext ctx, IMapper mapper)
        {
             this.ctx = ctx;
            this.mapper = mapper;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            //var items = ctx.Movies.ToList();
            var items = ctx.Movies
                           .Include(x => x.Genre)
                           .ToList();

            return Ok(mapper.Map<IEnumerable<MovieDto>>(items));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
             if (id < 0)
                 return BadRequest("Id can not be negative!");

             var item = ctx.Movies.Find(id);

             if (item == null)
                return NotFound("Product not found!");

             return Ok(mapper.Map<MovieDto>(item));
        }
        [HttpPost]
        public IActionResult Create(CreateMovieDto model)
        {
            // TODO: reference (class) vs value (structures)

            //}
            // model validation
            if (!ModelState.IsValid)
                return BadRequest(GetErrorMessages());

            var entity = mapper.Map<Movie>(model);
            ctx.Movies.Add(entity);
            ctx.SaveChanges(); // generate id (execute INSERT SQL command)

            var result = mapper.Map<MovieDto>(entity);
            //}
            // 201
            return CreatedAtAction(
                nameof(Get),            // The action to get a single product
                new { id = result.Id },  // Route values for that action
                result                   // Response body
            );
        }

        [HttpPut]
        public IActionResult Edit(EditMovieDto model)
        {
            // model validation
            if (!ModelState.IsValid)
                return BadRequest(GetErrorMessages());

            // logic...
            ctx.Movies.Update(mapper.Map<Movie>(model));
            ctx.SaveChanges();

            return Ok(); // 200
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest("Id can not be negative!");

            var item = ctx.Movies.Find(id);
            if (item == null)
                return NotFound("Product not found!");
            ctx.Movies.Remove(item);
            ctx.SaveChanges();
            return NoContent(); // 204
        }
        private IEnumerable<string> GetErrorMessages()
        {
            return ModelState.Values.SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage);
        }


    }
}
