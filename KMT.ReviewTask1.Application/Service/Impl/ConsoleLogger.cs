using System;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public class ConsoleLogger : ILogger
    {
        public void Add(string message)
        {
            Console.WriteLine($"[{DateTime.Now:yyyyMMdd hh:MM:ss.fff}] {message}");
        }
    }
}