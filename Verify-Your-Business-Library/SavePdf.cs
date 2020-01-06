using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing.Layout;
using MigraDoc.DocumentObjectModel;

namespace Verify_Your_Business_Library
{
    public class SavePdf
    {
        public static void SaveToPdf(List<FormBuilder.KeyValuePair<string, string>> obj, string filename)
        {
            int x = 30;
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Searched Result";
            PdfPage page = document.AddPage();
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 10);
            XTextFormatter tf = new XTextFormatter(gfx);
            tf.DrawString("Wykaz podmiotów zarejestrowanych jako podatnicy VAT, niezarejestrowanych oraz wykreślonych i przywróconych do rejestru VAT.", 
                new XFont("Verdana", 11, XFontStyle.Bold), XBrushes.Black, new XRect(15, 10, page.Width, 15));
            foreach (FormBuilder.KeyValuePair<string, string> field in obj)
            {
                XRect rect = new XRect(30, x, page.Width-30, page.Height-30);
                tf.DrawString(field.ToString(), font, XBrushes.Black, rect, XStringFormats.TopLeft);
                x += 30;
            }
            string fullFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), filename);
            document.Save(fullFilename);
            Process.Start(fullFilename);
            document.Close();
        }
    }
}
