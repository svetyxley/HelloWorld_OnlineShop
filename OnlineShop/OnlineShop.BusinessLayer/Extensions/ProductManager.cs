using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data.Entities;
using OnlineShop.BusinessLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace OnlineShop.BusinessLayer.Extensions
{
    public static class ProductManager
    {
        //int productID, string productName, int productCategoryId, int productManufacturerId, int productSupplierId, uint productPrice
        public static void AddDataToProduct(this Product product, string name, string productCategoryId, string productManufacturerId, string productSupplierId, string productPrice)
        {
            string productName = string.Empty;
            if(!InputCheck.GetString(name, out productName)) { return; }
            product.ProductName = productName;

            int categoryId;
            if(!InputCheck.GetIdNumber(productCategoryId, out categoryId)){ return; }

            if (JsonController<Product>.checkId(categoryId))
            {
                product.ProductCategoryID = categoryId;
            }
            else { InputCheck.ShowError("Нет такого productCategoryId"); }


            int manufacturerId;
            if(!InputCheck.GetIdNumber(productManufacturerId, out manufacturerId)){ return; }

            if (JsonController<Manufacturer>.checkId(manufacturerId))
            {
                product.ManufacturerId = manufacturerId;
            }
            else { InputCheck.ShowError("Нет такого manufacturerId"); }


            int supplierId;
            if(!InputCheck.GetIdNumber(productSupplierId,out supplierId)) {  return; }

            if (JsonController<Supplier>.checkId(supplierId))
            {
                product.SupplierID = supplierId;
            }
            else { InputCheck.ShowError("Нет такого supplierId"); }


            uint price;
            if(!InputCheck.GetPriceUint(productPrice, out price)) { return; }
            product.ProductPrice = price;

        }
    }
}
