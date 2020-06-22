using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public static class NumberOperations
    {
        public static IEnumerable<IEnumerable<int>> GetSubsetsLessOrEqualThanSum(IEnumerable<int> source, int sum)
        {
            ThrowIfNullParameter(source);

            return source.SelectMany((_, startPos) =>
                                                    source.Skip(startPos).Select((__, secIndex) =>
                                                          source.Skip(startPos).Take(source.Count() - secIndex - startPos)))
                                                                                                .Where(x => x.Sum() <= sum);
        }

        public static IEnumerable<string> GetAllPlusMinusCombinations(int length)
        {
            IEnumerable<string> seed = new[] { "" };

            return Enumerable.Range(1, length).Aggregate(seed, (res, x) =>
                                                            res.SelectMany(result => new[] { result + "+", result + "-" }));
        }

        private static void ThrowIfNullParameter(IEnumerable<int> array)
        {
            if (array != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(array));
        }
    }
}
