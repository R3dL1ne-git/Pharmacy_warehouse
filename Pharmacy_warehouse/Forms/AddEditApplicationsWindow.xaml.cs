using Pharmacy_warehouse.Classes;
using Pharmacy_warehouse.Model;
using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace Pharmacy_warehouse.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddEditApplicationsWindow.xaml
    /// </summary>
    public partial class AddEditApplicationsWindow : Window
    {
        private Applications _currentApplications = new Applications();
        public AddEditApplicationsWindow(Applications selectedApp)
        {
            InitializeComponent();

            if (selectedApp != null)
            {
                _currentApplications = selectedApp;
            }

            DataContext = _currentApplications;
            ComboDrugStores.ItemsSource = AptekaEntities.GetContext().Drugstore.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            //
            // errors.AppendLine("Укажите дату");

            if (_currentApplications.id_applications == 0)
            {
                AptekaEntities.GetContext().Applications.Add(_currentApplications);
            }

            try
            {
                AptekaEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }
        }
    }
}
