
using System;

namespace OCR_Examples.Examples
{
    class RecognizedInformation
    {
        public static void Example()
        {
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // Instantiate Object
            APOCR.Net45.OCR ocr = new APOCR.Net45.OCR();

            // Keep the recognized data after the conversion
            ocr.Settings.KeepRecognizedText = true;

            // Enable extra logging (logging should only be used while
            // troubleshooting) C:\ProgramData\activePDF\Logs\
            ocr.Settings.Debug = true;

            // Convert the file to PDF
            OCRDK.Results.OCRResult result =
                ocr.Convert(
                    inputFile: $"{strPath}..\\..\\..\\Input\\OCR.TIF.Input.tif",
                    outputFile: $"{strPath}..\\..\\..\\Output\\OCR.RecognizedInformation.Output.pdf");

            // Output recognized text
            Console.WriteLine(ocr.RecognizedInformation.DocumentText + System.Environment.NewLine);

            WriteResult.Write(result);
        }
    }
}
