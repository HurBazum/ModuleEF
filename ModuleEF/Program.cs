using Microsoft.EntityFrameworkCore;
using ModuleEF.BLL.Models;
using ModuleEF.BLL.Servicies;
using ModuleEF.DAL.Repositories;
using ModuleEF.PLL.Queries;

class Program
{
    static ModuleEF.DAL.DB.AppContext app;
    static AuthorService authorService = new();
    static BookService bookService = new();
    static GenreService genreService = new();
    static UserService userService = new();
    static GenrePrintQuery gpQuery = new();
    static GetAuthorBookQuery gabQuery = new();
    static void Main(string[] strings)
    {
        bookService.FindAll();
        Console.WriteLine();

        //gpQuery.QueryBook();
        gabQuery.QueryBook();

        Console.ReadLine();
    }
}