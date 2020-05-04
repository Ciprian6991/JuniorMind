using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public class Stock
    {
        private IEnumerable<Product> products;

        public Stock(params Product[] setProducts)
        {
            products = setProducts;
        }

        public void AddProducts(params Product[] productsToAdd)
        {
            ThrowIfNullProduct(productsToAdd);

            foreach (Product product in productsToAdd)
            {
                products = products.Append(product);
            }
        }

        public void Refill(Product product, int quantity)
        {
            ThrowIfNullProduct(product);

            products.First((prod) => prod.Equals(product)).Add(quantity);
        }

        public void Buy(Product product, int quantity)
        {
            ThrowIfNullProduct(product);

            if (GetProductQuantity(product) < quantity)
            {
                throw new ArgumentOutOfRangeException("Quantity must be equal or less than" + $" {GetProductQuantity(product)}");
            }

            products.First((prod) => prod.Equals(product)).Subtract(quantity);
        }

        public void RemoveProduct(Product product)
        {
            ThrowIfNullProduct(product);

            products = products.Where(prod => !prod.Equals(product));
        }

        public int GetProductQuantity(Product product)
        {
            ThrowIfNullProduct(product);

            return products.First(prod => prod.Equals(product))?.Quantity ?? 0;
        }

        public int GetTotalQuantity()
        {
            return products.Aggregate(0, (totalQuantity, product) => totalQuantity + product.Quantity);
        }

        private void ThrowIfNullProduct(params Product[] products)
        {
            if (!products.Contains(null) && products != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(products));
        }
    }
}