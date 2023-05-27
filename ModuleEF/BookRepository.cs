namespace ModuleEF
{
    public sealed class BookRepository : BaseRepository
    {
        public BookRepository() : base()
        {
            lookingDelegate = LookForElementById<Book>;
            creationDelegate = CreateItem;
        }

        protected override Book CreateItem()
        { 
            Console.WriteLine("Добавление книги:");
            Book book = new Book();
            
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
    }
}