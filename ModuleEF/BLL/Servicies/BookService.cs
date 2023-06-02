using ModuleEF.BLL.Models;
using ModuleEF.DAL.Repositories;
using ModuleEF.PLL.Helpers;
using AppContext = ModuleEF.DAL.DB.AppContext;

namespace ModuleEF.BLL.Servicies
{
    public class BookService
    {
        private BookRepository _bookRepository = new();
        private UserRepository _userRepository = new();
        private AppContext app;

        // CRUD
        public void AddBooks()
        {
            _bookRepository.AddItemToDB<Book>();
        }

        public void UpdateBooks()
        {
            _bookRepository.UpdateItemById();
        }

        public void DeleteBooks()
        {
            _bookRepository.RemoveItemById<Book>();
        }

        public Book FindOne()
        {
            var book = _bookRepository.LookForElementById<Book>();
            return book!;
        }

        public void FindAll()
        {
            _bookRepository.ShowContent<Book>();
        }

        /// <summary>
        /// сортировка контента
        /// </summary>
        /// <param name="order">
        /// false - asc
        /// true - desc
        /// </param>
        public void SortContentByName(bool order = false)
        {
            using (app = new())
            {
                var sorted = order 
                    ? _bookRepository.GetContent<Book>().OrderBy(x => x.Name).ToList() 
                    : _bookRepository.GetContent<Book>().OrderByDescending(x => x.Name).ToList();
                
                foreach (var book in sorted)
                {
                    Console.WriteLine(book);
                }
            }
        }

        /// <summary>
        /// см. SortContentByName
        /// </summary>
        /// <param name="order"></param>
        public void SortContentByPrintYear(bool order = false)
        {
            using (app = new())
            {
                var sorted = order
                    ? _bookRepository.GetContent<Book>().OrderBy(x => x.PrintYear).ToList()
                    : _bookRepository.GetContent<Book>().OrderByDescending(x => x.PrintYear).ToList();

                foreach (var book in sorted)
                {
                    Console.WriteLine(book);
                }
            }
        }

        // Выдача, поступление и т.д.
        public void ChangeBookStock()
        {
            Console.WriteLine("Сколько книг прибыло?");
            try
            {
                if (int.TryParse(Console.ReadLine(), out int newStock))
                {
                    var book = _bookRepository.LookForElementById<Book>(true);
                    _bookRepository.ChangeBooksAmount(book, newStock);
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Print(ex.Message);
            }
        }

        public void GiveABookToUser()
        {
            var user = _userRepository.LookForElementById<User>(true);

            _userRepository.AddBookToUserBooks(user);
        }
    }
}
