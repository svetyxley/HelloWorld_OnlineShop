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

            string name = string.Empty;
            if (!InputCheck.GetString(manufacturerName, out name)) { return; }
            manufacturer.ManufacturerName = name;

            string edrpou ;
            if (!InputCheck.GetEDRPOU(manufacturerEDRPOU ,out edrpou)) {  return; }    
            manufacturer.ManufacturerEDRPOU = edrpou;
        }
    }
}
