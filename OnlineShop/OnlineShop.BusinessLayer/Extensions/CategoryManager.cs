using OnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data.Entities;
using OnlineShop.BusinessLayer.Managers;

namespace OnlineShop.BusinessLayer.Extensions
{
    public static class CategoryManager
    {
        public static void AddDataToCategory(this Category category, string categoryName)
        {
            string catName = string.Empty;
            if (!InputCheck.GetString(categoryName, out catName)) { return; }
            category.Category_Name = catName;

            category.Category_Id = JsonController<Category>.LoadIndexer();
            JsonController<Category>.SaveIndexer(category.Category_Id + 1);

        }
    }
}
