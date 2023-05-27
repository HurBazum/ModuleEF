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
            Book book = new();
            try
            {
                CreateItemNameMethod(book);
                CreatePrintYearMethod(book);
            }
            catch (Exception ex)
            {
                book = null;
                Console.WriteLine(ex.Message);
            }

            return book!;
        }

        public override void UpdateItemById()
        {
            Console.WriteLine("\t\tИзненеие книги по Id!");
            var book = (Book)lookingDelegate.Invoke(default);

            if (book != null)
            {
                using (db = new())
                {
                    try
                    {
                        Console.WriteLine("Что вы хотите изменить: \n1.Название\n2.Год издания");

                        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice < 4)
                        {
                            switch (choice)
                            {
                                case 1:
                                    CreateItemNameMethod(book);
                                    break;
                                case 2:
                                    CreatePrintYearMethod(book);
                                    break;
                            }

                            db.Books.Update(book);
                            db.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Операция под таким номером недоступна!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                };
            }
        }

        private void CreatePrintYearMethod(Book book)
        {
            string noYear = !(book.PrintYear == default) ? " новый " : " ";
            Console.Write($"Введите{noYear}год издания: ");
            if (ushort.TryParse(Console.ReadLine(), out ushort bookPrintYear) && bookPrintYear > 0)
            {
                book.PrintYear = bookPrintYear;
            }
            else
            {
                throw new Exception("Нужно ввести целое число больше ноля!");
            }
        }
    }
}