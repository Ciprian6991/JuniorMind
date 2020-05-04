using System;
using Lesson8LINQ;
using Xunit;

namespace LINQ.Tests
{
    public class StockFacts
    {
        [Fact]
        public void Test_Initialize_Add_GetTotalQuantity()
        {
            {
                var prod1 = new Product(1, "prod1", 10);
                var prod2 = new Product(2, "prod2", 100);
                var stock = new Stock();

                stock.AddProducts(prod1);
                stock.AddProducts(prod2);

                Assert.Equal(110, stock.GetTotalQuantity());
            }
        }

        [Fact]
        public void Test_Buy_GetProductQuantity()
        {
            {
                var prod1 = new Product(1, "prod1", 10);
                var prod2 = new Product(2, "prod2", 100);
                var stock = new Stock();

                stock.AddProducts(prod1, prod2);

                stock.Buy(prod2, 20);

                Assert.Equal(80, stock.GetProductQuantity(prod2));
            }
        }

        [Fact]
        public void Test_ExceptionNotFoundElementForGetProductQuantity()
        {
            {
                var prod1 = new Product(1, "prod1", 10);
                var prod2 = new Product(2, "prod2", 100);
                var stock = new Stock();

                stock.AddProducts(prod1);

                var exception = Assert.Throws<InvalidOperationException>(() => stock.GetProductQuantity(prod2));

                Assert.Equal("No element has been found", exception.Message);
            }
        }

        [Fact]
        public void Test_ExceptionNotFoundElementForBuy()
        {
            {
                var prod1 = new Product(1, "prod1", 10);
                var prod2 = new Product(2, "prod2", 100);
                var stock = new Stock();

                stock.AddProducts(prod1);

                var exception = Assert.Throws<InvalidOperationException>(() => stock.Buy(prod2, 10));

                Assert.Equal("No element has been found", exception.Message);
            }
        }

        [Fact]
        public void Test_ExceptionNotEnoughQuantityForBuy()
        {
            {
                var prod1 = new Product(1, "prod1", 10);
                var prod2 = new Product(2, "prod2", 100);
                var stock = new Stock();

                stock.AddProducts(prod1, prod2);

                var exception = Assert.Throws<ArgumentOutOfRangeException>(() => stock.Buy(prod2, 200));

                Assert.Equal("Quantity must be equal or less than 100", exception.ParamName);
            }
        }
    }
}
