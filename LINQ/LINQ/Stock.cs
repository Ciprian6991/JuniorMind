﻿using System;
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

        public int GetTotalQuantity()
        {
            return products.Aggregate(0, (totalQuantity, product) => totalQuantity + product.Quantity);
        }

        public void Buy(Product product, int quantity)
        {
            ThrowIfNullProduct(product);

            products.First((prod) => prod.Equals(product)).Subtract(quantity);
        }

        public int GetProductQuantity(Product product)
        {
            ThrowIfNullProduct(product);

            return products.First(prod => prod.Equals(product))?.Quantity ?? 0;
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