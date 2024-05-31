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
using OnlineShop;

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for Manufacturer.xaml
    /// </summary>
    public partial class Manufacturer : Page
    {
        

        public Manufacturer()
        {
            InitializeComponent();
            
        }

        private void Button_Click_AddManuracturer(object sender, RoutedEventArgs e)
        {

            // Создаем новый объект Manufacturer
            // Manufacturer temp = new Manufacturer()
            // {
            //      
            //      ManufacturerID = ManufacturerID.Text;
            //      ManufacturerName = ManufacturerName.Text;
            //      ManufacturerEDRPOU = ManufacturerEDRPOU.Text;
            // }
            // List.Add(temp)


        }

        private void Button_Click_ShowAllManufacturer(object sender, RoutedEventArgs e)
        {
            AllManufacturesListBox.Items.Clear();
            //AllManufacturesListBox.ItemsSource = обращение к свойству дбконтекста
        }


    }
}
