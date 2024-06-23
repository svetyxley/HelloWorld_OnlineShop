using OnlineShop.Data;
using OnlineShop.Data.Entities;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.Managers;

namespace OnlineShop.BusinessLayer.Extensions
{
    static class ManufacturerManager
    {
        public static void addDataToEmployee(this Manufacturer manufacturer, string manufacturerName, string manufacturerEDRPOU)
        {
            //public Manufacturer(int manufacturerID, string manufacturerName, string manufacturerEDRPOU)

            manufacturer.ManufacturerID = JsonController<Manufacturer>.LoadIndexer();
            JsonController<Employee>.SaveIndexer(manufacturer.ManufacturerID + 1);

            manufacturer.ManufacturerName = InputCheck.GetString(manufacturerName);
            manufacturer.ManufacturerEDRPOU = InputCheck.GetEDRPOU(manufacturerEDRPOU);
        }
    }
}
