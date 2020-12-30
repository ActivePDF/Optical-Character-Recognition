
namespace OCR_Examples.Examples
{
    class OCROptions
    {
        public static void Example()
        {
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // Instantiate Object
            APOCR.Net45.OCR ocr = new APOCR.Net45.OCR();

            // Enable extra logging (logging should only be used while
            // troubleshooting) C:\ProgramData\activePDF\Logs\
            ocr.Settings.Debug = true;

            // OCR Settings
            ocr.Settings.OCR.Deskew = OCRData.Enums.ImageProcessing.DeskewOptions.Auto2D;
            ocr.Settings.OCR.Despeckled = true;
            ocr.Settings.OCR.ExportBookmarks = false;
            ocr.Settings.OCRType = OCRData.Enums.OCR.OCRTypeOptions.SearchablePDF;
            ocr.Settings.OCR.PictureHandling = OCRData.Enums.OCR.PictureHandlingOptions.Default;
            ocr.Settings.OCR.RetainLineNumbering = false;
            ocr.Settings.OCR.Rotation = OCRData.Enums.ImageProcessing.RotationOptions.Auto;
            ocr.Settings.OCR.Languages.Add(OCRData.Enums.OCR.LanguageOptions.English);

            // Convert the file to PDF
            OCRDK.Results.OCRResult result =
                ocr.Convert(
                    inputFile: $"{strPath}..\\..\\..\\Input\\OCR.TIF.Input.tif",
                    outputFile: $"{strPath}..\\..\\..\\Output\\OCR.OCROptions.Output.pdf");
            WriteResult.Write(result);
        }
    }
}
