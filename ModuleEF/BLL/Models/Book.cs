using ModuleEF.DAL.Entities;

namespace ModuleEF.BLL.Models
{
    public class Book : DB_Entity
    {
        public ushort PrintYear { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public int InStock { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public List<User> Users { get; set; } = new();
        public override string ToString()
        {
            return $"{Id,4}\t{Name,-25}\t{PrintYear}\t{GenreId}\t{AuthorId}\t{InStock}";
        }
    }
}