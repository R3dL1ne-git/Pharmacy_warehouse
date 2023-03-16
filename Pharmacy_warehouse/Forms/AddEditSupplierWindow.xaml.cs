using Pharmacy_warehouse.Classes;
using Pharmacy_warehouse.Model;
using System;
using System.Text;
using System.Windows;

namespace Pharmacy_warehouse.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddEditSupplierWindow.xaml
    /// </summary>
    public partial class AddEditSupplierWindow : Window
    {
        private Supplier _currentSupplier = new Supplier();
        public AddEditSupplierWindow(Supplier selectedSupplier)
        {
            InitializeComponent();

            if (selectedSupplier != null)
            {
                _currentSupplier = selectedSupplier;
            }
            DataContext = _currentSupplier;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentSupplier.id_supplier == 0)
            {
                AptekaEntities.GetContext().Supplier.Add(_currentSupplier);
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
                //throw;
            }
        }
    }
}
