namespace ModuleEF.PLL.Helpers
{
    static class ErrorMessage
    {
        public static void Print(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}