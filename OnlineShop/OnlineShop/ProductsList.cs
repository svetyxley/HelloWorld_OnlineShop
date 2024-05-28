using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class ProductsList
    {
        public ListController<Product> productsListController;
        public ProductsList()
        {
            productsListController = new ListController<Product>();
        }

        // Add a product to the list
        public void AddProduct(Product product)
        {
            productsListController.AddItem(product);
        }

        // Remove a product from the list by index
        public bool RemoveProductAt(int index)
        {
            return productsListController.RemoveItemAt(index);
        }

        // Get all products
        public List<Product> GetProducts()
        {
            return productsListController.GetItems();
        }

        // Override the ToString method
        public override string ToString()
        {
            return productsListController.ToString();
        }
    }
}
