using ModuleEF;
class Program
{
    static ModuleEF.AppContext app;
    static UserRepository userRepository = new();
    static BookRepository bookRepository = new();
    static void Main(string[] strings)
    {
        userRepository.ShowContent<User>();
        userRepository.AddItemToDB<User>();
        userRepository.ShowContent<User>();
        bookRepository.AddItemToDB<Book>();
        userRepository.ShowContent<Book>();
        using (app = new())
        {
            var user = userRepository.LookForElementById<User>();
            bookRepository.ShowContent<Book>();
            var book = bookRepository.LookForElementById<Book>();
            user.Books.Add(book);
            app.SaveChanges();
        }
        Console.ReadLine();
    }
}