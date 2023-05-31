using Microsoft.IdentityModel.Tokens;
using ModuleEF.DAL.DB;

namespace ModuleEF.PLL.Queries
{
    public class GenrePrintQuery
    {
        DAL.DB.AppContext app;
        public void QueryBook()
        {
            using (app = new())
            {
                try
                {
                    Console.WriteLine("Введите название жанра:");
                    string gen = Console.ReadLine();
                    if(gen.IsNullOrEmpty())
                    {
                        throw new Exception("Введена пустая строка!");
                    }

                    Console.WriteLine("Введите минимальное значение года издания:");
                    if(!int.TryParse(Console.ReadLine(), out int minYear))
                    {
                        throw new Exception("Неизвестное значение года!");
                    }

                    Console.WriteLine("Введите максимальное значение года издания:");
                    if(!int.TryParse(Console.ReadLine(), out int maxYear))
                    {
                        throw new Exception("Неизвестное значение года!");
                    }

                    var query = from book in app.Books
                                join g in app.Genres on book.GenreId equals g.Id
                                where g.Name == gen
                                where book.PrintYear > minYear
                                where book.PrintYear < maxYear
                                select (new { name = book.Name, gen = g.Name, print = book.PrintYear });

                    if(!query.Any())
                    {
                        throw new Exception("Подходящих данных не найдено!");
                    }
                    else
                    {
                        Console.WriteLine($"Найдено {query.Count()}:");
                        foreach (var q in query)
                        {
                            Console.WriteLine(q);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}