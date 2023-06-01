﻿using Microsoft.EntityFrameworkCore;
using ModuleEF.BLL.Models;
using System.Security.Cryptography.X509Certificates;

namespace ModuleEF.DAL.Repositories
{
    enum RoleEnum
    {
        Admin,
        User
    }

    public class UserRepository : BaseRepository
    {
        private BookRepository bookRepository = new();
        public UserRepository() : base()
        {
            lookingDelegate = LookForElementById<User>;
            creationDelegate = CreateItem;
        }
        protected override User CreateItem()
        {
            User user = new();

            try
            {
                CreateItemNameMethod(user);
                CreateUserRoleMethod(user);
            }
            catch (Exception ex)
            {
                user = null;
                Console.WriteLine(ex.Message);
            }

            return user!;
        }

        public void UpdateUsersById()
        {
            Console.WriteLine("\t\tИзненеие юзера по Id!");
            var user = (User)lookingDelegate.Invoke(true);

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
                                    CreateItemNameMethod(user);
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
                            throw new Exception("Операция под таким номером недоступна!");
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
        /// выдача книги
        /// </summary>
        /// <param name="user"></param>
        public void AddBookToUserBooks(User user)
        {
            var book = LookForElementById<Book>(true);

            using (db = new())
            {
                var query = from u in db.Users.Include(u => u.Books)
                            where u.Name == user.Name
                            select u.Books;
                try
                {
                    if (!query.Any(x => x.Contains(book)))
                    {
                        user.Books.Add(book);
                        bookRepository.AddUserToBook(user, book);
                        db.Users.Update(user);
                        db.SaveChanges();
                        Console.WriteLine($"Выдача книги {book.Name} пользователю {user.Name} выполнена успешно!");
                    }
                    else
                    {
                        Console.WriteLine($"Пользователь {user.Name} уже взял книгу {book?.Name}!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            };
        }

        /// <summary>
        /// Не работает
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="Exception"></exception>
        /*public void ReturnBookToLibrary(User user)
        {
            using (db = new())
            {
                var query = from u in db.Users.Include(u => u.Books)
                            where u.Name == user.Name
                            select u.Books;

                foreach (var books in query)
                {
                    foreach (var book in books)
                    {
                        Console.WriteLine(book);
                    }
                }

                Console.WriteLine("Введите ID книги, кот. хотите вернуть:");
                if(!int.TryParse(Console.ReadLine(), out int id))
                {
                    throw new Exception("Неправильный ввод!");
                }

                var b = query.First().Find(x => x.Id == id);
                var indx = query.First().IndexOf(b);

                if (b != null)
                {
                    var a = db.Users.Where(x => x.Name == user.Name).Include(x => x.Books.Where(x => x.Id == id).First());
                    db.Remove(a);

                    bookRepository.TakeUserBook(user, b);
                    db.Users.Update(user);
                    db.SaveChanges();
                }
            }
        }*/

        /// <summary>
        /// Методы для проверки ввода текстовых значений для св-в класса User
        /// </summary>
        private void CreateUserEmailMethod(User user)
        {
            string hasEmail = !string.IsNullOrEmpty(user.Email) ? " новый " : " ";
            Console.Write($"Введите{hasEmail}e-mail: ");
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