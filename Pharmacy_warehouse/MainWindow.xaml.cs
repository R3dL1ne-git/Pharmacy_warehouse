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
            dataGridCategoryDrugs.ItemsSource = AptekaEntities.GetContext().Caterory_drug.ToList();
            dataGridSupplier.ItemsSource = AptekaEntities.GetContext().Supplier.ToList();
            dataGridPurchase.ItemsSource = AptekaEntities.GetContext().Purchase.ToList();
            dataGridDrugstore.ItemsSource = AptekaEntities.GetContext().Drugstore.ToList();
            dataGridDrug.ItemsSource = AptekaEntities.GetContext().Drug.ToList();
            dataGridApplications.ItemsSource = AptekaEntities.GetContext().Applications.ToList();


        }

        private void TabControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AptekaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

            dataGridCategoryDrugs.ItemsSource = AptekaEntities.GetContext().Caterory_drug.ToList();
            dataGridSupplier.ItemsSource = AptekaEntities.GetContext().Supplier.ToList();
            dataGridPurchase.ItemsSource = AptekaEntities.GetContext().Purchase.ToList();
            dataGridDrugstore.ItemsSource = AptekaEntities.GetContext().Drugstore.ToList();
            dataGridDrug.ItemsSource = AptekaEntities.GetContext().Drug.ToList();
            dataGridApplications.ItemsSource = AptekaEntities.GetContext().Applications.ToList();

        }
    }
}
