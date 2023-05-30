using Microsoft.EntityFrameworkCore;
using ModuleEF.BLL.Models;

namespace ModuleEF.DAL.DB
{
    public class AppContext : DbContext
    {
        //объекты таблицы Users
        public DbSet<User> Users { get; set; }
        //объекты таблицы Books
        public DbSet<Book> Books { get; set; }

        //public DbSet<Genre> Genres { get; set; }

        //public DbSet<Author> Author { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@$"{ConnectionString.GetConnectionString}");
        }
    }
}