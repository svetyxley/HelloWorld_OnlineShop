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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {

        private MainWindow mainWindow;

        public Order(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click_Back_to_Main_Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }

        private void Button_Click_AddProduct(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_AddOrder(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_ShowAll(object sender, RoutedEventArgs e)
        {

        }
    }
}
