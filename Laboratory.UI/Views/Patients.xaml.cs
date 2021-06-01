using Laboratory.Shared.ViewModels;
using Laboratory.UI.HttpHelper;
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
    /// Interaction logic for Patients.xaml
    /// </summary>
    public partial class Patients : UserControl
    {
        public Patients()
        {
            InitializeComponent();
            GetGenders();
            GetTitles();
            GetPatientsAsync();
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
        private async void Add_Patient(object sender, RoutedEventArgs e)
        {
            var title = (TitleViewModel)comboTitle.SelectedItem;
            var gender = (GenderViewModel)comboGender.SelectedItem;

            PatientViewModel patient = new PatientViewModel();
            patient.TitleId = title.Id;
            patient.Name = txtName.Text;
            patient.LastName = txtLastName.Text;
            patient.FatherName = txtFatherName.Text;
            patient.MotherName = txtMotherName.Text;
            patient.Age = Convert.ToInt32(txtAge.Text);
            patient.ArriveTime = arriveTime.Text;
            patient.GenderId = gender.Id;
            patient.DoctorName = txtDoctorName.Text;
            patient.RoomNr = txtRoomNr.Text;
            patient.PhoneNr = txtPhoneNr.Text;
            patient.Diagnosis = txtDiagnosis.Text;
            await PatientHelper.AddOrUpdatePatientAsync(patient);
            GetPatientsAsync();
            ClearInput();
        }

        public void ClearInput()
        {
            comboTitle.SelectedIndex = -1;
            comboGender.SelectedIndex = -1;
            txtName.Clear();
            txtLastName.Clear();
            txtFatherName.Clear();
            txtMotherName.Clear();
            txtAge.Clear();
            arriveTime.SelectedTime = null;
            txtDoctorName.Clear();
            txtRoomNr.Clear();
            txtPhoneNr.Clear();
            txtDiagnosis.Clear();
        }

        public void GetPatientsAsync()
        {
            Task<List<PatientViewModel>> patientsTask = PatientHelper.GetPatientsAsync();
            List<PatientViewModel> patients = patientsTask.Result;
            patientsGrid.Items.Clear();
            foreach (var item in patients)
            {
                patientsGrid.Items.Add(new PatientViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Name = item.Name,
                    FullName = $"{item.Name} {item.LastName}",
                    LastName = item.LastName,
                    FatherName = item.FatherName,
                    MotherName = item.MotherName,
                    Age = item.Age,
                    ArriveTime = item.ArriveTime,
                    GenderId = item.GenderId,
                    Gender = item.Gender,
                    DoctorName = item.DoctorName,
                    RoomNr = item.RoomNr,
                    PhoneNr = item.PhoneNr,
                    Diagnosis = item.Diagnosis
                });
            }

        }

        private void New_Patient(object sender, RoutedEventArgs e)
        {
            ClearInput();
        }

        private  void Delete_Patient(object sender, RoutedEventArgs e)
        {
            var patient = (PatientViewModel)patientsGrid.SelectedItem;
            PatientHelper.DeletePatientAsync(patient.Id);
            GetPatientsAsync();
        }

        private async void Update_Patient(object sender, RoutedEventArgs e)
        {
            var title = (TitleViewModel)comboTitle.SelectedItem;
            var gender = (GenderViewModel)comboGender.SelectedItem;
            var patient = (PatientViewModel)patientsGrid.SelectedItem;

            patient.TitleId = title.Id;
            patient.Name = txtName.Text;
            patient.LastName = txtLastName.Text;
            patient.FatherName = txtFatherName.Text;
            patient.MotherName = txtMotherName.Text;
            patient.Age = Convert.ToInt32(txtAge.Text);
            patient.ArriveTime = arriveTime.Text;
            patient.GenderId = gender.Id;
            patient.DoctorName = txtDoctorName.Text;
            patient.RoomNr = txtRoomNr.Text;
            patient.PhoneNr = txtPhoneNr.Text;
            patient.Diagnosis = txtDiagnosis.Text;
            await PatientHelper.AddOrUpdatePatientAsync(patient);
            GetPatientsAsync();
        }

        private void patientsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var patient = (PatientViewModel)patientsGrid.SelectedItem;
            if (patient!= null)
            {
                comboTitle.Text = patient.Title.Name;
                txtName.Text = patient.Name;
                txtLastName.Text = patient.LastName;
                txtFatherName.Text = patient.FatherName;
                txtMotherName.Text = patient.MotherName;
                txtAge.Text = patient.Age.ToString();
                arriveTime.Text = patient.ArriveTime;
                comboGender.Text = patient.Gender.Name;
                txtDoctorName.Text = patient.DoctorName;
                txtRoomNr.Text = patient.RoomNr;
                txtPhoneNr.Text = patient.PhoneNr;
                txtDiagnosis.Text = patient.Diagnosis;
            }
 
        }
    }
}
