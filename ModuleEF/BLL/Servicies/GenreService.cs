using ModuleEF.DAL.Repositories;
using ModuleEF.BLL.Models;

namespace ModuleEF.BLL.Servicies
{
    public class GenreService
    {
        private GenreRepository _genreRepository = new();

        public void AddGenres()
        {
            _genreRepository.AddItemToDB<Genre>();
        }

        public void FindAll()
        {
            _genreRepository.ShowContent<Genre>();
        }

        public void DeleteGenres()
        {
            _genreRepository.RemoveItemById<Genre>();
        }

        public void UpdateGenre()
        {
            _genreRepository.UpdateItemById();
        }
    }
}