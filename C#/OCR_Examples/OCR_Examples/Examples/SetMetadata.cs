using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR_Examples.Examples
{
    class SetMetadata
    {
        public static void Example()
        {
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // Instantiate Object
            APOCR.Net45.OCR ocr = new APOCR.Net45.OCR();

            // Enable extra logging (logging should only be used while
            // troubleshooting) C:\ProgramData\activePDF\Logs\
            ocr.Settings.Debug = true;

            // PDF Metadata
            ocr.Settings.PDF.Metadata.Author = "John Doe";
            ocr.Settings.PDF.Metadata.Title = "OCR Example";
            ocr.Settings.PDF.Metadata.Subject = "Example";
            ocr.Settings.PDF.Metadata.Keywords = "OCR, example, metadata";

            // Convert the file to PDF
            OCRDK.Results.OCRResult result =
                ocr.Convert(
                    $"{strPath}..\\..\\..\\Input\\OCR.TIF.Input.tif",
                    $"{strPath}..\\..\\..\\Output\\OCR.SetMetadata.Output.pdf");
            WriteResult.Write(result);
        }
    }
}
