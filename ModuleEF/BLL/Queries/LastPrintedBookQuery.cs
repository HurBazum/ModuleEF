using AppContext = ModuleEF.DAL.DB.AppContext;

namespace ModuleEF.BLL.Queries
{
    public class LastPrintedBookQuery
    {
        AppContext app;

        public void BookQuery()
        {
            using(app = new())
            {
                // несколько книг в один год
                var lastBook = app.Books.Where(x => x.PrintYear == app.Books.Max(x => x.PrintYear)).ToList();

                string message = (lastBook.Count() > 1) ? "Последние напечатанные книги:" : "Последняя напечатанная книга:";

                foreach (var book in lastBook)
                {
                    Console.WriteLine($"{book.Name} - {book.PrintYear}");
                }
            }
        }
    }
}