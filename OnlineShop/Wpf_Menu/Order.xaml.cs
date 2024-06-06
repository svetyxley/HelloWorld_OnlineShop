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
using OnlineShop.Entities;
using OnlineShop.EntityServices;

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {

        private MainWindow mainWindow;

        private PaymentType paymentType;

        public Order(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            //Payment_type_combo_box.ItemsSource = PaymentTypeController.ReadFromFile();

        }

        

        private void Button_Click_Back_to_Main_Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }



        private void Button_Click_AddOrder(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_ShowAll(object sender, RoutedEventArgs e)
        {


        }

        private void Payment_type_combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paymentType = (PaymentType)Payment_type_combo_box.SelectedItem;
        }

        private void Button_Click_AddPaymentType(object sender, RoutedEventArgs e)
        {
            //if (this.paymentType != null)
            //{
            //    PaymentTypeController.AddPaymentType(PaymentTypeTextBox.Text);
            //}
        }

        private void Button_Click_AddProduct(object sender, RoutedEventArgs e)
        {

        }
    }
}
