namespace ModuleEF.BLL.Models
{
    public class Book : DB_Entity
    {
        public ushort PrintYear { get; set; }
        public List<User> Users { get; set; } = new();
        public override string ToString()
        {
            return $"{Id,4}\t{Name,-25}\t{PrintYear}";
        }
    }
}