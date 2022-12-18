using System.ComponentModel.DataAnnotations;

namespace LittleLibrary.Views.Book
{
    public class IndexVM
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string Genre { get; set; }
        public bool Available { get; set; }
        public string? Image { get; set; }
        

     }
}
