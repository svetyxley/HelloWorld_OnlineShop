using OnlineShop.EntityServices;
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
using System.Net.Mail;

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for Buyers.xaml
    /// </summary>
    public partial class Buyers : Page
    {


        private MainWindow mainWindow;

        public Buyers(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click_Back_to_Main_Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }

        private void Button_Click_ChangeBuyerByID(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_AddBuyer(object sender, RoutedEventArgs e)
        {

            ulong inn = GettingData.GetINN(INN);
            string name = GettingData.GetString(Name);
            string surname = GettingData.GetString(Surname);
            string phoneNumber = GettingData.GetString(PhoneNumber);
            DateOnly userBirthDate = GettingData.GetDataOnly(Date_of_birth);

            string address = GettingData.GetString(Address);
            MailAddress email = GettingData.GetEmail(emailtext);


            Buyer addingBuyer = new Buyer(inn, name, surname, email, phoneNumber,  userBirthDate, address);
            

            JsonController<Buyer>.Add(addingBuyer);
        }

        private void Button_Click_ShowAllBuyers(object sender, RoutedEventArgs e)
        {
            List<Buyer> list = JsonController<Buyer>.ReadFromFile();

            foreach (var buyer in list)
            {
                AllBuyersListBox.Items.Add(buyer.ToString());
            }
        }
    }
}
