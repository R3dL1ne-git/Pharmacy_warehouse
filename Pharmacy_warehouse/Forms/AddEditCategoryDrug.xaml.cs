using Pharmacy_warehouse.Classes;
using Pharmacy_warehouse.Model;
using System;
using System.Text;
using System.Windows;

namespace Pharmacy_warehouse.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddEditCategoryDrug.xaml
    /// </summary>
    public partial class AddEditCategoryDrug : Window
    {
        private Caterory_drug _currentCategory = new Caterory_drug();
        public AddEditCategoryDrug(Caterory_drug selectedCategory)
        {
            InitializeComponent();

            if (selectedCategory != null)
            {
                _currentCategory = selectedCategory;
            }

            DataContext = _currentCategory;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentCategory.id_category == 0)
            {
                AptekaEntities.GetContext().Caterory_drug.Add(_currentCategory);
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
