using ModuleEF;
using System.Security.Principal;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

class Program
{
    //static ModuleEF.AppContext appContext = new();
    static UserRepository userRepository = new();
    static BookRepository bookRepository = new();
    static void Main(string[] strings)
    {
        //userRepository.ShowContent();
        //userRepository.CreateUser();
        //userRepository.UpdateUsersById();

        //userRepository.LookForUserById();
        //userRepository.RemoveUserById();
        //userRepository.ShowContent();

        //bookRepository.AddBook();
        //bookRepository.ShowContent();
        //bookRepository.ShowContent<Book>();
        //bookRepository.LookForElementById<Book>();
        //bookRepository.RemoveItemById<Book>();
        //bookRepository.AddItemToDB<Book>();
        //bookRepository.ShowContent<Book>();
        Console.WriteLine(bookRepository.creationDelegate.GetMethodInfo());
        Console.ReadLine();
    }

    /*static void AddUsers(params User[] users)
    {
        using (appContext = new())
        {
            if (users.Length > 1)
            {
                appContext.Users.AddRange(users);
                appContext.SaveChanges();
            }
            if(users.Length == 1)
            {
                appContext.Users.Add(users[0]);
                appContext.SaveChanges();
            }
        };
    }
    /// <summary>
    /// примерно . . .
    /// </summary>
    static void RemoveUsersById()
    {
        using(appContext = new())
        {
            Console.WriteLine("Введите ID(если несколько - через пробел):");
            string enter = Console.ReadLine();
            //нужна проверка на соответсвие строки шаблону число-пробел-число-пробел etc.
            var transformEnter = enter.Split(" ");
            for(int i = 0; i < transformEnter.Length; i++)
            {
                appContext.Remove(appContext.Users.First(x => x.Id == int.Parse(transformEnter[i])));
            }

            appContext.SaveChanges();
        };
    }
    static void ShowContent()
    {
        using (appContext = new())
        {
            foreach (var item in appContext.Users)
            {
                Console.WriteLine(item.ToString());
            }
        };
    }
    static List<User> GetAdmins()
    {
        List<User> admins = new();
        using (appContext = new())
        {
            admins = appContext.Users.Where(x => x.Role == "Admin").ToList();
        };

        return admins;
    }
    static void SetOrChangeEmailById()
    {
        using (appContext = new())
        {
            Console.Write("Введите ID user'а, e-mail которого хотите изменить: ");
            try 
            {
                bool result = int.TryParse(Console.ReadLine(), out int id);
                if(!result)
                {
                    throw new FormatException("Нужно ввести целое число!");
                }

                if(id > appContext.Users.OrderBy(i => i.Id).Last().Id || id < appContext.Users.OrderBy(i => i.Id).First().Id)
                {
                    throw new Exception("Элемента с таким Id  не существует в базе!");
                }
                var user = appContext.Users.FirstOrDefault(x => x.Id == id);

                //необходим regexp
                Console.Write("Введите e-mail: ");
                string email = Console.ReadLine();
                if(string.IsNullOrEmpty(email))
                {
                    throw new ArgumentNullException($"Введена пустая строка!");
                }
                user.Email = email;

                appContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        };
    }*/
}