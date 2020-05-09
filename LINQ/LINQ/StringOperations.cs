using System;
using System.Collections.Generic;
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

            var operatingString = word.Replace(" ", "", StringComparison.CurrentCulture);

            return operatingString.Aggregate((0, 0), (resultTuple, curentChar) => "aeiouAEIOU".Contains(curentChar) ?
                                                                                        (resultTuple.Item1 + 1, resultTuple.Item2) :
                                                                                        (resultTuple.Item1, resultTuple.Item2 + 1));
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
