using ModuleEF.DAL.Entities;

namespace ModuleEF.BLL.Models
{
    public class Genre : DB_Entity
    {
        List<Book> Books { get; set; } = new();
        public override string ToString()
        {
            return $"{Id,4}\t{Name,-25}";
        }
    }
}