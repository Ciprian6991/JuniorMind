using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LINQ;

namespace LINQ
{
    public class StringOperations
    {
        public static int CountVocals(string word)
        {
            return word.Aggregate(0, (vocalsNumber, curentChar) => "aeiouAEIOU".Contains(curentChar) ? vocalsNumber + 1 : vocalsNumber);
        }

        public static int CountConsonants(string word)
        {
            ThrowNullParameter(word);

            return Regex.Replace(word, "\\s", "").Length - CountVocals(word);
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
