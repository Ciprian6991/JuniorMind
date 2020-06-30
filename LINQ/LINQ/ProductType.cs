using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class ProductType
    {
        public string Name { get; set; }

        public ICollection<Feature> Features { get; set; }
    }
}
