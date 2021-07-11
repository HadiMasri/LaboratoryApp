using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.Pdf.Grid;
using System.Data;

namespace Laboratory.UI.Views
{
    /// <summary>
    /// Interaction logic for PrintDialog.xaml
    /// </summary>
    public partial class PrintDialog : Window
    {
        public PrintDialog()
        {
            InitializeComponent();
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            using (PdfDocument document = new PdfDocument())
            {
                //Create a new PDF document.
                PdfDocument doc = new PdfDocument();
                //Add a page.
                PdfPage page = doc.Pages.Add();
                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();
                //Create a DataTable.
                DataTable dataTable = new DataTable();
                //Add columns to the DataTable
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("Name");
                //Add rows to the DataTable.
                dataTable.Rows.Add(new object[] { "E01", "Clay" });
                dataTable.Rows.Add(new object[] { "E02", "Thomas" });
                dataTable.Rows.Add(new object[] { "E03", "Andrew" });
                dataTable.Rows.Add(new object[] { "E04", "Paul" });
                dataTable.Rows.Add(new object[] { "E05", "Gary" });
                //Assign data source.
                pdfGrid.DataSource = dataTable;
                //Draw grid to the page of PDF document.
                pdfGrid.Draw(page, new PointF(10, 10));
                //Save the document.
                doc.Save("C:\\Users\\Hadi\\Downloads\\Documents\\Output.pdf");
                //close the document
                doc.Close(true);
            }
        }

    }
}
