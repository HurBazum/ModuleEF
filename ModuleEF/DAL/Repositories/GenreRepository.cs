using ModuleEF.BLL.Models;
using ModuleEF.PLL.Helpers;

namespace ModuleEF.DAL.Repositories
{
    public class GenreRepository : BaseRepository
    {
        public GenreRepository() : base ()
        {
            lookingDelegate = LookForElementById<Genre>;
            creationDelegate = CreateItem;
        }

        protected override Genre CreateItem()
        {
            Console.WriteLine("\t\tДобавление жанра");
            var item = new Genre();
            try
            {
                CreateItemNameMethod(item);
            }
            catch (Exception ex)
            {
                item = null;
                Console.WriteLine(ex.Message);
            }

            return item!;
        }

        public override void UpdateItemById()
        {
            var genre = (Genre)lookingDelegate.Invoke(default);
            if (genre != null)
            {
                using(db = new())
                {
                    try
                    {
                        CreateItemNameMethod(genre);
                        db.Genres.Update(genre);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage.Print(ex.Message);
                    }
                }
            }
        }

        public void AddGenreToBookMethod(Book book)
        {
            using (db = new())
            {
                try
                {
                    var genre = LookForElementById<Genre>(true);

                    book.GenreId = genre.Id;
                }
                catch (Exception ex)
                {
                    ErrorMessage.Print(ex.Message);
                }
            }
        }
    }
}
