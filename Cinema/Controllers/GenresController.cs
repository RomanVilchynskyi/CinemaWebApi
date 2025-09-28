using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class GenresController : ControllerBase
    {
        private readonly CinemaDbContext ctx;

        public GenresController(CinemaDbContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var genres = ctx.Genre.ToList();
            return Ok(genres);
        }
    }
}
