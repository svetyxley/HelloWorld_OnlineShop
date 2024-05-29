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
            this.pages.Add("Manufacturer", new Manufacturer());
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
    }
}