using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Tests
{
    public class NumberOperationsFacts
    {
        [Fact]
        public void Test_GenerateSubsets()
        {
            var subSets = NumberOperations.GetSubsetsLessOrEqualThanSum(new int[] { 1, 2, 3, 4, 5 }, 5);

            List<List<int>> testList = new List<List<int>>() {
                new List<int> { 1, 2 },
                new List<int> { 1 },
                new List<int> { 2, 3 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 4 },
                new List<int> { 5 }
            };

            Assert.Equal(testList, subSets);
        }

        [Fact]
        public void Test_GetAllPlusMinusCombinations_LengthOfFour()
        {
            var result = NumberOperations.GetAllPlusMinusCombinations(4);

            var expected = new string[] {
                                        "++++", "+++-", "++-+" ,"++--", "+-++", "+-+-", "+--+", "+---",
                                        "-+++", "-++-", "-+-+" ,"-+--", "--++", "--+-", "---+", "----",
                                        };
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test_GenerateEquations()
        {
            var result = NumberOperations.GenerateEquations(3, 0);

            var expected = new string[] {
                                        "+1+2-3 = 0",
                                        "-1-2+3 = 0"
                                        };

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test_GenerateEquationsComplex()
        {
            var result = NumberOperations.GenerateEquations(7, 10);

            var expected = new string[] {
                                        "+1+2+3-4-5+6+7 = 10",
                                        "+1+2-3+4+5-6+7 = 10",
                                        "+1-2+3+4+5+6-7 = 10",
                                        "+1-2-3-4+5+6+7 = 10",
                                        "-1+2-3+4-5+6+7 = 10",
                                        "-1-2+3+4+5-6+7 = 10"
                                        };

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test_GetAllConsecutiveTriplePairs()
        {
            var result = NumberOperations.GetAllConsecutiveTriplePairs(new int[] { 1, 2, 3, 4, 5 });

            var expected = new int[10][] {
                                          new int[] {1, 2, 3 },
                                          new int[] { 1, 2, 4 },
                                          new int[] {1, 2, 5 },
                                          new int[] { 1, 3, 4 },
                                          new int[] {1, 3, 5 },
                                          new int[] { 1, 4, 5 },
                                          new int[] {2, 3, 4 },
                                          new int[] { 2, 3, 5 },
                                          new int[] {2, 4, 5 },
                                          new int[] { 3, 4, 5 },
                                         }; 

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test_IsTriplePythagorean()
        {
            var result1 = NumberOperations.IsTriplePythagorean(3, 4, 5);
            var result2 = NumberOperations.IsTriplePythagorean(1, 2, 3);

            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void Test_GetAllPythagoreanPairPermutations()
        {
            var result = NumberOperations.GetAllPythagoreanPairPermutations(new int[] { 5, 4, 3 });

            var expected = new int[2][] {
                                          new int[] { 4, 3, 5 },
                                          new int[] { 3, 4, 5 },
                                         };

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test_IsTriplePythagoreanFalse()
        {

            var res = NumberOperations.IsTriplePythagorean(3, 12, 13);

            Assert.False(res);
        }

        [Fact]
        public void Test_GetAllPythagoreanPairs()
        {
            var result = NumberOperations.GetAllPythagoreanPairs(new int[] { 1, 2, 3, 4, 5, 12, 13 });

            var expected = new int[4][] {
                                          new[] { 3, 4, 5 }, new[] { 4, 3, 5 },
                                          new[] { 5, 12, 13 }, new[] { 12, 5, 13 }
                                         };

            Assert.Equal(result, expected);
        }
    }
}
