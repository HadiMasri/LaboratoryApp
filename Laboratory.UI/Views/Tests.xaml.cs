using Laboratory.Shared.ViewModels;
using Laboratory.UI.HttpHelper;
using Laboratory.Utility;
using System;
using System.Collections.Generic;
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

namespace Laboratory.UI.Views
{
    /// <summary>
    /// Interaction logic for Tests.xaml
    /// </summary>
    public partial class Tests : UserControl
    {
        public Tests()
        {
            InitializeComponent();
            GetTestsAsync();
            GetCategory();
            GetUnits();
        }

        private void GetCategory()
        {
            List<CategoryViewModel> categories = CategoryHelper.GetCategoriesAsync().Result;
            comboCategory.ItemsSource = categories;
        }

        private void GetUnits()
        {
            List<UnitViewModel> units = UnitHelper.GetUnitsAsync().Result;
            comboUnits.ItemsSource = units;
        }
        public void GetTestsAsync()
        {
            Task<List<TestViewModel>> testsTask = TestHelper.GetTestsAsync();
            List<TestViewModel> tests = testsTask.Result;
            testsGrid.Items.Clear();
            foreach (var item in tests)
            {
                testsGrid.Items.Add(new TestViewModel
                {
                    Id = item.Id,
                    Code = item.Code,
                    AppearName = item.AppearName,
                    Name = item.Name,
                    Price = item.Price,
                    CategoryId = item.CategoryId,
                    Category = item.Category,
                    CategoryName = item.Category.Name,
                    UnitName = item.Unit.Name,
                    Note = item.Note
                });
            }
        }

        private async void add_Test(object sender, RoutedEventArgs e)
        {
            if ((string)addTest.Content == "Add")
            {
                await Add_Test();
            }
            else if ((string)addTest.Content == "Update")
            {
                await Update_Patient();
                addTest.Content = "Add";
            }
        }

        private async Task Add_Test()
        {
            var category = (CategoryViewModel)comboCategory.SelectedItem;
            var unit = (UnitViewModel)comboUnits.SelectedItem;

            TestViewModel test = new TestViewModel();
            test.Code = txtCode.Text;
            test.Name = txtTestName.Text;
            test.AppearName = txtAppearingName.Text;
            test.CategoryId = category.Id;
            test.UnitId = unit.Id;
            test.Price = Convert.ToInt32(txtPrice.Text);
            test.Note = txtNote.Text;
            await TestHelper.AddOrUpdateTestAsync(test);
            GetTestsAsync();
            ClearInput();
        }

        private async Task Update_Patient()
        {
            var category = (CategoryViewModel)comboCategory.SelectedItem;
            var unit = (UnitViewModel)comboUnits.SelectedItem;

            var test = (TestViewModel)testsGrid.SelectedItem;
            test.Code = txtCode.Text;
            test.Name = txtTestName.Text;
            test.AppearName = txtAppearingName.Text;
            test.CategoryId = category.Id;
            test.UnitId = unit.Id;
            test.Price = Convert.ToInt32(txtPrice.Text);
            test.Note = txtNote.Text;
            await TestHelper.AddOrUpdateTestAsync(test);
            GetTestsAsync();
            ClearInput();
        }

        public void ClearInput()
        {
            comboCategory.SelectedIndex = -1;
            comboUnits.SelectedIndex = -1;
            txtPrice.Clear();
            txtNote.Clear();
            txtCode.Clear();
            txtAppearingName.Clear();
            txtTestName.Clear();
        }

        private void testsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addTest.Content = "Update";
            var test = (TestViewModel)testsGrid.SelectedItem;
            if (test != null)
            {
                comboCategory.Text = test.Category.Name;
                comboUnits.Text = test.Unit.Name;
                txtCode.Text = test.Code;
                txtAppearingName.Text = test.AppearName;
                txtTestName.Text = test.Name;
                txtPrice.Text = test.Price.ToString() ;
                txtNote.Text = test.Note;
            }
        }

        public void Delete_Patient(int Id)
        {
            TestHelper.DeleteTestAsync(Id);
            GetTestsAsync();
            ClearInput();
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            var test = (TestViewModel)testsGrid.SelectedItem;
            var confirmDialog = new ConifrmationDialog(SD.Test_Delete_Confirmation, test.Id,null, this, "Test.png");
            confirmDialog.ShowDialog();
        }

        private void add_Range(object sender, RoutedEventArgs e)
        {
            var test = (TestViewModel)testsGrid.SelectedItem;
            var testRange = new TestRange(test.Id);
            testRange.ShowDialog();
        }

        private void btn_New_Test(object sender, RoutedEventArgs e)
        {
            ClearInput();
        }
    }
}
