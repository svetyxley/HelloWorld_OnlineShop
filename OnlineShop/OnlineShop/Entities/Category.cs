using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    internal class Category
    {
        private static int incrementer = 0;

        public int Category_Id { get; private set; }

        public string Category_Name { get; set; }

        public Category()
        {
            Category_Id = incrementer;
            incrementer++;
        }

        public Category(string name)
        {
            Category_Name = name;
            Category_Id = incrementer;
            incrementer++;
        }
    }
}
