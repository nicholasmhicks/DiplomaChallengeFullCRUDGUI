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
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Page
    {

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        DataAccess _da = new DataAccess();
        public Client()
        {
            InitializeComponent();
        }

        void PopulateGrid(List<dynamic> entities)
        {
            DataTable dt = new DataTable();

            DataColumn ClientId = new DataColumn("Client ID", typeof(string));
            DataColumn Surname = new DataColumn("Surname", typeof(string));
            DataColumn GivenName = new DataColumn("Given Name", typeof(string));
            DataColumn Gender = new DataColumn("Gender", typeof(string));

            dt.Columns.Add(ClientId);
            dt.Columns.Add(Surname);
            dt.Columns.Add(GivenName);
            dt.Columns.Add(Gender);

            foreach (var i in entities)
            {
                DataRow _row = dt.NewRow();
                _row[0] = i.ClientId;
                _row[1] = i.Surname;
                _row[2] = i.GivenName;
                _row[3] = i.Gender;
                dt.Rows.Add(_row);
            }
            Data.ItemsSource = dt.DefaultView;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.PopulateGrid(await _da.GetEntitiesAsync("api/ClientViews"));
        }
        private void Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            if (row != null)
            {
                DataGridCell RowClientId = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowSurname = dataGrid.Columns[1].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowGivenName = dataGrid.Columns[2].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowGender = dataGrid.Columns[3].GetCellContent(row).Parent as DataGridCell;

                ClientIdTextBox.Text = ((TextBlock)RowClientId.Content).Text;
                SurnameTextBox.Text = ((TextBlock)RowSurname.Content).Text;
                GivenNameTextBox.Text = ((TextBlock)RowGivenName.Content).Text;
                GenderTextBox.Text = ((TextBlock)RowGender.Content).Text;
            }
        }
        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Models.Client temp = new Models.Client();
                temp.ClientId = Int32.Parse(ClientIdTextBox.Text);
                temp.Surname = SurnameTextBox.Text;
                temp.GivenName = GivenNameTextBox.Text;
                temp.Gender = GenderTextBox.Text;

                if (temp.Surname == "" || temp.GivenName == "")
                {
                    MessageBox.Show("Can not enter blank names");
                    throw new ValidationFailureException("Blank Name Entered");
                }
                if (temp.Gender == "m" || temp.Gender == "M" || temp.Gender == "f" || temp.Gender == "F")
                {
                    if (await _da.PostEntityAsync($"api/Clients/{ClientIdTextBox.Text}", temp))
                    {
                        this.PopulateGrid(await _da.GetEntitiesAsync("api/ClientViews"));
                    }
                    else
                    {
                        MessageBox.Show("Post Failed");
                        throw new Exception("Post Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Gender, must be 'm' 'M' 'f' 'F'");
                }

            }
            catch (ValidationFailureException ex)
            {
                _logger.Debug($"Client update failed with message: {ex.Message}");
            }catch (Exception ex)
            {
                MessageBox.Show("Fatal Exception Thrown, check that your client ID is a number with no letters or special characters");
                _logger.Fatal($"Fatal exception thrown on client: {ex.Message}");
            }
        }
        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Models.Client temp = new Models.Client();
                temp.ClientId = Int32.Parse(ClientIdTextBox.Text);
                temp.Surname = SurnameTextBox.Text;
                temp.GivenName = GivenNameTextBox.Text;
                temp.Gender = GenderTextBox.Text;

                if (temp.Surname == "" || temp.GivenName == "")
                {
                    MessageBox.Show("Can not enter blank names");
                    throw new ValidationFailureException("Blank Name Entered");
                }
                if (temp.Gender == "m" || temp.Gender == "M" || temp.Gender == "f" || temp.Gender == "F")
                {
                    if (await _da.PutEntityAsync($"api/Clients/{ClientIdTextBox.Text}", temp))
                    {
                        this.PopulateGrid(await _da.GetEntitiesAsync("api/ClientViews"));
                    }
                    else
                    {
                        throw new Exception("Post Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Gender, must be 'm' 'M' 'f' 'F'");
                }

            }
            catch (ValidationFailureException ex)
            {
                _logger.Debug($"Client update failed with message: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal Exception Thrown, check that your client ID is a number with no letters or special characters");
                _logger.Fatal($"Fatal exception thrown on client: {ex.Message}");
            }
        }
        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ClientIdTextBox.Text == "")
                {
                    MessageBox.Show("Client Id can not be null to delete");
                    throw new ValidationFailureException("Client id was empty on delete attempt");
                }
                if (await _da.DeleteEntityAsync($"api/Clients/{ClientIdTextBox.Text}"))
                {
                    this.PopulateGrid(await _da.GetEntitiesAsync("api/ClientViews"));
                }
            }catch (ValidationFailureException ex)
            {
                _logger.Debug($"Client delete failed with message: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal Exception Thrown, check that your client ID is a number with no letters or special characters");
                _logger.Fatal($"Fatal exception thrown on client: {ex.Message}");
            }

        }
    }
}
