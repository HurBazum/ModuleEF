using Microsoft.EntityFrameworkCore;
namespace ModuleEF
{
    public delegate T LookingDelegate<T>(bool result) where T : DB_Entity;
    public delegate T CreationDelegate<T>() where T : DB_Entity;
    public class BaseRepository
    {
        protected AppContext? db;

        protected LookingDelegate<DB_Entity> lookingDelegate;
        public CreationDelegate<DB_Entity> creationDelegate;

        public BaseRepository()
        {
            lookingDelegate = LookForElementById<DB_Entity>;
            creationDelegate = CreateItem;
        }

        // Общие методы для потомков
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
            T item = (T)lookingDelegate.Invoke(true);
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
            T[] values = new T[0];
            string itemName = (values is User[]) ? "user" : "book";
            Console.WriteLine($"Сколько {itemName}" + "s хотите добавить?");
            if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
            {
                values = new T[count];
                using (db = new())
                {
                    try
                    {
                        for (int i = 0; i < count; i++)
                        {
                            values[i] = (T)creationDelegate.Invoke();
                        }

                        if (count == 1)
                        {
                            db.Set<T>().Add(values[0]);
                        }
                        else
                        {
                            db.Set<T>().AddRange(values);
                        }
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                };
            }
        }

        protected void CreateItemNameMethod<T>(T entity) where T : DB_Entity
        {
            var itemName = typeof(T).Name;
            string noName = (!string.IsNullOrEmpty(entity.Name)) ? " новое " : " ";
            Console.Write($"Введите{noName}имя {itemName}: ");
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                throw new ArgumentNullException($"Введена пустая строка!");
            }
            else
            {
                entity.Name = newName;
            }
        }

        // Виртуальные
        protected virtual DB_Entity CreateItem()
        {
            return new DB_Entity();
        }
        public virtual void UpdateItemById()
        {

        }
    }
}