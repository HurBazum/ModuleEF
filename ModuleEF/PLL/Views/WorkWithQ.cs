using ModuleEF.BLL.Queries;
using ModuleEF.PLL.Helpers;
using ModuleEF.PLL.Queries;
using System.ComponentModel.DataAnnotations;

namespace ModuleEF.PLL.Views
{
    public class WorkWithQ
    {
        GenrePrintQuery gpQuery = new();
        GetAuthorBookQuery gabQuery = new();
        UserBookUserQuery ubuQuery = new();
        LastPrintedBookQuery lpbQuery = new();
        NameAndAuthorBookQuery naabQuery = new();
        public void ShowQ()
        {
            Console.WriteLine("1.Выбрать книги по жанру и годам;\n" +
                "2.Выбрать книги по жанру;\n" +
                "3.Выбрать книги определённого автора;\n" +
                "4.Показать книги определённого пользователя;\n" +
                "5.Показать последние напечатанные книги;\n" +
                "6.Узнать есть ли опр. книга опр. автора в библиотеке.");

            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine($"1.Указать годы;\n2.Годы изданий не важны;");
                    var yearKey = Console.ReadKey().Key;
                    switch (yearKey)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            gpQuery.QueryBook(true);
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            gpQuery.QueryBook();
                            break;
                        default:
                            Console.Clear();
                            ErrorMessage.Print("Неизвестная операция!");
                            break;
                    }
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    gpQuery.QueryBook();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    gabQuery.QueryBook();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    ubuQuery.BookQuery();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    lpbQuery.BookQuery();
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    Console.WriteLine(naabQuery.BookQuery());
                    break;
                default:
                    Console.Clear();
                    ErrorMessage.Print("Нельзя выбрать такую операцию!");
                    break;
            }

        }
    }
}