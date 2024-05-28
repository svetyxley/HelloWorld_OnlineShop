using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class ProductCategoryList
    {
        public ListController<ProductCategory> productCategoryController;
        public ProductCategoryList()
        {
            productCategoryController = new ListController<ProductCategory>();
        }

        // Add a ProductCategory to the list
        public void AddProductCategory(ProductCategory productCategory)
        {
            productCategoryController.AddItem(productCategory);
        }

        // Remove a ProductCategory from the list by index
        public bool RemoveProductCategoryAt(int index)
        {
            return productCategoryController.RemoveItemAt(index);
        }

        // Get all product`s category
        public List<ProductCategory> GetProductCategory()
        {
            return productCategoryController.GetItems();
        }

        // Override the ToString method
        public override string ToString()
        {
            return productCategoryController.ToString();
        }

    }
}
