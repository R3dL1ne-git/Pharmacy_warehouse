using Pharmacy_warehouse.Model;
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
using System.Windows.Shapes;

namespace Pharmacy_warehouse.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddEditDrug.xaml
    /// </summary>
    public partial class AddEditDrug : Window
    {
        private Drug _currentDrug = new Drug();
        public AddEditDrug(Drug selectedDrug)
        {
            InitializeComponent();

            if (selectedDrug != null)
            {
                _currentDrug = selectedDrug;
            }

            DataContext = _currentDrug;
            ComboCategory.ItemsSource = AptekaEntities.GetContext().Caterory_drug.ToList();
            ComboSupplier.ItemsSource = AptekaEntities.GetContext().Supplier.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentDrug.id_drug == 0)
            {
                AptekaEntities.GetContext().Drug.Add(_currentDrug);
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
