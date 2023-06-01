using AppContext = ModuleEF.DAL.DB.AppContext;
using Microsoft.IdentityModel.Tokens;

namespace ModuleEF.BLL.Queries
{
    public class GetAuthorBookQuery
    {
        AppContext app;

        public void QueryBook()
        {
            using (app = new())
            {
                try
                {
                    Console.WriteLine("Введите фамилию автора(часть фамилии):");
                    string lastName = Console.ReadLine();
                    if (lastName.IsNullOrEmpty())
                    {
                        throw new Exception("Введена пустая строка!");
                    }

                    var query = from b in app.Books
                                join a in app.Authors on b.AuthorId equals a.Id
                                where a.Name.Contains(lastName)
                                select (new { bookName = b.Name, auth = a.Name });

                    if (!query.Any())
                    {
                        throw new Exception("Подходящих данных не найдено!");
                    }
                    else
                    {
                        Console.WriteLine($"Найдено {query.Count()}:");
                        foreach (var item in query)
                        {
                            Console.WriteLine(item);
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