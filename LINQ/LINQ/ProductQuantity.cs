using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class ProductQuantity
    {
        public ProductQuantity(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.Equals(Quantity);
        }
    }
}
