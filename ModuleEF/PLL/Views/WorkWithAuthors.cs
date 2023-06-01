using ModuleEF.BLL.Servicies;

namespace ModuleEF.PLL.Views
{
    public class WorkWithAuthors
    {
        AuthorService authorService = new();
        public void ShowAuthorOperations()
        {
            Console.WriteLine("1.Добавить автора;\n" +
                "2.Посмотреть имеющихся авторов;\n" +
                "3.Посмотреть конкретного автора;\n" +
                "4.Изменить данные автора;\n" +
                "5.Удалить автора.");

            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    authorService.AddAuthors();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    authorService.FindAll();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    authorService.FindOne();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    authorService.UpdateAuthor();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    authorService.DeleteAuthor();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Нельзя выбрать такую операцию!");
                    break;
            }
        }
    }
}