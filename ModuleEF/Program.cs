using ModuleEF;
class Program
{
    static UserRepository userRepository = new();
    static BookRepository bookRepository = new();
    static void Main(string[] strings)
    {
        //userRepository.ShowContent();
        //userRepository.CreateUser();
        //userRepository.UpdateUsersById();

        //userRepository.LookForUserById();
        //userRepository.RemoveUserById();
        //userRepository.ShowContent();

        //bookRepository.AddBook();
        //bookRepository.ShowContent();
        bookRepository.ShowContent<Book>();
        //bookRepository.LookForElementById<Book>();
        //bookRepository.AddItemToDB<Book>();
        //bookRepository.ShowContent<Book>();
        //bookRepository.RemoveItemById<Book>();
        //bookRepository.ShowContent<Book>();
        bookRepository.UpdateItemById();
        bookRepository.ShowContent<Book>();
        Console.ReadLine();
    }
}