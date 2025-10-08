using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class AccountsController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
