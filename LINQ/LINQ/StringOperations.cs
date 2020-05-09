using System;
using System.Collections.Generic;
using System.Text;
using LINQ;

namespace LINQ
{
    public class StringOperations
    {
        public static int CountVocals(string word)
        {
            return word.Aggregate(0, (vocalsNumber, curentChar) => "aeiouAEIOU".Contains(curentChar) ? vocalsNumber + 1 : vocalsNumber);
        }
    }
}
