using Microsoft.EntityFrameworkCore;
using ModuleEF.BLL.Models;
using ModuleEF.DAL.DB;
using ModuleEF.DAL.Entities;
using ModuleEF.PLL.Helpers;
using AppContext = ModuleEF.DAL.DB.AppContext;

namespace ModuleEF.DAL.Repositories
{
    // возможно, лишнее
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
            using (db = new())
            {
                foreach (var item in db.Set<T>())
                {
                    Console.WriteLine(item.ToString());
                }
            };
        }

        public List<T> GetContent<T>() where T : DB_Entity
        {
            List<T> content = new();
            using(db = new())
            {
                foreach(var item in db.Set<T>())
                {
                    content.Add(item);
                }
            }
            return content;
        }

        public T LookForElementById<T>(bool show = false) where T : DB_Entity
        {
            T item = (T)Activator.CreateInstance(typeof(T))!;
            
            string elementName = item.GetType().Name;

            if (!show)
            {
                Console.WriteLine($"Поиск {elementName} по Id!");
            }

            using (db = new())
            {
                try
                {
                    Console.Write($"Введите ID {elementName}: ");
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
                    ErrorMessage.Print(ex.Message);
                }
            };

            if (item != null && show == false)
            {
                Console.Write($"Найден {elementName}: ");
                Console.WriteLine(item.ToString());
            }

            return item!;
        }

        public void RemoveItemById<T>() where T : DB_Entity
        {
            T item = (T)lookingDelegate.Invoke(true);
            string itemName = item.GetType().Name;
            Console.WriteLine($"\t\tУдаление {itemName} по Id!");

            if (item != null)
            {
                using (db = new())
                {
                    var deletedItem = item;
                    db.Set<T>().Remove(item);
                    db.SaveChanges();
                    SuccessMessage.Print($"{itemName} {deletedItem} был удалён!");
                };
            }
        }

        public void AddItemToDB<T>() where T : DB_Entity
        {
            T[] values = new T[0];
            string itemName = ((T)Activator.CreateInstance(typeof(T))!).GetType().Name;
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
                            if (values[i] == null)
                            {
                                throw new ArgumentNullException();
                            }

                            db.Set<T>().Add(values[i]);
                            SuccessMessage.Print($"{itemName} {values[i].Name} успешно добавлен в БД!");
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage.Print(ex.Message);
                    }
                };
            }
        }

        protected void CreateItemNameMethod<T>(T entity) where T : DB_Entity
        {
            var itemName = typeof(T).Name;
            string noName = !string.IsNullOrEmpty(entity.Name) ? " новое " : " ";
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