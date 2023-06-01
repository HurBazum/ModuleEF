using Appcontext = ModuleEF.DAL.DB.AppContext;

namespace ModuleEF.BLL.Queries
{
    public class NameAndAuthorBookQuery
    {
        Appcontext db;

        public bool BookQuery()
        {
            bool result = default;
            using(db = new())
            {
                Console.WriteLine("Введите имя автора(часть имени):");
                string authorName = Console.ReadLine();
                if(string.IsNullOrEmpty(authorName))
                {
                    Console.WriteLine("Введена пустая строка!");
                }

                Console.WriteLine("Введите название книги: ");
                string bookName = Console.ReadLine();
                if(string.IsNullOrEmpty(bookName))
                {
                    Console.WriteLine("Введена пустая строка!");
                }

                var query = from book in db.Books
                            join author in db.Authors on book.AuthorId equals author.Id
                            where book.Name == bookName
                            where author.Name.Contains(authorName!)
                            select (new { name = book.Name, author = author.Name });

                if(query.Count() > 0 )
                {
                    result = true;
                }

                return result;
            }
        }
    }
}
