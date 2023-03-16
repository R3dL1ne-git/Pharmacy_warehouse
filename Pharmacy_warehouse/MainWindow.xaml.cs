using Pharmacy_warehouse.Forms;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pharmacy_warehouse
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addDrugButtonClick_Click(object sender, RoutedEventArgs e)
        {
            AddEditDrug addEditDrug = new AddEditDrug(null);
            addEditDrug.Show();
        }
        private void addCategoryDrugsButtonClick_Click(object sender, RoutedEventArgs e)
        {
            AddEditCategoryDrug addEditCategoryDrug = new AddEditCategoryDrug(null);
            addEditCategoryDrug.Show();
        }

        private void addSupplierButtonClick_Click(object sender, RoutedEventArgs e)
        {
            AddEditSupplierWindow addEditSupplierWindow = new AddEditSupplierWindow(null);
            addEditSupplierWindow.Show();
        }

        private void addDrugstoreButtonClick_Click(object sender, RoutedEventArgs e)
        {
            AddEditDrugstoreWindow addEditDrugstoreWindow = new AddEditDrugstoreWindow(null);
            addEditDrugstoreWindow.Show();
        }

        private void addApplicationsButtonClick_Click(object sender, RoutedEventArgs e)
        {
            AddEditApplicationsWindow addEditApplicationsWindow = new AddEditApplicationsWindow(null);
            addEditApplicationsWindow.Show();
        }

        private void addPurchaseButtonClick_Click(object sender, RoutedEventArgs e)
        {
            AddEditPurchaseWindow addEditPurchaseWindow = new AddEditPurchaseWindow(null);
            addEditPurchaseWindow.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            AptekaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

            dataGridCategoryDrugs.ItemsSource = AptekaEntities.GetContext().Caterory_drug.ToList();
            dataGridSupplier.ItemsSource = AptekaEntities.GetContext().Supplier.ToList();
            dataGridPurchase.ItemsSource = AptekaEntities.GetContext().Purchase.ToList();
            dataGridDrugstore.ItemsSource = AptekaEntities.GetContext().Drugstore.ToList();
            dataGridDrug.ItemsSource = AptekaEntities.GetContext().Drug.ToList();
            dataGridApplications.ItemsSource = AptekaEntities.GetContext().Applications.ToList();
        }

        private void editDrugButtonClick_Click(object sender, RoutedEventArgs e)
        {
            AddEditDrug addEditDrug = new AddEditDrug((sender as Button).DataContext as Drug);
            addEditDrug.Show();
        }

        private void deleteDrugButtonClick_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
