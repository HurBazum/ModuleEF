﻿namespace ModuleEF
{
    public class User : DB_Entity
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; }
        public List<Book> Books { get; set; }

        public User() 
        {
            Books = new();
        }
        public override string ToString()
        {
            return $"{Id, 4}\t{Name, -10}\t{Email, -25}\t{Role}";
        }
    }
}