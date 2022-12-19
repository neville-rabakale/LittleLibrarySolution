using LittleLibrary.Models.Entities;
using LittleLibrary.Views.Book;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace LittleLibrary.Models
{
    public class DataService
    {
        private readonly IWebHostEnvironment environment;
        private readonly LittleLibraryContext context;

        public DataService(IWebHostEnvironment environment, LittleLibraryContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        //--Fake Database
        //List<Book> books = new List<Book>
        //{
        //    new Book{ Id = 0, Author = "Viktoria", Title = "Greatest Book",  Genre =2 ,Available = false},
        //    new Book{ Id = 2, Author = "Neville", Title = "Adventerous Book",  Genre =2, Available = false},
        //    new Book{ Id = 3, Author = "Nelson", Title = "Playful Book",  Genre =3, Available = false},
        //};

        public void UploadImage(CreateVM createVM)
        {
           // string fileName = Guid.NewGuid().ToString(); //to get a new unique file name
            var filePath = Path.Combine(environment.WebRootPath, @"images\books", createVM.Image.FileName);

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

        public static string GetGenreText(int value)
        {
            if (value == 1)
                return "Fiction";
            if (value == 2)
                return "Non-Fiction";            
            if (value == 3)
                return "Children";
            return "";
        }
        public IndexVM[] GetAllBooks()
        {
            return context.Books
                .Select( o => new IndexVM 
                {
                    Author = o.Author,
                    Title = o.Title, 
                    Genre= GetGenreText(o.Genre),
                    Available = o.Available,
                    Image = o.Image
                })
                .ToArray();
        }

        public void AddBook(CreateVM createVM)
        {
            Book book = new();
            UploadImage(createVM);
            var imagepath = @"images\books\"+createVM.Image.FileName;
            book.Author = createVM.Author;
            book.Title = createVM.Title;
            book.Genre = createVM.GenreValues;
            book.Available = createVM.Available;
            book.Image = imagepath;
            book.Description= createVM.Description; 

            context.Books.Add(book);
            context.SaveChanges();

        }
      
    }
}
