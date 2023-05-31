using ModuleEF.BLL.Servicies;

namespace ModuleEF.PLL.Views
{
    public class WorkWithUsers
    {
        UserService userService = new();
        public void ShowUserOperations()
        {
            Console.WriteLine("1.Добавить пользователя(нескольких);" +
                "2.Удалить пользователя;" +
                "3.Показать всех пользователей;" +
                "4.Показать конкретного пользователя;" +
                "5.Изменить данные конкретного пользователя;" +
                "6.Добавить книгу пользователю;");

            var key = Console.ReadKey().Key;
            switch(key)
            {
                case ConsoleKey.D1:
                    userService.AddUsers();
                    break;
                case ConsoleKey.D2:
                    userService.DeleteUsers();
                    break;
                case ConsoleKey.D3:
                    userService.FindAll();
                    break;
                case ConsoleKey.D4:
                    userService.GetUserById();
                    break;
                case ConsoleKey.D5:
                    userService.UpdateUsers();
                    break;
                case ConsoleKey.D6:
                    userService.GiveBookToUser();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Нельзя выбрать такую операцию!");
                    break;
            }
        }
    }
}