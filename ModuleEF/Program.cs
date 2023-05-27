using Microsoft.EntityFrameworkCore;
using ModuleEF;
class Program
{
    static ModuleEF.AppContext app;
    static UserRepository userRepository = new();
    static BookRepository bookRepository = new();
    static void Main(string[] strings)
    {
        /*bookRepository.ShowContent<Book>();
        var user = userRepository.LookForElementById<User>(true);
        userRepository.AddBookToBooks(user);
        */using(app = new())
        {
            var users = app.Users.Include(u => u.Books).ToList();

            foreach(var user in users)
            {
                if (user.Books.Any())
                {
                    Console.WriteLine($"Книги {user.Name}:");
                    foreach (var book in user.Books)
                    {
                        Console.WriteLine("\t\t" + book.Name);
                    }
                }
            }
        }
        Console.ReadLine();
    }
}