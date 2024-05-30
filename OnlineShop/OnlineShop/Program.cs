// See https://aka.ms/new-console-template for more information
using OnlineShop.Items;
using OnlineShop.Services;

ProductsService productsService = new ProductsService();
productsService.Add(new Product(1, "Product1"));
productsService.Add(new Product(2, "Product2"));


ManufacturesService manufactureService = new ManufacturesService();
manufactureService.Add(new Manufacturer(1, "Manufacturer1", "Manufacturer1"));
manufactureService.Add(new Manufacturer(2, "Manufacturer2", "Manufacturer2"));


SuppliersService suppliersService = new SuppliersService();
suppliersService.Add(new Supplier(1, "Supplier1", "Supplier1"));
suppliersService.Add(new Supplier(2, "Supplier2", "Supplier2"));





