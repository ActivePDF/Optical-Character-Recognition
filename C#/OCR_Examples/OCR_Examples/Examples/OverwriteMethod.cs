
using System;

namespace OCR_Examples.Examples
{
    class OverwriteMethod
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
            OCRDK.Results.OCRConversionResult result =
                ocr.Convert(
                    inputFile: $"{strPath}..\\..\\..\\Input\\OCR.TIF.Input.tif",
                    outputFile: $"{strPath}..\\..\\..\\Output\\OCR.OverwriteMethod.Output.pdf");

            Console.WriteLine("First conversion complete - OverwriteMethod.Always");
            WriteResult.Write(result);

            // Set the OverwriteMethod value to generate a new file name if the
            // output file exists.
            ocr.Settings.PDF.OverwriteMethod = OCRData.Enums.PDF.OverwriteMethod.AlterFilename;

            // Convert the file to PDF, this will alter the output file name
            result = ocr.Convert(
                inputFile: $"{strPath}..\\..\\..\\Input\\OCR.TIF.Input.tif",
                outputFile: $"{strPath}..\\..\\..\\Output\\OCR.OverwriteMethod.Output.pdf");

            Console.WriteLine("Second conversion complete - OverwriteMethod.AlterFilename");
            WriteResult.Write(result);

            // Set the OverwriteMethod value to generate a new file name if the
            // output file exists.
            ocr.Settings.PDF.OverwriteMethod = OCRData.Enums.PDF.OverwriteMethod.Never;

            // Convert the file to PDF, this will alter the output file name
            result = ocr.Convert(
                inputFile: $"{strPath}..\\..\\..\\Input\\OCR.TIF.Input.tif",
                outputFile: $"{strPath}..\\..\\..\\Output\\OCR.OverwriteMethod.Output.pdf");

            Console.WriteLine("Third conversion complete - OverwriteMethod.Never");
            Console.WriteLine("This conversion should result in an error, the original file already exists.");
            WriteResult.Write(result);
        }
    }
}
