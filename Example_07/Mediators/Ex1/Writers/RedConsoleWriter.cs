using System;

namespace Example_07.Mediators
{
    public class RedConsoleWriter
    {
        public void Write(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
