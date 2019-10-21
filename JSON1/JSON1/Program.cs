﻿using System;

namespace JSON1
{
    public class Program
    {
        public static bool IsAValidJsonString(string text)
        {
            return text != null
                    && IsBetweenApostrophe(text)
                    && HasCorrectBackslashSpecialCharacters(ExtractStringFromQuatationMarks(text))
                    && HasCorrectUnicodeWithoutExceptions(ExtractStringFromQuatationMarks(text));
        }

        public static bool IsValidJsonNumber(string numberString)
        {
            return numberString != null
                && IsNegativeOrPositiveNumber(numberString);
        }

        private static bool IsNegativeOrPositiveNumber(string numberString)
        {
            int startIndex = 0;
            if (numberString[0] == '-')
            {
                startIndex = 1;
            }

            for (int i = startIndex; i < numberString.Length; i++)
            {
                if (numberString[i] < '0' || numberString[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private static string ExtractStringFromQuatationMarks(string text)
        {
            const int subtractedLength = 2;
            return text.Substring(1, text.Length - subtractedLength);
        }

        private static bool HasCorrectUnicodeWithoutExceptions(string text)
        {
            const string specialCharacters = "\"\b\f\n\r\t";
            const int unicodeUpperLimit = 32;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\"'
                    || !specialCharacters.Contains(text[i])
                    && (text[i] < unicodeUpperLimit))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HasCorrectBackslashSpecialCharacters(string text)
        {
            const string specialCharactersExceptHexa = "\"\\/bfnrt";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\\' && i < text.Length - 1
                    && !specialCharactersExceptHexa.Contains(text[i + 1])
                    && !HasCorrectFourUnicodeFromGivenPosition(text, i + 1))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HasCorrectFourUnicodeFromGivenPosition(string text, int pos)
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
