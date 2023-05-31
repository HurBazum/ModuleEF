using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModuleEF.BLL.Servicies;

namespace ModuleEF.PLL.Views
{
    public class Library
    {
        WorkWithQ workWithQ = new();
        WorkWithUsers workWithUsers = new();
        WorkWithAuthors workWithAuthors = new();
        WorkWithBooks workWithBooks = new();
        WorkWithGenres workWithGenres = new();
        public void CreateLibrary(
            UserService userService, 
            BookService bookService, 
            GenreService genreService, 
            AuthorService authorService)
        {
            Console.WriteLine("Добавим пользователей!");
            userService.AddUsers();
            Console.Clear();
            Console.WriteLine("Добавим возможных авторов книг!");
            authorService.AddAuthors();
            Console.Clear();
            Console.WriteLine("Добавим возможные жанры книг!");
            genreService.AddGenres();
            Console.Clear();
            Console.WriteLine("Наконец добавим книги!");
            bookService.AddBooks();
            Console.Clear();
        }

        public void MainMenu()
        {

        }

        public void WorkMenu()
        {
            Console.WriteLine("1.Действия с пользователями;\n2.Действия с книгами;\n3.Действия с жанрами;\n4.Действия с авторами;\n5.Запросы;");
            var key = Console.ReadKey().Key;
            switch(key)
            {
                case ConsoleKey.D1:
                    workWithUsers.ShowUserOperations();
                    break; 
                case ConsoleKey.D2:
                    workWithBooks.ShowBooksOperations();
                    break; 
                case ConsoleKey.D3: 
                    workWithGenres.ShowGenresOperations();
                    break; 
                case ConsoleKey.D4: 
                    workWithAuthors.ShowAuthorOperations();
                    break; 
                case ConsoleKey.D5:
                    Console.Clear();
                    workWithQ.ShowQ();
                    break;
            }
        }
    }
}