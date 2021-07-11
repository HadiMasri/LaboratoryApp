using Laboratory.Shared.ViewModels;
using Laboratory.UI.HttpHelper;
using Laboratory.Utility;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace Laboratory.UI.Views
{
    /// <summary>
    /// Interaction logic for Patients.xaml
    /// </summary>
    public partial class Patients : UserControl
    {
        int nr = 1;
        public Patients()
        {
            InitializeComponent();
            GetGenders();
            GetTitles();
            GetPatientsAsync();
            GetTestsAsync();
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
        private async void Add_Or_Update_Patient(object sender, RoutedEventArgs e)
        {
            if ((string)addPatient.Content == "Add")
            {
                await AddPatient();
            }
            else if ((string)addPatient.Content == "Update")
            {
                await Update_Patient();
            }
        }

        private async Task AddPatient()
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
                    Nr = nr++,
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
            nr = 1;
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
                });
            }
        }

        private void New_Patient(object sender, RoutedEventArgs e)
        {
            addPatient.Content = "Add";
            ClearInput();
        }

        private  void Confirm_Dialog(object sender, RoutedEventArgs e)
        {
            var patient = (PatientViewModel)patientsGrid.SelectedItem;
            var confirmDialog = new ConifrmationDialog(SD.Patient_Delete_Confirmation, patient.Id, this,null, "patient.png");
            confirmDialog.ShowDialog();
        }

        public void Delete_Patient(int Id)
        {
            PatientHelper.DeletePatientAsync(Id);
            GetPatientsAsync();
            ClearInput();
        }


        private async Task Update_Patient()
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
            ClearInput();
            addPatient.Content = "Add";
        }

        private void patientsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addPatient.Content = "Update";
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
            GetPatientTestsAsync(patient.Id);
        }
        public void GetPatientTestsAsync(int patientId)
        {
            Task<List<Patient_TestViewModel>> patientTestsTask = PatientTestHelper.GetPatientTestsAsync(patientId);
            List<Patient_TestViewModel> patientTests = patientTestsTask.Result;
            userTestsGrid.Items.Refresh();
            List<TestViewModel> patientTest = new List<TestViewModel>();
            foreach (var item in patientTests)
            {
                Task<List<TestRangeViewModel>> Ranges = TestRangeHelper.GetTestRangesAsync(item.TestId);
                List<TestRangeViewModel> testRanges = Ranges.Result;

                var range = new TestRangeViewModel();
                foreach (var item2 in testRanges)
                {
                    if (Enumerable.Range(item2.FromAge, item2.ToAge).Contains(item.Patient.Age) && item.Patient.Gender.Name == item2.Gender.Name)
                    {
                        range = item2;
                    }
                }
                patientTest.Add(new TestViewModel
                {
                    Id = item.Test.Id,
                    PatientId = item.PatientId,
                    PatientTestId = item.Id,
                    Name = item.Test.Name,
                    AppearName = item.Test.AppearName,
                    Range = $"{range.LowFrom} - {range.HighFrom}",
                    Code = item.Test.Code,
                    Result = item.Result,
                    Price = item.Test.Price,
                    CategoryName = item.Test.Category.Name,
                    Note = item.Test.Note,
                }) ;
            }
            userTestsGrid.ItemsSource = patientTest;
        }
        private async void add_Test_To_Patient(object sender, MouseButtonEventArgs e)
        {
            var patient = (PatientViewModel)patientsGrid.SelectedItem;
            if (patient != null)
            {
                var test = (TestViewModel)testsGrid.SelectedItem;
                var patientTest = new Patient_TestViewModel();
                patientTest.TestId = test.Id;
                patientTest.PatientId = patient.Id;
                await PatientTestHelper.AddOrUpdatePatientTestAsync(patientTest);
                GetPatientTestsAsync(patient.Id);
            }
            else
            {
                MessageBox.Show("Please select a patient first");
            }
        }

        private async void userTestsGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedTextbox = e.EditingElement as TextBox;
            var updatedResult = editedTextbox.Text;
            var patientTest = (TestViewModel)userTestsGrid.SelectedItem;
            Patient_TestViewModel updatedPatientTest = new Patient_TestViewModel();
            updatedPatientTest.Id = patientTest.PatientTestId;
            updatedPatientTest.PatientId = patientTest.PatientId;
            updatedPatientTest.TestId = patientTest.Id;
            updatedPatientTest.Result = updatedResult;
            await PatientTestHelper.AddOrUpdatePatientTestAsync(updatedPatientTest);
            GetPatientTestsAsync(patientTest.PatientId);
        }

        private void print(object sender, RoutedEventArgs e)
        {
            var patient = (PatientViewModel)patientsGrid.SelectedItem;
            flowDocument flow = new flowDocument(patient.Id);
            flow.ShowDialog();
        }
    }
}
