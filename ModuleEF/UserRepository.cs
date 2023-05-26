using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace ModuleEF
{
    enum RoleEnum
    {
        Admin,
        User
    }

    public delegate User Del(bool result);
    public class UserRepository
    {
        private AppContext db;

        public Del delegatedMethod;

        public UserRepository()
        {
            delegatedMethod = LookForUserById;
        }

        public void AddUser(params User[] users)
        {
            using(db = new())
            {
                if (users.Length == 1)
                {
                    db.Users.Add(users[0]);
                }
                if(users.Length > 1) 
                {
                    db.AddRange(users);
                }
                db.SaveChanges();
            };
        }

        private User CreateUser()
        {
            User user = new();

            try
            {
                CreateUserNameMethod(user);
                CreateUserRoleMethod(user);
            }
            catch (Exception ex)
            {
                user = null;
                Console.WriteLine(ex.Message);
            }

            return user!;
        }

        public void ShowContent()
        {
            using(db = new())
            {
                foreach(var user in db.Users)
                {
                    Console.WriteLine(user.ToString());
                }

                db.SaveChanges();
            };
        }

        public void RemoveUserById()
        {
            Console.WriteLine("\t\tУдаление юзера по Id!");
            var user = delegatedMethod.Invoke(true);

            if (user != null)
            {
                using (db = new())
                {
                    var deletedUser = user;
                    db.Users.Remove(user);
                    db.SaveChanges();
                    Console.WriteLine($"user {deletedUser} был удалён!");
                };
            }
        }
        /// <summary>
        /// Метод поиска юзера по Id, используется в методах RemoveUserById и UpdateUserById
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public User LookForUserById(bool show = false)
        {
            if(!show)
            {
                Console.WriteLine("Поиск пользователя по Id!");
            }

            User user = null;

            using (db = new())
            {
                try
                {
                    Console.WriteLine("Введите ID:");
                    bool result = int.TryParse(Console.ReadLine(), out int id);
                    if(!result)
                    {
                        throw new FormatException();
                    }
                    if (result == true && (id > db.Users.OrderBy(x => x.Id).Last().Id || id < db.Users.First().Id))
                    {
                        throw new Exception("Элемента с таким Id  не существует в базе!");
                    }

                    user = db.Users.AsNoTracking().FirstOrDefault(x => x.Id == id)!;
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };

            if (user != null && !show)
            {
                Console.WriteLine("Найден пользователь:");
                Console.WriteLine(user.ToString());
            }

            return user!;
        }

        public void UpdateUsersById()
        {
            Console.WriteLine("\t\tИзненеие юзера по Id!");
            var user = delegatedMethod.Invoke(true);

            if (user != null)
            {
                using (db = new())
                {
                    try
                    {
                        Console.WriteLine("Что вы хотите изменить: \n1.Имя\n2.E-mail\n3.Роль\n");

                        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice < 4)
                        {
                            switch (choice)
                            {
                                case 1:
                                    CreateUserNameMethod(user);
                                    break;
                                case 2:
                                    CreateUserEmailMethod(user);
                                    break;
                                case 3:
                                    CreateUserRoleMethod(user);
                                    break;
                            }

                            db.Users.Update(user);
                            db.SaveChanges();
                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                };
            }
        }

        /// <summary>
        /// Методы для проверки ввода текстовых значений для св-в класса User
        /// </summary>
        private void CreateUserEmailMethod(User user) 
        {
            Console.Write("Введите новый e-mail: ");
            string newEmail = Console.ReadLine();
            if (string.IsNullOrEmpty(newEmail))
            {
                throw new ArgumentNullException($"Введена пустая строка!");
            }
            else
            {
                user.Email = newEmail;
            }
        }

        private void CreateUserNameMethod(User user)
        {
            Console.Write("Введите новое имя: ");
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                throw new ArgumentNullException($"Введена пустая строка!");
            }
            else
            {
                user.Name = newName;
            }
        }

        private void CreateUserRoleMethod(User user)
        {
            Console.Write("Введите роль(admin, user): ");
            string newRole = Console.ReadLine();
            if (string.IsNullOrEmpty(newRole))
            {
                throw new ArgumentNullException($"Введена пустая строка!");
            }
            newRole = string.Join("", char.ToUpper(newRole.First()), newRole.Substring(1).ToLowerInvariant());
            if (!Enum.IsDefined(typeof(RoleEnum), newRole))
            {
                throw new ArgumentNullException("Такой роли не существует!");
            }
            user.Role = newRole;
        }
    }
}