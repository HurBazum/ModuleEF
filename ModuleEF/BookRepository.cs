namespace ModuleEF
{
    public class BookRepository : BaseRepository
    {
        // private AppContext? db;
        public BookRepository()
        {
            del = LookForElementById<Book>;
        }
        public void AddBook()
        {
            var boook = CreateBook();
            using(db = new())
            {
                db.Books.Add(boook);
                db.SaveChanges();
            };
        }

        private Book CreateBook()
        {
            Console.WriteLine("Добавление книги:");
            Book book = new();
            Console.Write("Введите название книги: ");
            string bookName = Console.ReadLine()!;
            book.Name = bookName;
            Console.Write("Введите год издания: ");
            if(ushort.TryParse(Console.ReadLine(), out ushort bookPrintYear))
            {
                book.PrintYear = bookPrintYear;
            }

            return book;
        }

        public void ShowContent()
        {
            using (db = new())
            {
                foreach (var book in db.Books)
                {
                    Console.WriteLine(book.ToString());
                }
            };
        }
    }
}