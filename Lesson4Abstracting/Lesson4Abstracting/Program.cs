using System;

namespace Lesson4Abstracting
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Anita Ciprian\Desktop\afis.txt");
            Console.WriteLine("Contents of WriteText.txt = {0}", text);
            Console.Read();
        }
    }
}
