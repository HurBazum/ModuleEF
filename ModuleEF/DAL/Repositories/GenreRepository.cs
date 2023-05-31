using ModuleEF.BLL.Models;

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
            Console.WriteLine("Добавление жанра:");
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
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void AddGenreToBookMethod(Book book)
        {
            Console.WriteLine("Введите Id жанра:");
            using (db = new())
            {
                try
                {
                    var genre = LookForElementById<Genre>(true);

                    book.GenreId = genre.Id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
