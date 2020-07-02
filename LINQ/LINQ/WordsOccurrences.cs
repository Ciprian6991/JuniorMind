using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class WordsOccurrences
    {
        private readonly string input;

        public WordsOccurrences(string input)
        {
            this.input = input ?? throw new ArgumentNullException(nameof(input));
        }

        public string GetWordsOccurrences()
        {
            string result = " ";

            foreach (KeyValuePair<string, int> pair in GetWordsOccurrencesAsKeyValuePair())
            {
                result += pair.Key + " => " + pair.Value + " \n ";
            }

            return result;
        }

        private IEnumerable<KeyValuePair<string, int>> GetWordsOccurrencesAsKeyValuePair()
        {
            return GetWords().GroupBy(words => words).Select(word => new KeyValuePair<string, int>(word.Key, word.Count()))
                                                     .OrderByDescending(pair => pair.Value);
        }

        private IEnumerable<string> GetWords()
        {
            return input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(word => word.ToLower());
        }
    }
}
