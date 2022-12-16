using Microsoft.AspNetCore.Mvc;

namespace LittleLibrary.Controllers
{
    public class BookController : Controller
    {
        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Content("This works");
        }
    }
}
