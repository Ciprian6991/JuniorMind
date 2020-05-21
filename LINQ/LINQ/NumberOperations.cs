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

            var allSets = from index1 in Enumerable.Range(1, 1 << source.Count())
                            select
                                   from index2 in Enumerable.Range(0, source.Count())
                                   where (index1 & (1 << index2)) != 0
                                   select source.ToList()[index2];

            return allSets.Where(element => element.Sum() <= sum).SkipLast(1);
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
