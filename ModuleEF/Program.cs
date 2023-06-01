using ModuleEF.PLL.Views;

class Program
{
    static Library library = new();
    static void Main(string[] strings)
    {
        var quit = false;
        while (quit == false)
        {
            library.WorkMenu(ref quit);

            Console.ReadLine();
        }
    }
}