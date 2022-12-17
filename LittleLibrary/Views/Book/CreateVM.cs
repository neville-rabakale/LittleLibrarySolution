using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LittleLibrary.Views.Book
{
    public class CreateVM
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Author { get; set; }
        public SelectListItem[]? Genre { get; set; }
        public int GenreValues { get; set; }
        public bool Available { get; set; } = true;
        public IFormFile? Image { get; set; } = null;
    }
}
