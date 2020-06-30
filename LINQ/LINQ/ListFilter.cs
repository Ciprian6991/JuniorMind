using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public class ListFilter
    {
        private readonly List<Feature> featureList;
        private readonly List<ProductType> productList;

        public ListFilter(List<ProductType> products, List<Feature> features)
        {
            productList = products;
            featureList = features;
        }

        public IEnumerable<ProductType> AnyFeatureFilter()
        {
            return productList.Where(product => HasAtLeastOneFeature(product));
        }

        public IEnumerable<ProductType> AllFeaturesFilter()
        {
            return productList.Where(product => HasAllFeatures(product));
        }

        private bool HasAtLeastOneFeature(ProductType product)
        {
            return featureList.Any(feature => product.Features.Contains(feature, new IDComparer()));
        }

        private bool HasAllFeatures(ProductType product)
        {
            return featureList.All(feature => product.Features.Contains(feature, new IDComparer()));
        }
    }
}
