using Pharmacy_warehouse.Classes;
using Pharmacy_warehouse.Model;
using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace Pharmacy_warehouse.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddEditPurchaseWindow.xaml
    /// </summary>
    public partial class AddEditPurchaseWindow : Window
    {
        private Purchase _currentPurchase = new Purchase();
        public AddEditPurchaseWindow(Purchase selectedPurchase)
        {
            InitializeComponent();

            if (selectedPurchase != null)
            {
                _currentPurchase = selectedPurchase;
            }

            DataContext = _currentPurchase;
            comboDrugs.ItemsSource = AptekaEntities.GetContext().Drug.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentPurchase.id_purchase == 0)
            {
                AptekaEntities.GetContext().Purchase.Add(_currentPurchase);
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
