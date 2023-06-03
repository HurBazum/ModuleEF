using ModuleEF.BLL.Servicies;
using ModuleEF.PLL.Helpers;

namespace ModuleEF.PLL.Views
{
    public class WorkWithUsers
    {
        UserService userService = new();
        public void ShowUserOperations()
        {
            Console.WriteLine("1.Добавить пользователя(нескольких);\n" +
                "2.Удалить пользователя;\n" +
                "3.Показать всех пользователей;\n" +
                "4.Показать конкретного пользователя;\n" +
                "5.Изменить данные конкретного пользователя;\n" +
                "6.Добавить книгу пользователю;\n" +
                "7.Забрать книгу у юзера.");

            var key = Console.ReadKey().Key;
            switch(key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    userService.AddUsers();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    userService.DeleteUsers();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    userService.FindAll();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    userService.GetUserById();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    userService.UpdateUsers();
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    userService.GiveBookToUser();
                    break;
                case ConsoleKey.D7:
                    Console.Clear();
                    userService.TakeBookFromUser();
                    break;
                default:
                    Console.Clear();
                    ErrorMessage.Print("Нельзя выбрать такую операцию!");
                    break;
            }
        }
    }
}