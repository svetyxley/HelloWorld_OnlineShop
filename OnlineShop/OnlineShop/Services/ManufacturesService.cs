using OnlineShop.Items;

namespace OnlineShop.Services
{
    internal class ManufacturesService
    {
        private List<Manufacturer> manufacturers = new();

        public bool Add(Manufacturer manufacturer)
        {
            manufacturers.Add(manufacturer);
            return true;
        }
    }
}
