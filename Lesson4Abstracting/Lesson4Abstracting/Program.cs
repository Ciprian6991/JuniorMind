using System;

namespace Lesson4Abstracting
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"E:\ProiecteVS\GitHub\Lesson4Abstracting\Lesson4Abstracting.Facts\JSON1.txt");
            var value = new Value();
            Console.WriteLine(string.IsNullOrEmpty(value.Match(text).RemainingText()) ? "Valid JSON!" : "Invalid JSON!");

            Console.Read();
        }
    }
}
