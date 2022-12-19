using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LittleLibrary.Views.Book
{
    public class CreateVM
    {
        [Required(ErrorMessage = "Please enter the title of the book")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Please enter the name of the Author/s of the book")]
        public string? Author { get; set; }
        public SelectListItem[]? Genre { get; set; }
        [Required(ErrorMessage = "Please give a brief descripion of the book")]
        public string Description { get; set; }
        public int GenreValues { get; set; }
        public bool Available { get; set; } = true;
        public IFormFile? Image { get; set; } = null;
    }

}
