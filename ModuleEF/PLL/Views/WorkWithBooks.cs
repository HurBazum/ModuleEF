using ModuleEF.BLL.Servicies;

namespace ModuleEF.PLL.Views
{
    public class WorkWithBooks
    {
        BookService bookService = new();
        public void ShowBooksOperations()
        {
            
            Console.WriteLine("1.Добавить книгу(несколько);\n" +
                "2.Удалить книгу;\n" +
                "3.Показать все книги;\n" +
                "4.Показать конкретную книгу;\n" +
                "5.Изменить данные конкретной книги;\n" +
                "6.Добавить кол-во книги.\n" +
                "7.Показать все книги(а-я||я-а)\n" +
                "8.Показать все книги(сортировка по году издания);");

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
                case ConsoleKey.D7:
                    Console.Clear();
                    Console.WriteLine("Сортировка по имени. Укажите порядок:");
                    Console.WriteLine("1.По убыванию;\n2.По возрастанию;");
                    var keyTwo = Console.ReadKey().Key;
                    switch(keyTwo)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            bookService.SortContentByName();
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            bookService.SortContentByName(true);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Нельзя выбрать такую операцию!");
                            break;
                    }
                    break;
                case ConsoleKey.D8:
                    Console.Clear();
                    Console.WriteLine("Сортировка по году издания. Укажите порядок:");
                    Console.WriteLine("1.По убыванию;\n2.По возрастанию;");
                    var keyThree = Console.ReadKey().Key;
                    switch (keyThree)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            bookService.SortContentByPrintYear();
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            bookService.SortContentByPrintYear(true);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Нельзя выбрать такую операцию!");
                            break;
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Нельзя выбрать такую операцию!");
                    break;
            }
        }
    }
}