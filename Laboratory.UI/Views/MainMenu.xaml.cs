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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu(string childWindow)
        {
            InitializeComponent();
            if (childWindow == SD.Patients)
            {
                mainGrid.Children.Add(new Patients());
            }
            else if (childWindow == SD.Tests)
            {
                mainGrid.Children.Add(new Tests());

            }
            else if (childWindow == SD.Materials)
            {
                mainGrid.Children.Add(new Materials());

            }
        }

        private void MainPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
            nav_pnl.Opacity = 1;
        }
        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            mainGrid.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            mainGrid.Opacity = 1;
        }

 



        private void Patients_Menu_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                ShowStackPanel.Begin();
                Tg_Btn.IsChecked = true;
            }
            else
            {
                mainGrid.Children.Clear();
                mainGrid.Children.Add(new Patients());
            }
        }

        private void Tests_Menu_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                ShowStackPanel.Begin();
                Tg_Btn.IsChecked = true;
            }
            else
            {
                mainGrid.Children.Clear();
                mainGrid.Children.Add(new Tests());
            }
        }
        private void Meterials_Menu_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                ShowStackPanel.Begin();
                Tg_Btn.IsChecked = true;
            }
            else
            {
                mainGrid.Children.Clear();
                mainGrid.Children.Add(new Materials());
            }
        }

        private void Settingss_Menu_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                ShowStackPanel.Begin();
                Tg_Btn.IsChecked = true;
            }
            else
            {
                mainGrid.Children.Clear();
                mainGrid.Children.Add(new Settings());
            }
        }
    }
}
