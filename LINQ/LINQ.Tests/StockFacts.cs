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
    }
}
