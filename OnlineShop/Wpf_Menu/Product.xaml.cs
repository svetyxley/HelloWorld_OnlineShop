using OnlineShop.BusinessLayer.Extensions;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private MainWindow mainWindow;

        private int indexer = JsonController<Product>.LoadIndexer();

        public ProductPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click_ShowAll(object sender, RoutedEventArgs e)
        {
            List<Product> products = JsonController<Product>.ReadFromFile();

            ProductsListBox.ItemsSource = products;
        }

        private void Button_Click_AddProduct(object sender, RoutedEventArgs e)
        {

            Product addingProduct = new Product();

            addingProduct.AddDataToProduct(ProductNameTextBox.Text, CategoryIdTextBox.Text, ManufacturerTextBox.Text, SupplierTextBox.Text, ProductPriceTextBox.Text);

            JsonController<Product>.WriteToFile(addingProduct);

            CategoryIdTextBox.Clear();
            ManufacturerTextBox.Clear();
            SupplierTextBox.Clear();
            ProductNameTextBox.Clear();
            ProductPriceTextBox.Clear();

        }


        private void Button_Click_Back_to_Main_Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }
    }
}
