using Laboratory.Shared.ViewModels;
using Laboratory.UI.HttpHelper;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace Laboratory.UI.Views
{
    /// <summary>
    /// Interaction logic for flowDocument.xaml
    /// </summary>
    public partial class flowDocument : Window
    {
        private int currentYposition_valuese = 250;
        private int currentYposition_CategroryRectangle = 240;
        private int currentYposition_CategroryName = 255;
        private int currentYposition_TableHeader = 275;
        private bool newPage = false;
        private int numberOfItemsPerPage = 0;
        private readonly int _patientId;
        private string category;
        XGraphics gfx;

        public flowDocument(int paitentId)
        {
            InitializeComponent();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            _patientId = paitentId;
            print();

        }

        public void print()
        {
            Task<List<Patient_TestViewModel>> patientTestsTask = PatientTestHelper.GetPatientTestsAsync(_patientId);
            List<Patient_TestViewModel> patientTests = patientTestsTask.Result.OrderBy(c => c.Test.Category.Name).ToList();


            PdfDocument document = new PdfDocument();
            document.Info.Title = "PDF Example";
            PdfPage page = document.AddPage();
            gfx = XGraphics.FromPdfPage(page);

            GenerateDocumentHeader();

            for (int i = 0; i < patientTests.Count; i++)
            {
                numberOfItemsPerPage += 1;
                if (numberOfItemsPerPage <= 10)
                {
                    if (numberOfItemsPerPage == 10)
                    {
                        newPage = true;
                        numberOfItemsPerPage = 0;
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        GenerateDocumentHeader();
                        currentYposition_valuese = 250;
                        currentYposition_CategroryRectangle = 240;
                        currentYposition_CategroryName = 255;
                        currentYposition_TableHeader = 275;
                    }
                    if (patientTests[i].Test.Category.Name != category || newPage == true)
                        {
                            category = patientTests[i].Test.Category.Name;
                            var brushCategory = new XSolidBrush(XColor.FromArgb(30, 144, 255));
                            XRect snoColumnValCategory = new XRect(60, currentYposition_CategroryRectangle, 485, 20);
                            gfx.DrawRectangle(XPens.Transparent, brushCategory, snoColumnValCategory);
                        if (patientTests[i].Test.Category.Name.Length <= 5)
                        {
                            gfx.DrawString(patientTests[i].Test.Category.Name, new XFont("Arial", 15, XFontStyle.Regular), XBrushes.White, new XPoint(290, currentYposition_CategroryName));
                        }
                        else
                        {
                            gfx.DrawString(patientTests[i].Test.Category.Name, new XFont("Arial", 15, XFontStyle.Regular), XBrushes.White, new XPoint(270, currentYposition_CategroryName));
                        }
                        gfx.DrawString("Name", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(100, currentYposition_TableHeader));
                            gfx.DrawString("Category", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(190, currentYposition_TableHeader));
                            gfx.DrawString("Range", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(280, currentYposition_TableHeader));
                            gfx.DrawString("Result", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(370, currentYposition_TableHeader));
                            gfx.DrawString("Unit", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(460, currentYposition_TableHeader));

                            newPage = false;
                            currentYposition_valuese += 50;
                        }
                    Task<List<TestRangeViewModel>> Ranges = TestRangeHelper.GetTestRangesAsync(patientTests[i].TestId);
                    List<TestRangeViewModel> testRanges = Ranges.Result;
                    var range = new TestRangeViewModel();
                    foreach (var item2 in testRanges)
                    {
                        if (Enumerable.Range(item2.FromAge, item2.ToAge).Contains(patientTests[i].Patient.Age) && patientTests[i].Patient.Gender.Name == item2.Gender.Name)
                        {
                            range = item2;
                        }
                    }
                    gfx.DrawString(patientTests[i].Test.Name, new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(100, currentYposition_valuese));
                    gfx.DrawString(patientTests[i].Test.Category.Name, new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(190, currentYposition_valuese));
                    gfx.DrawString($"{range.LowFrom} {range.HighFrom}", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(280, currentYposition_valuese));
                    gfx.DrawString("12", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(380, currentYposition_valuese));
                    gfx.DrawString("L", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(470, currentYposition_valuese));
                    currentYposition_valuese += 30;
                    currentYposition_CategroryRectangle = currentYposition_valuese - 20;
                    currentYposition_CategroryName = currentYposition_valuese - 5;
                    currentYposition_TableHeader = currentYposition_valuese + 20;
                }

            }
            document.Save("C:\\Users\\Hadi\\Downloads\\Documents\\test.pdf");
            viewer.Load("C:\\Users\\Hadi\\Downloads\\Documents\\test.pdf");
        }

        private void GenerateDocumentHeader()
        {
            var patient = PatientHelper.GetOnePatientAsync(_patientId).Result;
            var brushCategory = new XSolidBrush(XColor.FromArgb(165, 145, 237));
            gfx.DrawString("Hadi Laboratory", new XFont("Cooper Black", 20, XFontStyle.Bold), brushCategory, new XPoint(60, 50));
            gfx.DrawString("charlottalei 1, 2018, Antwerpen", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 65));
            gfx.DrawString("Belgium", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 80));
            gfx.DrawString("0032465798393", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 95));
            gfx.DrawString("abdul.hadi@labo.com", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 110));

            XImage image = XImage.FromFile("C:\\Users\\Hadi\\Downloads\\LaboLogo.png");
            gfx.DrawImage(image, 470, 20, 70, 78);
            var brush = new XSolidBrush(XColor.FromArgb(0, 4, 74));
            XRect snoColumnVal = new XRect(60, 115, 485, 3);
            gfx.DrawRectangle(XPens.Transparent, brush, snoColumnVal);

            gfx.DrawString("Name:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 130));
            gfx.DrawString($"{patient.Name} {patient.LastName}", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(95, 130));

            gfx.DrawString("Date:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 145));
            gfx.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(90, 145));

            gfx.DrawString("Dr Name:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 160));
            gfx.DrawString(patient.DoctorName, new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(110, 160));

            gfx.DrawString("Gender:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(420, 130));
            gfx.DrawString(patient.Gender.Name, new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(465, 130));

            gfx.DrawString("Age:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(420, 145));
            gfx.DrawString(patient.Age.ToString(), new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(445, 145));

            gfx.DrawString("Phone Nr:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(420, 160));
            gfx.DrawString(patient.PhoneNr, new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(475, 160));

            brush = new XSolidBrush(XColor.FromArgb(71, 74, 70));
            gfx.DrawString("Tests Report", new XFont("Britannic Bold", 17, XFontStyle.Regular), brush, new XPoint(250, 200));

            snoColumnVal = new XRect(60, 750, 485, 3);
            brush = new XSolidBrush(XColor.FromArgb(0, 4, 74));
            gfx.DrawRectangle(XPens.Transparent, brush, snoColumnVal);


        }


    }
}
