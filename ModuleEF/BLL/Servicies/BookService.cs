using ModuleEF.BLL.Models;
using ModuleEF.DAL.Repositories;

namespace ModuleEF.BLL.Servicies
{
    public class BookService
    {
        private BookRepository _bookRepository = new();
        private UserRepository _userRepository = new();

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

        public Book GetBookById(int id)
        {
            var book = _bookRepository.LookForElementById<Book>();
            return book!;
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
                Console.WriteLine(ex.Message);
            }
        }

        public void GiveABookToUser()
        {
            var user = _userRepository.LookForElementById<User>(true);

            var book = _bookRepository.LookForElementById<Book>(true);

            _userRepository.AddBookToUserBooks(user);

            _bookRepository.ChangeBooksAmount(book);
        }
    }
}
