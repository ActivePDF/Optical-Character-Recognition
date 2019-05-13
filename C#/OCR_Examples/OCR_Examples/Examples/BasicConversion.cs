
using System;

namespace OCR_Examples.Examples
{
    class BasicConversion
    {
        public static void Example()
        {
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // Instantiate Object
            APOCR.Net45.OCR ocr = new APOCR.Net45.OCR();

            // Enable extra logging (logging should only be used while
            // troubleshooting) C:\ProgramData\activePDF\Logs\
            ocr.Settings.Debug = true;

            // Convert the file to PDF
            OCRDK.Results.OCRResult result =
                ocr.Convert(
                    $"{strPath}..\\..\\..\\Input\\OCR.TIF.Input.tif",
                    $"{strPath}..\\..\\..\\Output\\OCR.BasicConversion.Output.pdf");
            WriteResult.Write(result);
        }
    }
}
