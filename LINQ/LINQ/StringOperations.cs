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

            var operatingString = RemoveWhitespacesAndDigits(word);

            return operatingString.Aggregate((0, 0), (resultTuple, curentChar) => "aeiouAEIOU".Contains(curentChar) ?
                                                                                        (resultTuple.Item1 + 1, resultTuple.Item2) :
                                                                                        (resultTuple.Item1, resultTuple.Item2 + 1));
        }

        public static string RemoveWhitespacesAndDigits(string input)
        {
            return new string(input?.ToCharArray()
                .Where(c => char.IsLetter(c))
                .ToArray());
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
