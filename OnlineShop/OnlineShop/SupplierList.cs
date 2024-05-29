using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class SupplierList
    {
        public ListController<Supplier> supplierController;
        public SupplierList()
        {
            supplierController = new ListController<Supplier>();
        }

        // Add a supplier to the list
        public void AddSupplier(Supplier supplier)
        {
            supplierController.AddItem(supplier);
        }

        // Remove a supplier from the list by index
        public bool RemoveSupplierAt(int index)
        {
            return supplierController.RemoveItemAt(index);
        }

        // Get all suppliers
        public List<Supplier> GetSuppliers()
        {
            return supplierController.GetItems();
        }

        // Override the ToString method
        public override string ToString()
        {
            return supplierController.ToString();
        }
    }
}
