using ModuleEF.DAL.Repositories;
using ModuleEF.BLL.Models;

namespace ModuleEF.BLL.Servicies
{
    public class AuthorService
    {
        private AuthorRepository _authorRepository = new();

        public void CreateSomeGenres()
        {
            _authorRepository.AddItemToDB<Author>();
        }

        public void ShowAvailableGenres()
        {
            _authorRepository.ShowContent<Author>();
        }
    }
}
