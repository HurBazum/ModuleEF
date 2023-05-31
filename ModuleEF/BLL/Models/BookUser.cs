using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuleEF.BLL.Models
{
    public class BookUser
    {
        public int Id { get; set; }
        public int BooksId { get; set; }
        [ForeignKey("BooksId ")]
        public Book Book { get; set; } = null!;

        public int UsersId { get; set; }

        [ForeignKey("UsersId ")]
        public User User { get; set; } = null!;
    }
}
