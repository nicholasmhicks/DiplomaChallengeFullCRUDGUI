using CrudGUI.Models;
using NLog;
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
    /// Interaction logic for Bookings.xaml
    /// </summary>
    public partial class Bookings : Page
    {

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        DataAccess _da = new DataAccess();

        public Bookings()
        {
            InitializeComponent();
        }


        private void Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            if (row != null)
            {
                DataGridCell RowBookingId = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowClientId = dataGrid.Columns[1].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowTourName = dataGrid.Columns[2].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowEventMonth = dataGrid.Columns[3].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowEventDay = dataGrid.Columns[4].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowEventYear = dataGrid.Columns[5].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowPayment = dataGrid.Columns[6].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowDateBooked = dataGrid.Columns[7].GetCellContent(row).Parent as DataGridCell;

                BookingIdTextBox.Text = ((TextBlock)RowBookingId.Content).Text;
                ClientIdTextBox.Text = ((TextBlock)RowClientId.Content).Text;
                TourNameTextBox.Text = ((TextBlock)RowTourName.Content).Text;
                EventMonthTextBox.Text = ((TextBlock)RowEventMonth.Content).Text;
                EventDayTextBox.Text = ((TextBlock)RowEventDay.Content).Text;
                EventYearTextBox.Text = ((TextBlock)RowEventYear.Content).Text;
                PaymentTextBox.Text = ((TextBlock)RowPayment.Content).Text;
                DateBookedTextBox.Text = ((TextBlock)RowDateBooked.Content).Text;
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.PopulateGrid(await _da.GetEntitiesAsync("api/BookingsViews"));
        }

        void PopulateGrid(List<dynamic> entities)
        {
            DataTable dt = new DataTable();

            DataColumn BookingId = new DataColumn("Booking ID", typeof(string));
            DataColumn ClientId = new DataColumn("Client ID", typeof(string));
            DataColumn TourName = new DataColumn("Tour Name", typeof(string));
            DataColumn EventMonth = new DataColumn("Event Month", typeof(string));
            DataColumn EventDay = new DataColumn("Event Day", typeof(string));
            DataColumn EventYear = new DataColumn("Event Year", typeof(string));
            DataColumn Payment = new DataColumn("Payment", typeof(string));
            DataColumn DateBooked = new DataColumn("Date Booked", typeof(string));

            dt.Columns.Add(BookingId);
            dt.Columns.Add(ClientId);
            dt.Columns.Add(TourName);
            dt.Columns.Add(EventMonth);
            dt.Columns.Add(EventDay);
            dt.Columns.Add(EventYear);
            dt.Columns.Add(Payment);
            dt.Columns.Add(DateBooked);

            foreach (var i in entities)
            {
                DataRow _row = dt.NewRow();
                _row[0] = i.BookingId;
                _row[1] = i.ClientId;
                _row[2] = i.TourName;
                _row[3] = i.EventMonth;
                _row[4] = i.EventDay;
                _row[5] = i.EventYear;
                _row[6] = i.Payment;
                _row[7] = i.DateBooked;
                dt.Rows.Add(_row);
            }
            Data.ItemsSource = dt.DefaultView;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Booking temp = new Booking();
                temp.BookingId = Int32.Parse(BookingIdTextBox.Text);
                temp.ClientId = Int32.Parse(ClientIdTextBox.Text);
                temp.TourName = TourNameTextBox.Text;
                temp.EventMonth = EventMonthTextBox.Text;
                temp.EventDay = EventDayTextBox.Text;
                temp.EventYear = EventYearTextBox.Text;
                temp.Payment = Int32.Parse(PaymentTextBox.Text);
                temp.DateBooked = DateBookedTextBox.Text;

                if (await _da.PutEntityAsync($"api/Bookings/{BookingIdTextBox.Text}", temp))
                {
                    this.PopulateGrid(await _da.GetEntitiesAsync("api/BookingsViews"));
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Booking temp = new Booking();
                temp.BookingId = Int32.Parse(BookingIdTextBox.Text);
                temp.ClientId = Int32.Parse(ClientIdTextBox.Text);
                temp.TourName = TourNameTextBox.Text;
                temp.EventMonth = EventMonthTextBox.Text;
                temp.EventDay = EventDayTextBox.Text;
                temp.EventYear = EventYearTextBox.Text;
                temp.Payment = Int32.Parse(PaymentTextBox.Text);
                temp.DateBooked = DateBookedTextBox.Text;

                if (await _da.PostEntityAsync($"api/Bookings/{BookingIdTextBox.Text}", temp))
                {
                    this.PopulateGrid(await _da.GetEntitiesAsync("api/BookingsViews"));
                }
                else
                {
                    MessageBox.Show("Post Failed");
                    throw new Exception("Post Failed");
                }
            }
            catch (ValidationFailureException ex)
            {
                _logger.Debug($"Client update failed with message: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.Fatal($"Fatal exception thrown on client: {ex.Message}");
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (await _da.DeleteEntityAsync($"api/Bookings/{BookingIdTextBox.Text}"))
                {
                    this.PopulateGrid(await _da.GetEntitiesAsync("api/BookingsViews"));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
