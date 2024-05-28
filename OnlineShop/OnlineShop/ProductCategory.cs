using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class ProductCategory
    {
        public int ProductCategoryID { get; init; }
        public string ProductCategoryName { get; set; }

        public ProductCategory(int productCategoryID, string productCategoryName)
        {
            ProductCategoryID = productCategoryID;
            ProductCategoryName = productCategoryName;
        }

        // Override the ToString method
        public override string ToString()
        {
            return $"ProductCategoryID: {ProductCategoryID}, ProductCategoryName: {ProductCategoryName}";
        }
    }
}

