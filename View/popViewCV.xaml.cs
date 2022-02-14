using DevExpress.Xpf.PdfViewer;
using Services;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace View
{
    /// <summary>
    /// Interaction logic for popViewCV.xaml
    /// </summary>
    public partial class popViewCV : Window
    {
        public popViewCV()
        {
            InitializeComponent();
        }
        public popViewCV(byte[] cvFile)
        {
            string base64String = Convert.ToBase64String(cvFile);
            pdfLoadCV = new PdfViewerControl();
            //pdfLoadCV = new Syncfusion.Windows.PdfViewer.PdfViewerControl();
            PdfLoadedDocument pdf = new PdfLoadedDocument(cvFile);
            FileStream stream = new FileStream("/SSV - Calendar 2022.pdf", FileMode.Open);
            pdfLoadCV.DocumentSource = stream;
            //pdfLoadCV. = "data:application/pdf;base64," + base64String;
            InitializeComponent();
        }
    }
}
