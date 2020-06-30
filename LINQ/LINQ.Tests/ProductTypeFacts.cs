using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LINQ.Tests
{
    public class ProductTypeFacts
    {
        [Fact]
        public void Test_AnyFeatureFilter()
        {
            ProductType prod1 = new ProductType
            {
                Name = "prod1",
                Features = new List<Feature> { new Feature { Id = 1 } }
            };

            ProductType prod2 = new ProductType
            {
                Name = "prod2",
                Features = new List<Feature> { new Feature { Id = 2 },
                                               new Feature { Id = 3 }
                                             }
            };

            ProductType prod3 = new ProductType
            {
                Name = "prod3",
                Features = new List<Feature> { new Feature { Id = 4 },
                                               new Feature { Id = 1 }
                                             }
            };

            var productList = new List<ProductType> { prod1, prod2, prod3 };

            var filteringCriteria = new List<Feature> { new Feature { Id = 1 } };
            var filter = new ListFilter(productList, filteringCriteria);
            var filteredList = filter.AnyFeatureFilter();

            Assert.Equal(2, filteredList.Count());
            Assert.Equal(prod1, filteredList.First());
            Assert.Equal(prod3, filteredList.Last());

        }


        [Fact]
        public void Test_AllFeaturesFilter()
        {
            ProductType prod1 = new ProductType
            {
                Name = "prod1",
                Features = new List<Feature> { new Feature { Id = 1 },
                                               new Feature { Id = 2 },
                                               new Feature { Id = 3 },
                                               new Feature { Id = 4 }
                                             }
            };

            ProductType prod2 = new ProductType
            {
                Name = "prod2",
                Features = new List<Feature> { new Feature { Id = 2 },
                                               new Feature { Id = 3 }
                                             }
            };

            ProductType prod3 = new ProductType
            {
                Name = "prod3",
                Features = new List<Feature> { new Feature { Id = 2 },
                                               new Feature { Id = 1 }
                                             }
            };

            var productList = new List<ProductType> { prod1, prod2, prod3 };

            var filteringCriteria = new List<Feature> { new Feature { Id = 2 }, new Feature { Id = 3 } };
            var filter = new ListFilter(productList, filteringCriteria);
            var filteredList = filter.AllFeaturesFilter();

            Assert.Equal(2, filteredList.Count());
            Assert.Equal(prod1, filteredList.First());
            Assert.Equal(prod2, filteredList.Last());

        }




    }
}
