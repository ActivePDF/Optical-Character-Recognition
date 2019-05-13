using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR_Examples.Examples
{
    class KeepRecognizedText
    {
        public static void Example()
        {
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // Instantiate Object
            APOCR.Net45.OCR ocr = new APOCR.Net45.OCR();

            // Enable extra logging (logging should only be used while
            // troubleshooting) C:\ProgramData\activePDF\Logs\
            ocr.Settings.Debug = true;

            // Keep the recognized data after the conversion
            ocr.Settings.KeepRecognizedText = true;

            // Convert the file to PDF
            OCRDK.Results.OCRResult result =
                ocr.Convert(
                    $"{strPath}..\\..\\..\\Input\\OCR.TIF.Input.tif",
                    $"{strPath}..\\..\\..\\Output\\OCR.KeepRecText.Output.pdf");

            if (result.OCRStatus == OCRDK.Results.OCRStatus.Success)
            {
                System.IO.File.WriteAllText(
                    $"{strPath}RecognizedText.txt",
                    ocr.RecognizedInformation.DocumentText);
            }

            WriteResult.Write(result);
        }
    }
}
