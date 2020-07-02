using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Tests
{
    public class ListMergerFacts
    {
        [Fact]
        public void Test_GetAllQuantitiesByName()
        {
            var firstList = new List<ProductQuantity>
            {
                new ProductQuantity("apples", 3),
                new ProductQuantity("pears", 5)
            };

            var secondList = new List<ProductQuantity>
            {
                new ProductQuantity("apples", 4),
                new ProductQuantity("pears", 5)
            };

            var merger = new ListMerger(firstList, secondList).GetAllQuantitiesByName();
            var expectedList = new List<ProductQuantity>
            {
                new ProductQuantity("apples", 7),
                new ProductQuantity("pears", 10)
            };

            Assert.Equal(expectedList, merger);
        }

        [Fact]
        public void Test_GetAllQuantitiesByName_SameProductMultipleTimes_DiferentListsLength()
        {
            var firstList = new List<ProductQuantity>
            {
                new ProductQuantity("pears", 3),
                new ProductQuantity("pears", 5),
                new ProductQuantity("pears", 5),
                new ProductQuantity("apples", 1),
            };

            var secondList = new List<ProductQuantity>
            {
                new ProductQuantity("apples", 4),
                new ProductQuantity("pears", 1),
                new ProductQuantity("pears", 2),
                new ProductQuantity("pears", 5),
                new ProductQuantity("apples", 5)
            };

            var merger = new ListMerger(firstList, secondList).GetAllQuantitiesByName();
            var expectedList = new List<ProductQuantity>
            {
                new ProductQuantity("apples", 21),
                new ProductQuantity("pears", 10)
            };

            Assert.Equal(expectedList, merger);
        }
    }
}
