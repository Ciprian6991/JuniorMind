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
                              .Select(x =>
                              {
                                  var seed = x.First();

                                  return x.Aggregate(seed, (max, current) =>
                                                     current.Score > max.Score ? current : max);
                              });
        }
    }
}
