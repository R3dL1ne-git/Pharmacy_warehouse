using Pharmacy_warehouse.Classes;
using Pharmacy_warehouse.Model;
using System;
using System.Text;
using System.Windows;

namespace Pharmacy_warehouse.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddEditDrugstoreWindow.xaml
    /// </summary>
    public partial class AddEditDrugstoreWindow : Window
    {
        private Drugstore _currentDrugstore = new Drugstore();
        public AddEditDrugstoreWindow(Drugstore selectedDrugstore)
        {
            InitializeComponent();

            if (selectedDrugstore != null)
            {
                _currentDrugstore = selectedDrugstore;
            }

            DataContext = _currentDrugstore;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentDrugstore.id_drugstore == 0)
            {
                AptekaEntities.GetContext().Drugstore.Add(_currentDrugstore);
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
