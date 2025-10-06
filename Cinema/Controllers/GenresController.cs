using BuisnessLogic.DTOs;
using BuisnessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres(int pageNumber = 1)
        {
            return Ok(await genreService.Get(pageNumber));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDto>> GetGenre(int id)
        {
            return Ok(await genreService.GetById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(GenreDto category)
        {
            await genreService.Edit(category);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> Create(GenreDto category)
        {
            var item = await genreService.Create(category);
            return CreatedAtAction("GetCategory", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await genreService.Delete(id);
            return NoContent();
        }
    }
}
