using ModuleEF.BLL.Servicies;

namespace ModuleEF.PLL.Views
{
    public class WorkWithBooks
    {
        BookService bookService = new();
        public void ShowBooksOperations()
        {
            Console.WriteLine("1.Добавить книгу(несколько);" +
                "2.Удалить книгу;" +
                "3.Показать все книги;" +
                "4.Показать конкретную книгу;" +
                "5.Изменить данные конкретной книги;" +
                "6.Добавить книгу пользователю;");

            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    bookService.AddBooks();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    bookService.DeleteBooks();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    bookService.FindAll();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    bookService.FindOne();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    bookService.UpdateBooks();
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    bookService.ChangeBookStock();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Нельзя выбрать такую операцию!");
                    break;
            }
    }
}