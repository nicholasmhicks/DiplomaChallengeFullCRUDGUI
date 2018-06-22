using NLog;
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

namespace CrudGUI
{
    /// <summary>
    /// Interaction logic for IndexPage.xaml
    /// </summary>
    public partial class IndexPage : Page
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public IndexPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _logger.Trace($"Application launched at: {DateTime.Now}");
        }

        private void Tours_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Pages/Tours.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Bookings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Pages/Bookings.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Pages/Client.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
