using OnlineShop.Items;

namespace OnlineShop.Services
{
    internal class SuppliersService
    {
        private List<Supplier> suppliers = new();

        public bool Add(Supplier supplier)
        {
            suppliers.Add(supplier);
            return true;
        }
    }
}
