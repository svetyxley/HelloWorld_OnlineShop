// See https://aka.ms/new-console-template for more information
using OnlineShop;

ManufacturerList manufacturersList = new ManufacturerList();
SupplierList suppliersList = new SupplierList();
ProductCategoryList productCategoryList = new ProductCategoryList();
ProductsList productsList = new ProductsList();

manufacturersList.AddManufacturer(new Manufacturer(1, "Manufacturer1", "Manufacturer1"));
manufacturersList.AddManufacturer(new Manufacturer(2, "Manufacturer2", "Manufacturer2"));
Console.WriteLine(manufacturersList.ToString());

suppliersList.AddSupplier(new Supplier(1, "Supplier1", "Supplier1"));
suppliersList.AddSupplier(new Supplier(2, "Supplier2", "Supplier2"));
Console.WriteLine(suppliersList.ToString());

productCategoryList.AddProductCategory(new ProductCategory(1, "ProductCategory1"));
productCategoryList.AddProductCategory(new ProductCategory(2, "ProductCategory2"));
Console.WriteLine(productCategoryList.ToString());

productsList.AddProduct(new Product(1, "Product1"));
productsList.AddProduct(new Product(2, "Product2"));
Console.WriteLine(productsList.ToString());



