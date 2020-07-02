using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Tests
{
    public class BestScoreFacts
    {
        [Fact]
        public void Test_GetBestScoreByFamily()
        {
            var firstResult = new TestResults() { Id = "Sabin", FamilyId = "I", Score = 10 };
            var secondResult = new TestResults() {Id = "Adrian", FamilyId = "P", Score = 5};
            var thirdResult = new TestResults() {Id = "Adi", FamilyId = "I", Score = 15};
            var lastResult = new TestResults() { Id = "Andra", FamilyId = "P", Score = 3 };


            var list = new List<TestResults> { firstResult, secondResult, thirdResult, lastResult };

            var resultList = new BestScore(list);
            var filteredList = resultList.GetBestScoreByFamily();


            Assert.Equal(new[] { thirdResult, secondResult }, filteredList);

        }

        [Fact]
        public void Test_GetBestScoreByFamily_Duplicates()
        {
            var firstResult = new TestResults() { Id = "Sabin", FamilyId = "I", Score = 10 };
            var secondResult = new TestResults() { Id = "Andra", FamilyId = "P", Score = 3 };
            var thirdResult = new TestResults() { Id = "Sabin", FamilyId = "I", Score = 10 };
            var lastResult = new TestResults() { Id = "Andra", FamilyId = "P", Score = 3 };


            var list = new List<TestResults> { firstResult, secondResult, thirdResult, lastResult };

            var resultList = new BestScore(list);
            var filteredList = resultList.GetBestScoreByFamily();


            Assert.Equal(new[] { firstResult, secondResult }, filteredList);

        }
    }
}
