using Laboratory.Shared.ViewModels;
using Laboratory.UI.HttpHelper;
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

namespace Laboratory.UI.Views
{
    /// <summary>
    /// Interaction logic for TestRange.xaml
    /// </summary>
    public partial class TestRange : Window
    {
        private readonly int testId;
        private int testRangeId;

        public TestRange(int TestId)
        {
            InitializeComponent();
            GetGender();
            testId = TestId;
            GetTestRangesAsync();
        }
        public void GetTestRangesAsync()
        {
            Task<List<TestRangeViewModel>> testRangesTask = TestRangeHelper.GetTestRangesAsync();
            List<TestRangeViewModel> testRanges = testRangesTask.Result;
            foreach (var item in testRanges)
            {
                if (testRanges.ElementAtOrDefault(0) != null)
                {
                    testRangeId = item.Id;
                    comboGender.Text = item.Gender.Name;
                    comboGender.SelectedValuePath = item.Gender.Id.ToString();
                    txtFromAge.Text = item.FromAge.ToString();
                    txtToAge.Text = item.ToAge.ToString();
                    txtRange.Text = item.Range.ToString();
                    txtLowFrom.Text = item.LowFrom.ToString();
                    txtHighFrom.Text = item.HighFrom.ToString();
                }
                if (testRanges.ElementAtOrDefault(1) != null)
                {
                    testRangeId = item.Id;
                    comboGender2.Text = item.Gender.Name;
                    comboGender2.SelectedValuePath = item.Gender.Id.ToString();
                    txtFromAge2.Text = item.FromAge.ToString();
                    txtToAge2.Text = item.ToAge.ToString();
                    txtRange2.Text = item.Range.ToString();
                    txtLowFrom2.Text = item.LowFrom.ToString();
                    txtHighFrom2.Text = item.HighFrom.ToString();
                }
                if (testRanges.ElementAtOrDefault(2) != null)
                {
                    testRangeId = item.Id;
                    comboGender3.Text = item.Gender.Name;
                    comboGender3.SelectedValuePath = item.Gender.Id.ToString();
                    txtFromAge3.Text = item.FromAge.ToString();
                    txtToAge3.Text = item.ToAge.ToString();
                    txtRange3.Text = item.Range.ToString();
                    txtLowFrom3.Text = item.LowFrom.ToString();
                    txtHighFrom3.Text = item.HighFrom.ToString();
                }
                if (testRanges.ElementAtOrDefault(3) != null)
                {
                    testRangeId = item.Id;
                    comboGender4.Text = item.Gender.Name;
                    comboGender4.SelectedValuePath = item.Gender.Id.ToString();
                    txtFromAge4.Text = item.FromAge.ToString();
                    txtToAge4.Text = item.ToAge.ToString();
                    txtRange4.Text = item.Range.ToString();
                    txtLowFrom4.Text = item.LowFrom.ToString();
                    txtHighFrom4.Text = item.HighFrom.ToString();
                }
                if (testRanges.ElementAtOrDefault(4) != null)
                {
                    testRangeId = item.Id;
                    comboGender5.Text = item.Gender.Name;
                    comboGender5.SelectedValuePath = item.Gender.Id.ToString();
                    txtFromAge5.Text = item.FromAge.ToString();
                    txtToAge5.Text = item.ToAge.ToString();
                    txtRange5.Text = item.Range.ToString();
                    txtLowFrom5.Text = item.LowFrom.ToString();
                    txtHighFrom5.Text = item.HighFrom.ToString();
                }
            }
        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void GetGender()
        {
            List<GenderViewModel> genders = GenderHelper.GetGendersAsync().Result;
            comboGender.ItemsSource = genders;
            comboGender2.ItemsSource = genders;
            comboGender3.ItemsSource = genders;
            comboGender4.ItemsSource = genders;
            comboGender5.ItemsSource = genders;

        }
        private void btn_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btn_Add_Range(object sender, RoutedEventArgs e)
        {
            try
            {
                if (comboGender.SelectedItem != null && txtFromAge.Text != "" && txtToAge.Text != "" && txtRange.Text != "" && txtLowFrom.Text != "" && txtHighFrom.Text != "")
                {
                    var gender = (GenderViewModel)comboGender.SelectedItem;
                    TestRangeViewModel testRange = new TestRangeViewModel();
                    testRange.GenderId = gender.Id;
                    testRange.FromAge = Convert.ToInt32(txtFromAge.Text);
                    testRange.ToAge = Convert.ToInt32(txtToAge.Text);
                    testRange.Range = Convert.ToInt32(txtRange.Text);
                    testRange.LowFrom = Convert.ToInt32(txtLowFrom.Text);
                    testRange.HighFrom = Convert.ToInt32(txtHighFrom.Text);
                    testRange.TestId = testId;
                    await TestRangeHelper.AddOrUpdateTestAsync(testRange);
                }
                if (comboGender2.SelectedItem != null && txtFromAge2.Text != "" && txtToAge2.Text != "" && txtRange2.Text != "" && txtLowFrom2.Text != "" && txtHighFrom2.Text != "")
                {
                    var gender = (GenderViewModel)comboGender2.SelectedItem;
                    TestRangeViewModel testRange = new TestRangeViewModel();
                    testRange.GenderId = gender.Id;
                    testRange.FromAge = Convert.ToInt32(txtFromAge2.Text);
                    testRange.ToAge = Convert.ToInt32(txtToAge2.Text);
                    testRange.Range = Convert.ToInt32(txtRange2.Text);
                    testRange.LowFrom = Convert.ToInt32(txtLowFrom2.Text);
                    testRange.HighFrom = Convert.ToInt32(txtHighFrom2.Text);
                    testRange.TestId = testId;
                    await TestRangeHelper.AddOrUpdateTestAsync(testRange);
                }
                if (comboGender3.SelectedItem != null && txtFromAge3.Text != "" && txtToAge3.Text != "" && txtRange3.Text != "" && txtLowFrom3.Text != "" && txtHighFrom3.Text != "")
                {
                    var gender = (GenderViewModel)comboGender3.SelectedItem;
                    TestRangeViewModel testRange = new TestRangeViewModel();
                    testRange.GenderId = gender.Id;
                    testRange.FromAge = Convert.ToInt32(txtFromAge3.Text);
                    testRange.ToAge = Convert.ToInt32(txtToAge3.Text);
                    testRange.Range = Convert.ToInt32(txtRange3.Text);
                    testRange.LowFrom = Convert.ToInt32(txtLowFrom3.Text);
                    testRange.HighFrom = Convert.ToInt32(txtHighFrom3.Text);
                    testRange.TestId = testId;
                    await TestRangeHelper.AddOrUpdateTestAsync(testRange);
                }
                if (comboGender4.SelectedItem != null && txtFromAge4.Text != "" && txtToAge4.Text != "" && txtRange4.Text != "" && txtLowFrom4.Text != "" && txtHighFrom4.Text != "")
                {
                    var gender = (GenderViewModel)comboGender4.SelectedItem;
                    TestRangeViewModel testRange = new TestRangeViewModel();
                    testRange.GenderId = gender.Id;
                    testRange.FromAge = Convert.ToInt32(txtFromAge4.Text);
                    testRange.ToAge = Convert.ToInt32(txtToAge4.Text);
                    testRange.Range = Convert.ToInt32(txtRange4.Text);
                    testRange.LowFrom = Convert.ToInt32(txtLowFrom4.Text);
                    testRange.HighFrom = Convert.ToInt32(txtHighFrom4.Text);
                    testRange.TestId = testId;
                    await TestRangeHelper.AddOrUpdateTestAsync(testRange);
                }
                if (comboGender5.SelectedItem != null && txtFromAge5.Text != "" && txtToAge5.Text != "" && txtRange5.Text != "" && txtLowFrom5.Text != "" && txtHighFrom5.Text != "")
                {
                    var gender = (GenderViewModel)comboGender5.SelectedItem;
                    TestRangeViewModel testRange = new TestRangeViewModel();
                    testRange.GenderId = gender.Id;
                    testRange.FromAge = Convert.ToInt32(txtFromAge5.Text);
                    testRange.ToAge = Convert.ToInt32(txtToAge5.Text);
                    testRange.Range = Convert.ToInt32(txtRange5.Text);
                    testRange.LowFrom = Convert.ToInt32(txtLowFrom5.Text);
                    testRange.HighFrom = Convert.ToInt32(txtHighFrom5.Text);
                    testRange.TestId = testId;
                    await TestRangeHelper.AddOrUpdateTestAsync(testRange);
                }
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}
