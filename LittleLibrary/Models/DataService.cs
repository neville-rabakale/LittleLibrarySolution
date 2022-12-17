using LittleLibrary.Views.Book;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LittleLibrary.Models
{
    public class DataService
    {
        private readonly IWebHostEnvironment environment;
        public DataService(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        //--Fake Database
        List<Book> books = new List<Book>
        {
            new Book{ Id = 0, Author = "Viktoria", Title = "Greatest Book",  Genre =2 ,Available = false},
            new Book{ Id = 2, Author = "Neville", Title = "Adventerous Book",  Genre =2, Available = false},
            new Book{ Id = 3, Author = "Nelson", Title = "Playful Book",  Genre =3, Available = false},
        };

        public void UploadImage(CreateVM createVM)
        {
            var filePath = Path.Combine(environment.WebRootPath, "Uploads", createVM.Image.FileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            createVM.Image.CopyTo(fileStream);

        }

        public CreateVM GetGenre()
        {
            return new CreateVM
            {
                Genre = new SelectListItem[]
                {
                    new SelectListItem {Value = "1", Text = "Ficton"},
                    new SelectListItem {Value = "2", Text = "Non-Ficton"},
                    new SelectListItem {Value = "3", Text = "Children"},
                }
            };
        }
        
        public IndexVM[] GetAllBooks()
        {
            return books
                .Select( o => new IndexVM 
                {   
                    Author = o.Author, 
                    Title = o.Title, 
                    Genre= o.Genre, 
                    Available = o.Available,
                    HasImage = o.Image == null ? false : true
        })
                .ToArray();
        }

        public void AddBook(CreateVM createVM)
        {

            Book book = new Book();
            book.Id = books.Count + 1;
            book.Author = createVM.Author;
            book.Title = createVM.Title;
            book.Genre = createVM.GenreValues;
            book.Available = createVM.Available;
            book.Image = createVM.Image.FileName;

            books.Add(book);

        }
      
    }
}
