namespace OnlineShop
{
    internal class ManufacturerList
    {
        public ListController<Manufacturer> manufacturerController;
        public ManufacturerList()
        {
            manufacturerController = new ListController<Manufacturer>();
        }

        // Add a manufacturer to the list
        public void AddManufacturer(Manufacturer manufacturer)
        {
            manufacturerController.AddItem(manufacturer);
        }

        // Remove a manufacturer from the list by index
        public bool RemoveManufacturerAt(int index)
        {
            return manufacturerController.RemoveItemAt(index);
        }

        // Get all manufacturers
        public List<Manufacturer> GetManufacturers()
        {
            return manufacturerController.GetItems();
        }

        // Override the ToString method
        public override string ToString()
        {
            return manufacturerController.ToString();
        }

    }
}