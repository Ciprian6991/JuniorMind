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

                Assert.Equal("Sequence contains no matching element", exception.Message);
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

                Assert.Equal("Sequence contains no matching element", exception.Message);
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

        [Fact]
        public void Test_Refill()
        {
            {
                var prod1 = new Product(1, "prod1", 10);
                var prod2 = new Product(2, "prod2", 100);
                var stock = new Stock();

                stock.AddProducts(prod1, prod2);

                stock.Refill(prod2, 20);

                Assert.Equal(120, stock.GetProductQuantity(prod2));
            }
        }

        [Fact]
        public void Test_ExceptionRefillNullProduct()
        {
            {
                var prod1 = new Product(1, "prod1", 10);
                Product prod2 = null;
                var stock = new Stock();

                stock.AddProducts(prod1);

                var exception = Assert.Throws<ArgumentNullException>(() => stock.Refill(prod2, 20));

                Assert.Equal("products", exception.ParamName);
            }
        }

        public void Test_RemoveProduct()
        {
            {
                var prod1 = new Product(1, "prod1", 10);
                var prod2 = new Product(2, "prod2", 100);
                var stock = new Stock();

                stock.AddProducts(prod1, prod2);

                Assert.Equal(110, stock.GetTotalQuantity());

                stock.RemoveProduct(prod2);

                Assert.Equal(10, stock.GetTotalQuantity());
            }
        }

        [Fact]
        public void Test_CallBack()
        {

            var prod1 = new Product(1, "prod1", 10);
            var stock = new Stock();
            string testString = "";

            stock.AddProducts(prod1);

            void TestMethod(Product product, int quantity)
            {
                testString = $"{product.Name} has only " + $"{quantity} pieces left.";
            }

            stock.AddCallbackAction(TestMethod);

            stock.Buy(prod1, 1);

            Assert.Equal("prod1 has only 9 pieces left.", testString);
        }

        [Fact]
        public void Test_CallBack_MultipleBuysOnlyOneCallback()
        {

            var prod1 = new Product(1, "prod1", 10);
            var stock = new Stock();
            string testString = "";

            stock.AddProducts(prod1);

            void TestMethod(Product product, int quantity)
            {
                testString = $"{product.Name} has only " + $"{quantity} pieces left.";
            }

            stock.AddCallbackAction(TestMethod);

            stock.Buy(prod1, 1);

            Assert.Equal("prod1 has only 9 pieces left.", testString);
            Assert.Equal(9, stock.GetProductQuantity(prod1));

            stock.Buy(prod1, 2);

            Assert.Equal(7, stock.GetProductQuantity(prod1));
            Assert.Equal("prod1 has only 9 pieces left.", testString);

            stock.Buy(prod1, 2);

            Assert.Equal(5, stock.GetProductQuantity(prod1));
            Assert.Equal("prod1 has only 9 pieces left.", testString);

            stock.Buy(prod1, 2);

            Assert.Equal(3, stock.GetProductQuantity(prod1));
            Assert.Equal("prod1 has only 3 pieces left.", testString);

            stock.Buy(prod1, 2);

            Assert.Equal(1, stock.GetProductQuantity(prod1));
            Assert.Equal("prod1 has only 1 pieces left.", testString);
        }
    }
}
