using ModuleEF.DAL.Entities;

namespace ModuleEF.BLL.Models
{
    public class User : DB_Entity
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; }
        public List<Book> Books { get; set; } = new();

        public override string ToString()
        {
            return $"{Id,4}\t{Name,-10}\t{Email,-25}\t{Role}";
        }
    }
}