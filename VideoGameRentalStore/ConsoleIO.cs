using System;

namespace VideoGameRentalStore
{
    public class ConsoleIO : IConsoleIO
    {
        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
