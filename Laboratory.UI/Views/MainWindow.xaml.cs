using Laboratory.Utility;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Laboratory.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Open_Patients(object sender, RoutedEventArgs e)
        {
            var mainMEnu = new MainMenu(SD.Patients);

            
            mainMEnu.Owner = this;
            this.Hide();
            mainMEnu.ShowDialog();
        }

        private void Open_Tests_Dialog(object sender, RoutedEventArgs e)
        {
            var mainMEnu = new MainMenu(SD.Tests);
            mainMEnu.Owner = this;
            this.Hide();
            mainMEnu.ShowDialog();
        }
    }
}
