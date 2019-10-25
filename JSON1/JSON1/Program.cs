using System;

namespace JSON1
{
    public class Program
    {
        public static bool IsAValidJsonString(string text)
        {
            if (text == "")
            {
                return false;
            }

            return text != null
                    && IsBetweenApostrophe(text)
                    && HasCorrectBackslashSpecialCharacters(ExtractStringFromQuatationMarks(text))
                    && HasCorrectUnicodeWithoutExceptions(ExtractStringFromQuatationMarks(text));
        }

        public static bool IsValidJsonNumber(string numberString)
        {
            if (numberString == "")
            {
                return false;
            }

            return numberString != null
                && IsValidIfHasOnlyOneDigit(numberString)
                && IsValidNegativePositiveOrSubunitarNumber(numberString)
                && HasCorrectDotExponentAndDigits(numberString);
        }

        private static bool HasCorrectDotExponentAndDigits(string text)
        {
            const string specialCharacters = "eE.+-";
            bool flagDot = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsDigit(text[i]) && !specialCharacters.Contains(text[i]))
                {
                    return false;
                }

                if (text[i] == '.' && !HasCorrectDotAsNumberAtGivenPosition(text, i, ref flagDot))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HasCorrectDotAsNumberAtGivenPosition(string text, int i, ref bool flagDot)
        {
            if (flagDot || i + 1 >= text.Length && char.IsDigit(text[i + 1]))
            {
                return false;
            }

            flagDot = true;
            return true;
        }

        private static bool IsValidIfHasOnlyOneDigit(string numberString)
        {
            return numberString.Length != 1 || char.IsDigit(numberString[0]);
        }

        private static bool IsValidNegativePositiveOrSubunitarNumber(string numberString)
        {
            return numberString[0] == '+' || numberString[0] == '-'
                || char.IsDigit(numberString[0]) || numberString[0] == '.';
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
            Console.WriteLine(IsValidJsonNumber(""));
            Console.ReadLine();
        }
    }
}
