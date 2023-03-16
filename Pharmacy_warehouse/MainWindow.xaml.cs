using Pharmacy_warehouse.Forms;
using Pharmacy_warehouse.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

        private void searchTextBoxCategoryDrugs_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBoxCategoryDrugs.Text;
            ICollectionView view = CollectionViewSource.GetDefaultView(dataGridCategoryDrugs.ItemsSource);
            if (string.IsNullOrEmpty(searchText))
            {
                view.Filter = null;
            }
            else
            {
                view.Filter = obj =>
                {
                    var category = obj.GetType().GetProperty("category_name").GetValue(obj, null);
                    return category != null && category.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
                };
            }
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

        private void editCategoryDrugsButtonClick(object sender, RoutedEventArgs e)
        {
            AddEditCategoryDrug addEditCategoryDrug = new AddEditCategoryDrug((sender as Button).DataContext as Caterory_drug);
            addEditCategoryDrug.Show();
        }

        private void editSuppliersButtonClick(object sender, RoutedEventArgs e)
        {
            AddEditSupplierWindow addEditSupplier = new AddEditSupplierWindow((sender as Button).DataContext as Supplier);
            addEditSupplier.Show();
        }

        private void editApplicationsButtonClick(object sender, RoutedEventArgs e)
        {
            AddEditApplicationsWindow addEditApplications = new AddEditApplicationsWindow((sender as Button).DataContext as Applications);
            addEditApplications.Show();
        }

        private void editDrugButtonClick(object sender, RoutedEventArgs e)
        {
            AddEditDrug addEditDrug = new AddEditDrug((sender as Button).DataContext as Drug);
            addEditDrug.Show();
        }

        private void editDrugstoreButtonClick(object sender, RoutedEventArgs e)
        {
            AddEditDrugstoreWindow addEditDrugstore = new AddEditDrugstoreWindow((sender as Button).DataContext as Drugstore);
            addEditDrugstore.Show();
        }

        private void editPurchaseButtonClick(object sender, RoutedEventArgs e)
        {
            AddEditPurchaseWindow addEditPurchase = new AddEditPurchaseWindow((sender as Button).DataContext as Purchase);
            addEditPurchase.Show();
        }

        private void deleteDrugButtonClick_Click(object sender, RoutedEventArgs e)
        {
            var DrugsForRemoving = dataGridDrug.SelectedItems.Cast<Drug>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {DrugsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AptekaEntities.GetContext().Drug.RemoveRange(DrugsForRemoving);
                    AptekaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    dataGridDrug.ItemsSource = AptekaEntities.GetContext().Drug.ToList();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void deleteSupplierButtonClick_Click(object sender, RoutedEventArgs e)
        {
            var SupplierDrugForRemoving = dataGridSupplier.SelectedItems.Cast<Supplier>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {SupplierDrugForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AptekaEntities.GetContext().Supplier.RemoveRange(SupplierDrugForRemoving);
                    AptekaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    dataGridSupplier.ItemsSource = AptekaEntities.GetContext().Supplier.ToList();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void deleteCategoryDrugsButtonClick_Click(object sender, RoutedEventArgs e)
        {
            var CategoryDrugForRemoving = dataGridCategoryDrugs.SelectedItems.Cast<Caterory_drug>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {CategoryDrugForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AptekaEntities.GetContext().Caterory_drug.RemoveRange(CategoryDrugForRemoving);
                    AptekaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    dataGridCategoryDrugs.ItemsSource = AptekaEntities.GetContext().Caterory_drug.ToList();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void deleteDrugstoreButtonClick_Click(object sender, RoutedEventArgs e)
        {
            var DrugstoreDrugForRemoving = dataGridDrugstore.SelectedItems.Cast<Drugstore>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {DrugstoreDrugForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AptekaEntities.GetContext().Drugstore.RemoveRange(DrugstoreDrugForRemoving);
                    AptekaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    dataGridDrugstore.ItemsSource = AptekaEntities.GetContext().Drugstore.ToList();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void deleteApplicationsButtonClick_Click(object sender, RoutedEventArgs e)
        {
            var ApplicationsForRemoving = dataGridApplications.SelectedItems.Cast<Applications>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ApplicationsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AptekaEntities.GetContext().Applications.RemoveRange(ApplicationsForRemoving);
                    AptekaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    dataGridApplications.ItemsSource = AptekaEntities.GetContext().Applications.ToList();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void deletePurchaseButtonClick_Click(object sender, RoutedEventArgs e)
        {
            var PurchaseDrugForRemoving = dataGridPurchase.SelectedItems.Cast<Purchase>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {PurchaseDrugForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AptekaEntities.GetContext().Purchase.RemoveRange(PurchaseDrugForRemoving);
                    AptekaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    dataGridPurchase.ItemsSource = AptekaEntities.GetContext().Purchase.ToList();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
