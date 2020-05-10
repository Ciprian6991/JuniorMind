using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using LINQ;

namespace LINQ
{
    public class StringOperations
    {
        public static (int vocals, int consonants) CountVocalsConsonants(string word)
        {
            ThrowNullParameter(word);

            var operatingString = Regex.Replace(word, @"[\d ]*", "");

            return operatingString.Aggregate((0, 0), (resultTuple, curentChar) => "aeiouAEIOU".Contains(curentChar) ?
                                                                                        (resultTuple.Item1 + 1, resultTuple.Item2) :
                                                                                        (resultTuple.Item1, resultTuple.Item2 + 1));
        }

        public static char FirstUniqueCharacter(string word)
        {
            ThrowNullParameter(word);

            return word.FirstOrDefault((c) => word.IndexOf(c) == word.LastIndexOf(c));
        }

        public static int ConvertToInt(string word)
        {
            ThrowNullParameter(word);

            const int multiplyByTen = 10;

            return word.Aggregate(0, (number, ch) => char.IsDigit(ch) ? number * multiplyByTen + int.Parse(ch.ToString()) : number);
        }

        private static void ThrowNullParameter(string word)
        {
            if (word != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(word));
        }
    }
}
