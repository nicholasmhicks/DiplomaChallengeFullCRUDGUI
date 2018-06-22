using CrudGUI.Models;
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
    /// Interaction logic for Tours.xaml
    /// </summary>
    public partial class Tours : Page
    {
        DataAccess _da = new DataAccess();

        public Tours()
        {
            InitializeComponent();
        }

        private void Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            if (row != null)
            {
                DataGridCell RowTourName = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                DataGridCell RowDescription = dataGrid.Columns[1].GetCellContent(row).Parent as DataGridCell;

                TourNameTextBox.Text = ((TextBlock)RowTourName.Content).Text;
                Description.Text = ((TextBlock)RowDescription.Content).Text;
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.PopulateGrid(await _da.GetEntitiesAsync("api/TourViews"));
        }

        void PopulateGrid(List<dynamic> entities)
        {
            DataTable dt = new DataTable();

            DataColumn TourName = new DataColumn("Tour Name", typeof(string));
            DataColumn Description = new DataColumn("Description", typeof(string));

            dt.Columns.Add(TourName);
            dt.Columns.Add(Description);

            foreach (var i in entities)
            {
                DataRow _row = dt.NewRow();
                _row[0] = i.TourName;
                _row[1] = i.Description;
                dt.Rows.Add(_row);
            }
            Data.ItemsSource = dt.DefaultView;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tour temp = new Tour();
                temp.TourName = TourNameTextBox.Text;
                temp.Description = Description.Text;

                if (await _da.PutEntityAsync($"api/Tours/{TourNameTextBox.Text}", temp))
                {
                    this.PopulateGrid(await _da.GetEntitiesAsync("api/TourViews"));
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
                Tour temp = new Tour();
                temp.TourName = TourNameTextBox.Text;
                temp.Description = Description.Text;

                if (await _da.PostEntityAsync($"api/Tours/{TourNameTextBox.Text}", temp))
                {
                    this.PopulateGrid(await _da.GetEntitiesAsync("api/TourViews"));
                }
            }catch (Exception ex)
            {
                throw;
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (await _da.DeleteEntityAsync($"api/Tours/{TourNameTextBox.Text}"))
                {
                    this.PopulateGrid(await _da.GetEntitiesAsync("api/TourViews"));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
