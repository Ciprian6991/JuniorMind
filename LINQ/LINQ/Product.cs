using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class Product
    {
        public Product(int id, string name, int quantity)
        {
            ID = id;
            Name = name;
            Quantity = quantity;
        }

        public int ID { get; }

        public string Name { get; }

        public int Quantity { get; private set; }

        public void Add(int productNumbers)
        {
            Quantity += productNumbers;
        }

        public void Subtract(int productNumbers)
        {
            Quantity -= productNumbers;
        }
    }
}
