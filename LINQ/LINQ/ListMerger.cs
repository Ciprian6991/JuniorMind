using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public class ListMerger
    {
        private readonly List<ProductQuantity> firstList;
        private readonly List<ProductQuantity> secondList;

        public ListMerger(List<ProductQuantity> firstList, List<ProductQuantity> secondList)
        {
            this.firstList = firstList;
            this.secondList = secondList;
        }

        public IEnumerable<ProductQuantity> GetAllQuantitiesByName()
        {
            return MergeListsByName().Select(set => new ProductQuantity(set.Key, GetSetSumValues(set)));
        }

        private int GetSetSumValues(IGrouping<string, ProductQuantity> group)
        {
            return group.Sum(product => product.Quantity);
        }

        private IEnumerable<IGrouping<string, ProductQuantity>> MergeListsByName()
        {
            return firstList.Concat(secondList).GroupBy(x => x.Name);
        }
    }
}
