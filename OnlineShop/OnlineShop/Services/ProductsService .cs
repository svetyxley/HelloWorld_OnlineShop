using System.Collections.Generic;
using OnlineShop.Items;

namespace OnlineShop.Services
{
    internal class ProductsService
    {
        private List<Product> products = new();

        public bool Add(Product product)
        {
            products.Add(product);
            return true;
        }
    }
}
