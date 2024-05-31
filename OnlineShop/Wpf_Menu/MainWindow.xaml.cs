using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OnlineShop;
using Wpf_Menu.Level2_pages;

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Dictionary<string, Page> pages;

        

        public MainWindow()
        {
            InitializeComponent();
            this.pages = new Dictionary<string, Page>();

            this.pages.Add("Buyers", new Buyers());
            this.pages.Add("Card", new Card());
            this.pages.Add("Category", new Category());
            this.pages.Add("Employee", new Employee());
            this.pages.Add("Manufacturer", new Manufacturer());
            this.pages.Add("Order", new Order());
            this.pages.Add("Payment", new Payment());
            this.pages.Add("Product", new Product());
            this.pages.Add("Stock", new Stock());
            this.pages.Add("Supplier", new Supplier());

        }

        private void NavigateToPage(string pageKey)
        {
            if (this.pages.ContainsKey(pageKey))
            {
                .Navigate(this.pages[pageKey]);
            }
        }


        private void Button_Click_Manuracturer(object sender, RoutedEventArgs e)
        {
            if (this.pages.TryGetValue("Manufacturer", out Page page))
            {
                this.Content = page;
            }
            else
            {
                MessageBox.Show("Страница не найдена.");
            }
        }

        private void Button_Click_Suppliers(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Category(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Products(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Orders(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Employees(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Buyers(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Cards(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Payment(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Stock(object sender, RoutedEventArgs e)
        {

        }
    }
}