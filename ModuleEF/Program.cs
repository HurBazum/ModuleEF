using Microsoft.EntityFrameworkCore;
using ModuleEF.DAL.Repositories;

class Program
{
    static ModuleEF.DAL.DB.AppContext app;
    static UserRepository userRepository = new();
    static BookRepository bookRepository = new();
    static void Main(string[] strings)
    {
        Console.ReadLine();
    }
}