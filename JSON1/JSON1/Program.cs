using System;

namespace JSON1
{
    public class Program
    {
        public static bool IsAValidJsonString(string text)
        {
            return text != null
                    && IsBetweenApostrophe(text);
        }

        private static bool IsBetweenApostrophe(string text)
        {
            return text[0] == '\"' && text[text.Length - 1] == '\"';
        }

        static void Main()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
