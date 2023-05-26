using Microsoft.EntityFrameworkCore;

namespace ModuleEF
{
    public class AppContext : DbContext
    {
        //объекты таблицы Users
        public DbSet<User> Users { get; set; }
        //объекты таблицы Books
        public DbSet<Book> Books { get; set; }

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