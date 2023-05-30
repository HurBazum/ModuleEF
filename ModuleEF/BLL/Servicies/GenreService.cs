using ModuleEF.DAL.Repositories;
using ModuleEF.BLL.Models;

namespace ModuleEF.BLL.Servicies
{
    public class GenreService
    {
        private GenreRepository _genreRepository = new();

        public void CreateSomeGenres()
        {
            _genreRepository.AddItemToDB<Genre>();
        }

        public void ShowAvailableGenres()
        {
            _genreRepository.ShowContent<Genre>();
        }
    }
}