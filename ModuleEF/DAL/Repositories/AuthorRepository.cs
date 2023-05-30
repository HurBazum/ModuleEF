using ModuleEF.BLL.Models;
using ModuleEF.DAL.Entities;

namespace ModuleEF.DAL.Repositories
{
    public class AuthorRepository : BaseRepository
    {
        public AuthorRepository() :base()
        {
            lookingDelegate = LookForElementById<Author>;
            creationDelegate = CreateItem;
        }

        protected override Author CreateItem()
        {
            Console.WriteLine("Добавление автора:");
            var author = new Author();
            try
            {
                CreateItemNameMethod(author);
            }
            catch (Exception ex)
            {
                author = null;
                Console.WriteLine(ex.Message);
            }
            return author!;
        }

        public void AddAuthorToBookMethod(Book book)
        {
            Console.WriteLine("Введите Id автора:");
            using (db = new())
            {
                try
                {
                    var author = LookForElementById<Author>(true);

                    book.AuthorId = author.Id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
