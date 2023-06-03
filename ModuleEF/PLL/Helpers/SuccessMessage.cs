namespace ModuleEF.PLL.Helpers
{
    public static class SuccessMessage
    {
        public static void Print(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}