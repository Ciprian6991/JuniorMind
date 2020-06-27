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

        public static IEnumerable<string> GenerateEquations(int k, int sum)
        {
            return GetAllPlusMinusCombinations(k).Where(equation => GetSumOfConsecutiveNaturalNumbers(equation) == sum)
                                                 .Select(element => string.Concat(element.Select((sign, value) => sign.ToString() + (value + 1)))
                                                                    + string.Concat(" = ", sum.ToString()));
        }

        public static IEnumerable<string> GetAllPlusMinusCombinations(int length)
        {
            IEnumerable<string> seed = new[] { "" };

            return Enumerable.Range(1, length).Aggregate(seed, (res, x) =>
                                                            res.SelectMany(result => new[] { result + "+", result + "-" }));
        }

        public static IEnumerable<IEnumerable<int>> GetAllPythagoreanPairs(IEnumerable<int> array)
        {
            return GetAllDistinctTriplePairs(array).SelectMany(pair => GetAllPythagoreanPairPermutations(pair));
        }

        public static IEnumerable<IEnumerable<int>> GetAllDistinctTriplePairs(IEnumerable<int> array)
        {
            return array.SelectMany((first, firstIndex) => array.Skip(firstIndex + 1)
                                          .SelectMany((sec, secIndex) => array.Skip(firstIndex + ++secIndex + 1)
                                          .Select(third => new[] { first, sec, third })));
        }

        public static bool IsTriplePythagorean(int firstElement, int secondElement, int thirdElement)
        {
            return (firstElement * firstElement) + (secondElement * secondElement) == thirdElement * thirdElement;
        }

        public static IEnumerable<IEnumerable<int>> GetAllPythagoreanPairPermutations(IEnumerable<int> pair)
        {
            var first = pair.First();
            var second = pair.ElementAt(1);
            var third = pair.Last();

            return PermuteElements(first, second, third)
                   .Where(permutation => IsTriplePythagorean(permutation.First(), permutation.ElementAt(1), permutation.Last()));
        }

        private static IEnumerable<IEnumerable<int>> PermuteElements(int first, int second, int third)
        {
            return first != second ?
                        new[]
                        {
                            new[] { first, second, third }, new[] { first, third, second },
                            new[] { second, first, third }, new[] { second, third, first },
                            new[] { third, first, second }, new[] { third, second, first }
                        }
                        :
                        new[] { new[] { 0, 0, 0 } };
        }

        private static int GetSumOfConsecutiveNaturalNumbers(string signs)
        {
            if (signs == null)
            {
                throw new ArgumentNullException(signs);
            }

            return Enumerable.Range(1, signs.Length)
                .Aggregate(0, (result, index) => signs[index - 1] == '+' ? result + index : result - index);
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
