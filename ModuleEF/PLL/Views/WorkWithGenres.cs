using ModuleEF.BLL.Servicies;

namespace ModuleEF.PLL.Views
{
    public class WorkWithGenres
    {
        GenreService genreService = new();

        public void ShowGenresOperations()
        {
            Console.WriteLine("1.Добавить жанр;\n2.Посмотреть имеющиеся жанры;" +
        "\n3.Изменить данные жанра;\n4.Удалить жанр;");

            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    genreService.AddGenres();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    genreService.FindAll();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    genreService.UpdateGenre();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    genreService.DeleteGenres();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Нельзя выбрать такую операцию!");
                    break;
            }
    }
}