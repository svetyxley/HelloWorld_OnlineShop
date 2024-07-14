using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Entities
{
    public class Category
    {
       
        public required int Category_Id { get; set; }

        public string Category_Name { get; set; }

        public Category()
        {
            Category_Id = JsonController<Category>.LoadIndexer();
        }

        public Category(int id,string name)
        {
            Category_Id = JsonController<Category>.LoadIndexer();
            Category_Name = name;
        }

        public override string ToString() { return $"Category_Id:{Category_Id} Category_Name:{Category_Name}"; }
    }
}
