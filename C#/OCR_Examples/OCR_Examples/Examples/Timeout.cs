using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR_Examples.Examples
{
    class Timeout
    {
        public static void Example()
        {
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // Instantiate Object
            APOCR.Net45.OCR ocr = new APOCR.Net45.OCR();

            // Enable extra logging (logging should only be used while
            // troubleshooting) C:\ProgramData\activePDF\Logs\
            ocr.Settings.Debug = true;

            // Time to wait for conversion to complete (in seconds)
            ocr.Settings.Timeout = 20;

            // Convert the file to PDF
            OCRDK.Results.OCRResult result =
                ocr.Convert(
                    $"{strPath}..\\..\\..\\Input\\OCR.TIF.Input.tif",
                    $"{strPath}..\\..\\..\\Output\\OCR.Timeout.Output.pdf");
            WriteResult.Write(result);
        }
    }
}
