using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModuleEF.DAL.Repositories;
using AppContext = ModuleEF.DAL.DB.AppContext;
using ModuleEF.BLL.Models;

namespace ModuleEF.PLL.Queries
{
    public class UserBookUserQuery
    {
        AppContext app;
        UserRepository userRepository = new();

        public void BookQuery()
        {
            var user = userRepository.LookForElementById<User>(true);

            using(app = new())
            {
                // изначально искались все пользователи с кол-вом книг > 0,
                // поэтому такая структура
                // ******************************************************* //
                // запрос списков книг на руках у пользователя
                var query = from _user in app.Users.Include(u => u.Books)
                            where _user.Id == user.Id
                            select _user.Books;

                // запрос имени пользователя
                var helpQuery = from _user in app.Users
                                where _user.Name == user.Name
                                select _user.Name;

                // соединение результатов запросов в словарь
                var unionQueries = helpQuery.GroupBy(x=>x).ToDictionary(x=>x.Key, y => query.SelectMany(c=>c));


                foreach (var _user in unionQueries.Keys)
                {
                    Console.WriteLine($"Книги пользователя {_user}: ");
                    foreach(var value in unionQueries.Values)
                    {
                        Console.WriteLine(value.Count());
                        foreach (var book in value)
                        {
                            Console.WriteLine(book.Name + " " + book.PrintYear);
                        }
                    }
                }
            }
        }
    }
}