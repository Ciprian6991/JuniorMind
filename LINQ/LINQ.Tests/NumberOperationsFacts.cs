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
    }
}
