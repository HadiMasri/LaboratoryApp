using Laboratory.Shared.ViewModels;
using Laboratory.UI.HttpHelper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void saveAddress_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelAddress_Click(object sender, RoutedEventArgs e)
        {
            txtCountry.IsReadOnly = true;
            txtNr.IsReadOnly = true;
            txtPostCode.IsReadOnly = true;
            txtProvincie.IsReadOnly = true;
            txtStreetName.IsReadOnly = true;
            saveAddress.Visibility = Visibility.Hidden;
            cancelAddress.Visibility = Visibility.Hidden;
        }

        private void editAddress_Click(object sender, RoutedEventArgs e)
        {
            if (expAddress.IsExpanded)
            {
                txtCountry.IsReadOnly = false;
                txtNr.IsReadOnly = false;
                txtPostCode.IsReadOnly = false;
                txtProvincie.IsReadOnly = false;
                txtStreetName.IsReadOnly = false;
                saveAddress.Visibility = Visibility.Visible;
                cancelAddress.Visibility = Visibility.Visible;
            }
            else
            {
                expAddress.IsExpanded = true;
                txtCountry.IsReadOnly = false;
                txtNr.IsReadOnly = false;
                txtPostCode.IsReadOnly = false;
                txtProvincie.IsReadOnly = false;
                txtStreetName.IsReadOnly = false;
                saveAddress.Visibility = Visibility.Visible;
                cancelAddress.Visibility = Visibility.Visible;
            }
        }

        private void comboFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FontFamily font = (FontFamily)comboFont.SelectedItem;
            lblFont.FontFamily = font;
        }

        private void editFont_Click(object sender, RoutedEventArgs e)
        {
            if (expFont.IsExpanded)
            {
                comboFont.IsEnabled = true;
                saveFontAndLogo.Visibility = Visibility.Visible;
                cancelFontAndLogo.Visibility = Visibility.Visible;
            }
            else
            {
                expFont.IsExpanded = true;
                comboFont.IsEnabled = true;
                saveFontAndLogo.Visibility = Visibility.Visible;
                cancelFontAndLogo.Visibility = Visibility.Visible;
            }
         
        }

        private void saveFontAndLogo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelFontAndLogo_Click(object sender, RoutedEventArgs e)
        {
            comboFont.IsEnabled = false;
            saveFontAndLogo.Visibility = Visibility.Hidden;
            cancelFontAndLogo.Visibility = Visibility.Hidden;
        }

        private  async void button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg";
            if (fileDialog.ShowDialog() == true)
            {
                SettingViewModel Setting = new SettingViewModel();
                var fileName = System.IO.Path.GetFileName(fileDialog.FileName);
                byte[] imageArray = System.IO.File.ReadAllBytes(fileDialog.FileName);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(imageArray);
                bi.EndInit();
                imgLogo.Source = bi;
                Setting.Image = imageArray;
                await SettingHelper.AddOrUpdateSettingAsync(Setting);
            }
        }
    }
}
