using System;

namespace Lesson4Abstracting
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(args[0]);
            var value = new Value();
            Console.WriteLine(string.IsNullOrEmpty(value.Match(text).RemainingText()) ? "Valid JSON!" : "Invalid JSON!");

            Console.Read();
        }
    }
}
