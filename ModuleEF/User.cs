namespace ModuleEF
{
    public class User : DB_Entity
    {
        public string Name { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; }

        public override string ToString()
        {
            return $"{Id, 4}\t{Name, -10}\t{Email, -25}\t{Role}";
        }
    }
}