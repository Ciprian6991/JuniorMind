using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using LINQ;
using System.Linq;

namespace LINQ.Tests
{
    public class LinqFunctionsFacts
    {
        public class ProductsList
        {
            public struct Ingredient
            {
                public string Name { set; get; }

                public int IngredientID { get; set; }
            }

            public struct Product
            {
                public int ID { set; get; }
                public string Name { set; get; }
                public int Price { set; get; }
                public List<Ingredient> Ingredients { set; get; }
            }

            List<Product> products;


            public ProductsList()
            {
                products = new List<Product>();
            }

            public List<Product> GetProducts()
            {
                return new List<Product>()
                {
                new Product {ID = 2,
                    Name = "Detergent",
                    Price= 10,
                    Ingredients = new List<Ingredient> { new Ingredient { Name = "Lamaie" }, new Ingredient {Name = "Parfum1" } } },

                new Product {ID = 3,
                    Name = "Sapun",
                    Price= 10,
                    Ingredients = new List<Ingredient> { new Ingredient { Name = "Portocala" }, new Ingredient { Name = "Menta" }, new Ingredient {Name = "Parfum2" } } },

                new Product {ID = 6,
                    Name = "Sampon",
                    Price= 10,
                    Ingredients = new List<Ingredient> { new Ingredient { Name = "Menta" }, new Ingredient {Name = "Parfum3" } } },
                };
            }
        }


        [Fact]
        public void TestAllWhenTrue()
        {
            var array = new int[] { 2, 4, 6 };

            Func<int, bool> myFunc = (x) => { return x % 2 == 0; };

            Assert.True(LinqFunctions.All(array, p => myFunc(p)));
        }

        [Fact]
        public void TestAllWhenFalse()
        {
            var array = new int[] { 2, 4, 6, 7 };

            Func<int, bool> myFunc = (x) => { return x % 2 == 0; };

            Assert.False(LinqFunctions.All(array, p => myFunc(p)));
        }

        [Fact]
        public void TestAllWhenSourceIsNull()
        {
            int[] array = null;

            Func<int, bool> myFunc = (x) => { return x == 4; };

            var msg = Assert.Throws<ArgumentNullException>(() => LinqFunctions.All(array, p => myFunc(p)));

            Assert.Equal("Value cannot be null.\r\nParameter name: source", msg.Message);
        }

        [Fact]
        public void TestAnyWhenTrue()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 15 };

            Func<int, bool> myFunc = (x) => { return x >= 10; };

            Assert.True(LinqFunctions.Any(array, p => myFunc(p)));
        }

        [Fact]
        public void TestAnyWhenFalse()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };

            Func<int, bool> myFunc = (x) => { return x >= 10; };

            Assert.False(LinqFunctions.Any(array, p => myFunc(p)));
        }

        [Fact]
        public void TestAnyWhenSourceIsNull()
        {
            int[] array = null;

            Func<int, bool> myFunc = (x) => { return x == 4; };

            var msg = Assert.Throws<ArgumentNullException>(() => LinqFunctions.Any(array, p => myFunc(p)));

            Assert.Equal("Value cannot be null.\r\nParameter name: source", msg.Message);
        }

        [Fact]
        public void TestFirstWhenExists()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };

            Func<int, bool> myFunc = (x) => { return x == 4; };

            var result = LinqFunctions.First(array, p => myFunc(p));

            Assert.Equal(4, result);
        }

        [Fact]
        public void TestFirstWhenDoesntExists()
        {
            var array = new int[] { 2, 5, 3 };

            Func<int, bool> myFunc = (x) => { return x == 4; };

            var msg = Assert.Throws<InvalidOperationException>(() => LinqFunctions.First(array, p => myFunc(p)));

            Assert.Equal("No element has been found", msg.Message);
        }

        [Fact]
        public void TestFirstWhenSourceIsNull()
        {
            int[] array = null;

            Func<int, bool> myFunc = (x) => { return x == 4; };

            var msg = Assert.Throws<ArgumentNullException>(() => LinqFunctions.First(array, p => myFunc(p)));

            Assert.Equal("Value cannot be null.\r\nParameter name: source", msg.Message);
        }


        [Fact]
        public void TestSelectWhenExists()
        {
            string[] strings =
                { "Ana",
                  "Andrei",
                  "Sabin",
                  "Alin",
                  "Mihai"};

            Func<string, bool> myFunc = (x) => x.StartsWith("an", StringComparison.InvariantCultureIgnoreCase) ? true : false;

            var results = LinqFunctions.Select(strings, p => myFunc(p));

            var matches = 0;

            foreach (var result in results)
            {
                if (result)
                {
                    matches++;
                }
            }

            Assert.Equal(2, matches);
        }

        [Fact]
        public void TestSelectWhenDoesntExists()
        {
            string[] strings =
                { "Ana",
                  "Andrei",
                  "Sabin",
                  "Alin",
                  "Mihai"};

            Func<string, bool> myFunc = (x) => x.StartsWith("gf", StringComparison.InvariantCultureIgnoreCase) ? true : false;

            var results = LinqFunctions.Select(strings, p => myFunc(p));

            var matches = 0;

            foreach (var result in results)
            {
                if (result)
                {
                    matches++;
                }
            }

            Assert.Equal(0, matches);
        }

        [Fact]
        public void TestSelectWhenNullSelector()
        {
            string[] strings =
                { "Ana",
                  "Andrei",
                  "Sabin",
                  "Alin",
                  "Mihai"};

            Func<string, int> myFunc = null;

            var p = myFunc;

            var results = LinqFunctions.Select(strings, p);

            var numerator = results.GetEnumerator();

            var msg = Assert.Throws<ArgumentNullException>(() => numerator.MoveNext());

            Assert.Equal("selector", msg.ParamName);

        }

        [Fact]
        public void TestSelectWhenNullSource()
        {
            string[] strings = null;

            Func<string, int> myFunc = x => x.Length;

            var p = myFunc;

            var results = LinqFunctions.Select(strings, p);

            var numerator = results.GetEnumerator();

            var msg = Assert.Throws<ArgumentNullException>(() => numerator.MoveNext());

            Assert.Equal("source", msg.ParamName);

        }

        [Fact]
        public void TestSelectManyWhenExists()
        {
            var productList = new ProductsList().GetProducts();

            Func<ProductsList.Product, List<ProductsList.Ingredient>> MyFunc = x => x.Ingredients;

            var selectedIngredients = LinqFunctions.SelectMany(productList, MyFunc);

            var enumerator = selectedIngredients.GetEnumerator();

            int counter = 0;

            while(enumerator.MoveNext())
            {
                counter++;
            }

            Assert.Equal(7, counter);

        }

        [Fact]
        public void TestWhereWhenExists()
        {
            var productList = new ProductsList().GetProducts();

            Func<ProductsList.Product, bool> MyFunc = x => x.Ingredients.Contains(new ProductsList.Ingredient { Name = "Menta" });

            var selectedIngredients = LinqFunctions.Where(productList, MyFunc);

            var enumerator = selectedIngredients.GetEnumerator();

            int counter = 0;

            while (enumerator.MoveNext())
            {
                counter++;
            }

            Assert.Equal(2, counter);

        }



        [Fact]
        public void TestToDictionaryWhenExists()
        {
            var productList = new ProductsList().GetProducts();

            Func<ProductsList.Product, int> myKeyFunc = (x) => x.ID;
            Func<ProductsList.Product, string> myElementFunc = (x) => x.Name;

            var dictionary = LinqFunctions.ToDictionary(productList, p => myKeyFunc(p), z => myElementFunc(z));

            var test1 = new KeyValuePair<int, string>(2, "Detergent");
            var test2 = new KeyValuePair<int, string>(3, "Sapun");
            var test3 = new KeyValuePair<int, string>(6, "Sampon");
            var test4 = new KeyValuePair<int, string>(10, "Biocid");


            Assert.Contains(test1, dictionary);
            Assert.Contains(test2, dictionary);
            Assert.Contains(test3, dictionary);
            Assert.DoesNotContain(test4, dictionary);
        }

        [Fact]
        public void TestToDictionaryWhenDuplicateKeysException()
        {
            var productList = new ProductsList().GetProducts();

            var prodToAdd = new ProductsList.Product
            {
                ID = 6,
                Name = "Deodorant",
                Price = 6,
                Ingredients = new List<ProductsList.Ingredient> { new ProductsList.Ingredient { Name = "Fresh" }, new ProductsList.Ingredient { Name = "Parfum4" } }
            };

            productList.Add(prodToAdd);

            Func<ProductsList.Product, int> myKeyFunc = (x) => x.ID;
            Func<ProductsList.Product, string> myElementFunc = (x) => x.Name;

            var dictionary = Assert.Throws<ArgumentException>(() => LinqFunctions.ToDictionary(productList, p => myKeyFunc(p), z => myElementFunc(z)));

            Assert.Equal("An item with the same key has already been added. Key: 6", dictionary.Message);
        }

        [Fact]
        public void TestZipWhenValid()
        {
            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three", "nine", "six" };

            var result = LinqFunctions.Zip(numbers, words, (first, second) => first + " " + second);

            Assert.True(result.Contains("3 three"));
        }

        [Fact]
        public void TestZipExceptions()
        {
            int[] numbers = null;
            string[] words = { "one", "two", "three", "nine", "six" };

            var result = LinqFunctions.Zip(numbers, words, (first, second) => first + " " + second);

            var exception = Assert.Throws<ArgumentNullException>(() => result.Count());

            Assert.Equal("source", exception.ParamName);

            
        }


        [Fact]
        public void TestAggregateWhenValid()
        {
            int[] array = { 1, 2, 4, 5 };

            Func<int, int, int> myFunc = (x, z) => x * z;

            var result = LinqFunctions.Aggregate(array, 5, (a, b) => myFunc(a, b));

            Assert.Equal(200, result);
        }

        [Fact]
        public void TestAggregateExceptions()
        {
            int[] array = null;
            Func<int, int, int> myFunc = (x, z) => x * z;

            Assert.Throws<ArgumentNullException>(() => LinqFunctions.Aggregate(array, 5, (a, b) => myFunc(a, b)));
        }


        [Fact]
        public void TestJoin()
        {
            var products = new ProductsList().GetProducts();

            var newIngredients = new List<ProductsList.Ingredient>()
            {
                new ProductsList.Ingredient
                { IngredientID = 2, Name = "Rose1" },

                new ProductsList.Ingredient
                { IngredientID = 3, Name = "Rose2" },

                new ProductsList.Ingredient
                { IngredientID = 6, Name = "Rose3" },
            };

            Func<ProductsList.Product, int> outerFunc = (product) => product.ID;
            Func<ProductsList.Ingredient, int> innerFunc = (ingredient) => ingredient.IngredientID;
            Func<ProductsList.Product, ProductsList.Ingredient, KeyValuePair<string, string>> selector = (product, ingredient) =>
            {
                {
                    return new KeyValuePair<string, string>(product.Name, ingredient.Name);
                }
            };

            var result = LinqFunctions.Join(products, newIngredients,
                                        product => outerFunc(product), newIngredient => innerFunc(newIngredient),
                                        (product, newIngredient) =>
                                        selector(product, newIngredient));

            var cont1 = new KeyValuePair<string, string>("Detergent", "Rose1");
            var cont2 = new KeyValuePair<string, string>("Sapun", "Rose2");
            var notCont = new KeyValuePair<string, string>("Sapun", "Rose3");

            Assert.Contains(cont1, result);
            Assert.Contains(cont2, result);
            Assert.DoesNotContain(notCont, result);
        }
    }
}
