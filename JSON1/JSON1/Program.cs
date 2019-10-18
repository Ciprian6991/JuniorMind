using System;

namespace JSON1
{
    public class Program
    {
        public static bool IsAValidJsonString(string text)
        {
            return text != null
                    && IsBetweenApostrophe(text)
                    && HasCorrectSpecialCharactersInsideApostrophe(text);
        }

        private static bool HasCorrectSpecialCharactersInsideApostrophe(string text)
        {
            return HasCorrectBackslashSpecialCharacters(text.Substring(1, text.Length - 1 - 1));
        }

        private static bool HasCorrectBackslashSpecialCharacters(string text)
        {
            const string specialCharactersExceptHexa = "\"\\/bfnrt";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\\' && i < text.Length - 1
                    && !specialCharactersExceptHexa.Contains(text[i + 1])
                    && !HasCorrectUnicodeFromGivenPosition(text, i + 1))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HasCorrectUnicodeFromGivenPosition(string text, int pos)
        {
            const int SearchIntervalLength = 4;
            if (text.Length - pos < SearchIntervalLength)
            {
                return false;
            }

            if (text[pos] == 'u')
            {
                for (int i = pos + 1; i < SearchIntervalLength; i++)
                {
                    if (!IsHex(text[pos]))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool IsHex(char c)
        {
            return IsInRange('0', '9', c)
                    || IsInRange('a', 'f', c)
                    || IsInRange('A', 'F', c);
        }

        private static bool IsInRange(char start, char end, char c)
        {
            return start <= c && c <= end;
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
