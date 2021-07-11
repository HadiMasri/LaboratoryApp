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
        private int currentYposition_valuese = 330;
        private int currentYposition_CategroryRectangle = 240;
        private int currentYposition_CategroryName = 255;
        private int currentYposition_TableHeader = 260;

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
            List<Patient_TestViewModel> patientTests = patientTestsTask.Result.OrderBy( c => c.Test.Category.Name).ToList();


            PdfDocument document = new PdfDocument();
            document.Info.Title = "PDF Example";
            PdfPage page = document.AddPage();
            gfx = XGraphics.FromPdfPage(page);

            gfx.DrawString("Hadi Laboratory", new XFont("Arial", 20, XFontStyle.Bold), XBrushes.Blue, new XPoint(60, 50));
            gfx.DrawString("charlottalei 1, 2018, Antwerpen", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 65));
            gfx.DrawString("Belgium", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 80));
            gfx.DrawString("0032465798393", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 95));
            gfx.DrawString("abdul.hadi@labo.com", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 110));

            XImage image =  XImage.FromFile("C:\\Users\\Hadi\\Downloads\\LaboLogo.png");
            gfx.DrawImage(image, 470, 20, 70, 78);
            var brush = new XSolidBrush(XColor.FromArgb(202, 194, 209));
            XRect snoColumnVal = new XRect(60, 115, 485, 3);
            gfx.DrawRectangle(XPens.Transparent, brush, snoColumnVal);

            gfx.DrawString("Name:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 130));
            gfx.DrawString("John", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(95, 130));

            gfx.DrawString("Date:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 145));
            gfx.DrawString("2021/07/01", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(95, 145));

            gfx.DrawString("Doctor Name:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(60, 160));
            gfx.DrawString("Thomas", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(130, 160));

            gfx.DrawString("Gender:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(420, 130));
            gfx.DrawString("Male", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(465, 130));

            gfx.DrawString("Age:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(420, 145));
            gfx.DrawString("25", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(445, 145));

            gfx.DrawString("Phone Nr:", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(420, 160));
            gfx.DrawString("0032465798393", new XFont("Arial", 11, XFontStyle.Regular), XBrushes.Black, new XPoint(475, 160));



            //gfx.DrawString("Name", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(100, 260));
            //gfx.DrawString("Category", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(190, 260));
            //gfx.DrawString("Range", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(280, 260));
            //gfx.DrawString("Result", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(370, 260));
            //gfx.DrawString("Unit", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(460, 260));

            for (int i = 0; i < patientTests.Count; i++)
            {
                if (patientTests[i].Test.Category.Name != category)
                {
                    category = patientTests[i].Test.Category.Name;
                    var brushCategory = new XSolidBrush(XColor.FromArgb(202, 194, 209));
                    XRect snoColumnValCategory = new XRect(60, currentYposition_CategroryRectangle , 485, 20);
                    gfx.DrawRectangle(XPens.Transparent, brushCategory, snoColumnValCategory);
                    gfx.DrawString(patientTests[i].Test.Category.Name, new XFont("Arial", 15, XFontStyle.Regular), XBrushes.White, new XPoint(250, currentYposition_CategroryName));

                    gfx.DrawString("Name", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(100, currentYposition_CategroryName + 20));
                    gfx.DrawString("Category", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(190, currentYposition_CategroryName + 20));
                    gfx.DrawString("Range", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(280, currentYposition_CategroryName + 20));
                    gfx.DrawString("Result", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(370, currentYposition_CategroryName + 20));
                    gfx.DrawString("Unit", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(460, currentYposition_CategroryName + 20));

                    currentYposition_valuese = currentYposition_CategroryName + 50;

                }
                numberOfItemsPerPage += 1;
                if (numberOfItemsPerPage <= 10)
                {
                    if (numberOfItemsPerPage == 10)
                    {
                        numberOfItemsPerPage = 0;
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        gfx.DrawString("Tests", new XFont("Arial", 40, XFontStyle.Bold), XBrushes.Red, new XPoint(200, 70));
                        gfx.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(100, 100), new XPoint(500, 100));
                        gfx.DrawString("Name", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(90, 280));
                        gfx.DrawString("Category", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(240, 280));
                        gfx.DrawString("Range", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(390, 280));
                        gfx.DrawString("Result", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(540, 280));
                        gfx.DrawString("Unit", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(690, 280));
                        currentYposition_valuese = 303;
                        currentYposition_CategroryRectangle = 240;
                        currentYposition_CategroryName = 255;
                    }
                    gfx.DrawString(patientTests[i].Test.Name, new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(90, currentYposition_valuese));
                    gfx.DrawString(patientTests[i].Test.Category.Name, new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(240, currentYposition_valuese));
                    gfx.DrawString("1.2", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(400, currentYposition_valuese));
                    gfx.DrawString("12", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(550, currentYposition_valuese));
                    gfx.DrawString("L", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(700, currentYposition_valuese));
                    currentYposition_valuese += 30;
                    currentYposition_CategroryRectangle += 40;
                    currentYposition_CategroryName += 40;
                }

            }
            document.Save("C:\\Users\\Hadi\\Downloads\\Documents\\test.pdf");
            viewer.Load("C:\\Users\\Hadi\\Downloads\\Documents\\test.pdf");
        }

        private void SetHematologyCategory()
        {
            var brushCategory = new XSolidBrush(XColor.FromArgb(202, 194, 209));
            XRect snoColumnValCategory = new XRect(60, 210, 485, 20);
            gfx.DrawRectangle(XPens.Transparent, brushCategory, snoColumnValCategory);
            gfx.DrawString("Hematology", new XFont("Arial", 15, XFontStyle.Regular), XBrushes.White, new XPoint(250, 225));

            gfx.DrawString("Name", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(100, 260));
            gfx.DrawString("Category", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(190, 260));
            gfx.DrawString("Range", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(280, 260));
            gfx.DrawString("Result", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(370, 260));
            gfx.DrawString("Unit", new XFont("Arial", 13, XFontStyle.Regular), XBrushes.Black, new XPoint(460, 260));
        }
    }
}
