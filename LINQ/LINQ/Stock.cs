using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public class Stock
    {
        private IEnumerable<Product> products;

        private Action<Product, int> callback;

        public Stock(params Product[] setProducts)
        {
            products = setProducts;
        }

        public void AddCallbackAction(Action<Product, int> callback)
        {
            this.callback = callback;
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

            products.Single((prod) => prod.Equals(product)).Add(quantity);
        }

        public void Buy(Product product, int quantity)
        {
            ThrowIfNullProduct(product);

            if (GetProductQuantity(product) < quantity)
            {
                throw new ArgumentOutOfRangeException("Quantity must be equal or less than" + $" {GetProductQuantity(product)}");
            }

            products.Single((prod) => prod.Equals(product)).Subtract(quantity);

            var curentProductValues = products.Single((prod) => prod.Equals(product));

            CallBackProduct(curentProductValues, curentProductValues.Quantity + quantity);
        }

        public void RemoveProduct(Product product)
        {
            ThrowIfNullProduct(product);

            products = products.Where(prod => !prod.Equals(product));
        }

        public int GetProductQuantity(Product product)
        {
            ThrowIfNullProduct(product);

            return products.Single(prod => prod.Equals(product))?.Quantity ?? 0;
        }

        public int GetTotalQuantity()
        {
            return products.Aggregate(0, (totalQuantity, product) => totalQuantity + product.Quantity);
        }

        private void CallBackProduct(Product curentProductValues, int oldQuantity)
        {
            List<int> callbackLimitValues = new List<int> { 10, 5, 2 };

            if (this.callback == null ||
                !callbackLimitValues.Contains(oldQuantity) ||
                curentProductValues.Quantity >= oldQuantity)
            {
                return;
            }

            callback(curentProductValues, curentProductValues.Quantity);
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