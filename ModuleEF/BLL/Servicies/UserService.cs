using ModuleEF.DAL.Repositories;
using ModuleEF.BLL.Models;

namespace ModuleEF.BLL.Servicies
{
    public class UserService
    {
        private UserRepository _userRepository = new();
        private BookRepository _bookRepository = new();
        private BookService _bookService = new();

        public void AddUsers()
        {
            _userRepository.AddItemToDB<User>();
        }

        public void UpdateUsers()
        {
            _userRepository.UpdateItemById();
        }

        public void DeleteUsers()
        {
            _userRepository.RemoveItemById<User>();
        }

        public User GetUserById()
        {
            var user = _userRepository.LookForElementById<User>();
            return user;
        }

        public void FindAll()
        {
            _userRepository.ShowContent<User>();
        }

        public void GiveBookToUser()
        {
            _bookService.GiveABookToUser();
        }
    }
}
