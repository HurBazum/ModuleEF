using Microsoft.EntityFrameworkCore;
using ModuleEF.BLL.Models;
using ModuleEF.DAL.Repositories;

class Program
{
    static ModuleEF.DAL.DB.AppContext app;
    static UserRepository userRepository = new();
    static BookRepository bookRepository = new();
    static GenreRepository genreRepository = new();
    static AuthorRepository authorRepository = new();
    static void Main(string[] strings)
    {
        using(app = new())
        {
            try
            {
                bookRepository.AddItemToDB<Book>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.ReadLine();
    }
}