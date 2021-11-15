using Laboratory.Utility;
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
using System.Windows.Shapes;

namespace Laboratory.UI.Views
{
    /// <summary>
    /// Interaction logic for ConifrmationDialog.xaml
    /// </summary>
    public partial class ConifrmationDialog : Window
    {
        private readonly string _confirmationText;
        private readonly Patients _patients;
        private readonly Tests _tests;
        private readonly Materials _materials;
        private readonly int id;
        public ConifrmationDialog(string ConfirmationText, int Id, Patients patients = null, Tests tests = null, Materials materials = null, string imageName = null)
        {
            InitializeComponent();
            _confirmationText = ConfirmationText;
            id = Id;
            _patients = patients;
            _tests = tests;
            _materials = materials;
            confirmTxt.Text = ConfirmationText;
            confirmationImg.Source = new BitmapImage(new Uri($"../Assets/{imageName}", UriKind.RelativeOrAbsolute));

        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Do_Confirm(object sender, RoutedEventArgs e)
        {
            if (_confirmationText ==  SD.Patient_Delete_Confirmation)
            {
                _patients.Delete_Patient(id);
            }
            else if (_confirmationText == SD.Test_Delete_Confirmation)
            {
                _tests.Delete_Patient(id);
            }else if (_confirmationText == SD.Material_Delete_Confirmation)
            {
                _materials.Delete_Material(id);
            }
            this.Close();
        }

        private void Close_Confirm_Dialog(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
