using System.ComponentModel.DataAnnotations;

namespace LittleLibrary.Views.Book
{
    public class BookVM
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public bool Available { get; set; }
        public bool HasImage { get; set; }
        

     }
}
