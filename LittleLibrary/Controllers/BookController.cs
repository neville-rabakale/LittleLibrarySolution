using LittleLibrary.Models;
using LittleLibrary.Views.Book;
using Microsoft.AspNetCore.Mvc;

namespace LittleLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly DataService service;

        public BookController(DataService service)
        {
            this.service = service;
        }
        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var model = service.GetAllBooks();
            return View(model);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(service.GetGenre());
        }

        [HttpPost("create")]
        public IActionResult Create(CreateVM createVM)
        {
            if (!ModelState.IsValid)
            {
                return View(service.GetGenre());
            }
            service.AddBook(createVM);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            return View(service.GetBookDetails(id));
        }


    }
}
