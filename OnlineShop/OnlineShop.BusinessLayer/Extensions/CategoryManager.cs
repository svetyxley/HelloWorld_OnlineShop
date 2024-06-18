using OnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data.Entities;

namespace OnlineShop.BusinessLayer.Extensions
{
    public static class CategoryManager
    {
        public static void AddDataToCategory(this Category category, string categoryName)
        {
            category.Category_Id = JsonController<Category>.LoadIndexer();
            JsonController<Category>.SaveIndexer(category.Category_Id + 1);

            category.Category_Name = InputCheck.GetString(categoryName);
        }
    }
}
