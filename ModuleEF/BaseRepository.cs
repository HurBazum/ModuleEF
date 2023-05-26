using Microsoft.EntityFrameworkCore;
namespace ModuleEF
{
    public delegate T Del<T>(bool result) where T : DB_Entity;
    public class BaseRepository
    {
        protected AppContext db;

        protected Del<DB_Entity> del;

        public BaseRepository()
        {
            del = LookForElementById<DB_Entity>;
        }
        public void ShowContent<T>() where T : DB_Entity
        {
            using(db = new())
            {
                foreach(var item in db.Set<T>()) 
                {
                    Console.WriteLine(item.ToString());
                }
            };
        }

        public T LookForElementById<T>(bool show = false) where T : DB_Entity
        {
            T item = null;
            string elementName = (item is User) ? "user" : "book";

            if (!show)
            {
                Console.WriteLine($"Поиск {elementName} по Id!");
            }

            using (db = new())
            {
                try
                {
                    Console.WriteLine("Введите ID:");
                    bool result = int.TryParse(Console.ReadLine(), out int id);
                    if (!result)
                    {
                        throw new FormatException();
                    }
                    if (result == true && (id > db.Set<T>().OrderBy(x => x.Id).Last().Id || id < db.Set<T>().First().Id))
                    {
                        throw new Exception($"{elementName} с таким Id  не существует в базе!");
                    }

                    item = db.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id)!;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };

            if (item != null && !show)
            {
                Console.WriteLine($"Найден {elementName}:");
                Console.WriteLine(item.ToString());
            }

            return item!;
        }

        public void RemoveItemById<T>() where T : DB_Entity
        {
            T item = (T)del.Invoke(true);
            string itemName = (item is User) ? "user" : "book";
            Console.WriteLine($"\t\tУдаление {itemName} по Id!");

            if (item != null)
            {
                using (db = new())
                {
                    var deletedItem = item;
                    db.Set<T>().Remove(item);
                    db.SaveChanges();
                    Console.WriteLine($"{itemName} {deletedItem} был удалён!");
                };
            }
        }

        public void AddItemToDB<T>() where T : DB_Entity
        {

        }
    }
}