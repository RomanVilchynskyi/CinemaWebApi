using AutoMapper;
using BuisnessLogic.DTOs;
using BuisnessLogic.Interfaces;
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
       
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(moviesService.GetAll());
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(moviesService.Get(id)); 
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateMovieDto model)
        {
            // TODO: reference (class) vs value (structures)
            if (!ModelState.IsValid)
                return BadRequest(GetErrorMessages());

            var result = moviesService.Create(model);

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

            moviesService.Edit(model);

            return Ok(); // 200
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            moviesService.Delete(id);

            return NoContent(); // 204
        }
        private IEnumerable<string> GetErrorMessages()
        {
            return ModelState.Values.SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage);
        }


    }
}
