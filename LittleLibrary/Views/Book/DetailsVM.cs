using System.ComponentModel.DataAnnotations;

namespace LittleLibrary.Views.Book
{
    public class DetailsVM
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public string? Image { get; set; }
        

     }
}
