using ModuleEF.DAL.Repositories;
using ModuleEF.BLL.Models;

namespace ModuleEF.BLL.Servicies
{
    public class AuthorService
    {
        private AuthorRepository _authorRepository = new();

        public void AddAuthors()
        {
            _authorRepository.AddItemToDB<Author>();
        }

        public void FindAll()
        {
            _authorRepository.ShowContent<Author>();
        }

        public void FindOne()
        { 
            _authorRepository.LookForElementById<Author>(default);
        }

        public void DeleteAuthor()
        {
            _authorRepository.RemoveItemById<Author>();
        }

        public void UpdateAuthor()
        {
            _authorRepository.UpdateItemById();
        }
    }
}
