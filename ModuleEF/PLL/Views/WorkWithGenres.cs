﻿using ModuleEF.BLL.Servicies;
using ModuleEF.PLL.Helpers;

namespace ModuleEF.PLL.Views
{
    public class WorkWithGenres
    {
        GenreService genreService = new();

        public void ShowGenresOperations()
        {
            Console.WriteLine("1.Добавить жанр;\n" +
                "2.Посмотреть имеющиеся жанры;\n" +
                "3.Изменить данные жанра;\n" +
                "4.Удалить жанр.");

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
                    ErrorMessage.Print("Нельзя выбрать такую операцию!");
                    break;
            }
        }
    }
}