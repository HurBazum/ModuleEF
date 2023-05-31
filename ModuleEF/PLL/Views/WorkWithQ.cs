﻿using ModuleEF.PLL.Queries;
namespace ModuleEF.PLL.Views
{
    public class WorkWithQ
    {
        GenrePrintQuery gpQuery = new();
        GetAuthorBookQuery gabQuery = new();
        UserBookQuery ubQuery = new();
        public void ShowQ()
        {
            Console.WriteLine("1.Выбрать книги по жанру и годам;\n" +
                "2.Выбрать книги по жанру;\n" +
                "3.Выбрать книги определённого автора;\n" +
                "4.Показать книги определённого пользователя;");

            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    gpQuery.QueryBook(true);
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
                    ubQuery.BookQuery();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Нельзя выбрать такую операцию!");
                    break;
            }

        }
    }
}