using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class BestScore
    {
        private readonly List<TestResults> resultsList;

        public BestScore(List<TestResults> results)
        {
            resultsList = results;
        }

        public IEnumerable<TestResults> GetBestScoreByFamily()
        {
            return resultsList.GroupBy(results => results.FamilyId)
                              .Select(family => family.First(person => person.Score == family.Max(result => result.Score)));
        }
    }
}
