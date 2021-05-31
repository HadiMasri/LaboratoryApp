using Laboratory.Shared.ViewModels;
using Laboratory.UI.HttpHelper;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for Patients.xaml
    /// </summary>
    public partial class Patients : UserControl
    {
        public Patients()
        {
            InitializeComponent();
            GetGenders();
            GetTitles();
        }
        private void GetGenders()
        {
            List<GenderViewModel> genders = GenderHelper.GetGendersAsync().Result;
            comboGender.ItemsSource = genders;
        }
        private void GetTitles()
        {
            List<TitleViewModel> titles = TitleHelper.GetTitlesAsync().Result;
            comboTitle.ItemsSource = titles;
        }
        private void Add_Patient(object sender, RoutedEventArgs e)
        {

        }
    }
}
