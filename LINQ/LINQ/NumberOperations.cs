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

            var subsets = from subset in source.SubSetsOf()
                          where subset.Sum() <= sum
                          select subset;

            return subsets.SkipLast(1);
        }

        private static IEnumerable<IEnumerable<T>> SubSetsOf<T>(this IEnumerable<T> source)
        {
            if (source.Any())
            {
                var element = source.Take(1);

                var setsWithoutElement = SubSetsOf(source.Skip(1));

                var setsWithAddedElement = setsWithoutElement.Select(set => element.Concat(set));

                return setsWithAddedElement.Concat(setsWithoutElement);
            }

            return Enumerable.Repeat(Enumerable.Empty<T>(), 1);
        }

        private static IEnumerable<int> GetSubset(this IEnumerable<int> array, int startingPosition, int numbersToTake)
        {
            return GetSubset(array, startingPosition).Take(numbersToTake);
        }

        private static IEnumerable<int> GetSubset(this IEnumerable<int> array, int startingPosition)
        {
            return array.Skip(startingPosition);
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
