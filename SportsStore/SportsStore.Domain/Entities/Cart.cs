using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        //Add an item to cart
        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(n => n.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
                line.Quantity += quantity;
        }

        //Remove all product that match the condition
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        //Caculate total value of cart
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(l => l.Product.Price * l.Quantity);
        }

        //Clear all item in cart
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return lineCollection;
            }
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
