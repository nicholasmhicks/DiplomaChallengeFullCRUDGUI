using System;
using System.Collections.Generic;
using System.Data;
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

namespace CrudGUI.Pages
{
    /// <summary>
    /// Interaction logic for TourEventView.xaml
    /// </summary>
    public partial class TourEventView : Page
    {
        public TourEventView()
        {
            InitializeComponent();
        }

        private void Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
              
        }
        void PopulateGrid(List<dynamic> entities)
        {
            DataTable dt = new DataTable();

            DataColumn EventMonth = new DataColumn("Booking ID", typeof(string));
            DataColumn EventDay = new DataColumn("Client ID", typeof(string));
            DataColumn EventYear = new DataColumn("Tour Name", typeof(string));
            DataColumn EventTourName = new DataColumn("Event Month", typeof(string));
            DataColumn EventFee = new DataColumn("Event Day", typeof(string));

            dt.Columns.Add(EventMonth);
            dt.Columns.Add(EventDay);
            dt.Columns.Add(EventYear);
            dt.Columns.Add(EventTourName);
            dt.Columns.Add(EventFee);
            
            foreach (var i in entities)
            {
                DataRow _row = dt.NewRow();
                _row[0] = i.EventMonth;
                _row[1] = i.EventDay;
                _row[2] = i.EventYear;
                _row[3] = i.TourName;
                _row[4] = i.Fee;
                dt.Rows.Add(_row);
            }
            Data.ItemsSource = dt.DefaultView;
        }
    }
}
