using BuisnessLogic.DTOs;
using BuisnessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll(int? filterGenreId, string? searchTitle, int? searchYear, int? rating, bool sortByAsc, int pageNumber = 1)
        {
            return Ok(await moviesService.Get(filterGenreId, searchTitle, searchYear, rating, sortByAsc, pageNumber));
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await moviesService.GetById(id)); 
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieDto model)
        {
            // TODO: reference (class) vs value (structures)
            if (!ModelState.IsValid)
                return BadRequest(GetErrorMessages());

            var result = await moviesService.Create(model);

            // 201
            return CreatedAtAction(
                nameof(Get),            // The action to get a single product
                new { id = result.Id },  // Route values for that action
                result                   // Response body
            );
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditMovieDto model)
        {
            // model validation
            if (!ModelState.IsValid)
                return BadRequest(GetErrorMessages());

            await moviesService.Edit(model);

            return Ok(); // 200
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await moviesService.Delete(id);

            return NoContent(); // 204
        }
        private IEnumerable<string> GetErrorMessages()
        {
            return ModelState.Values.SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage);
        }


    }
}
