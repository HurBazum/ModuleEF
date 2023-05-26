namespace ModuleEF
{
    public class Book : DB_Entity
    {
        public ushort PrintYear { get; set; }

        public override string ToString()
        {
            return $"{Id, 4}\t{Name, -25}\t{PrintYear}";
        }
    }
}