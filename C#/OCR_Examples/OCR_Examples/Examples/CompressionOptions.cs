using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR_Examples.Examples
{
    class CompressionOptions
    {
        public static void Example()
        {
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // Instantiate Object
            APOCR.Net45.OCR ocr = new APOCR.Net45.OCR();

            // Enable extra logging (logging should only be used while
            // troubleshooting) C:\ProgramData\activePDF\Logs\
            ocr.Settings.Debug = true;

            // PDF Compression
            ocr.Settings.PDF.Compression.TextAndLineArt = false;
            ocr.Settings.PDF.Compression.ContentStream =
                OCRData.Enums.ImageProcessing.ContentStreamOptions.Flate;
            ocr.Settings.PDF.Compression.EmbeddedFonts = false;
            ocr.Settings.PDF.Compression.BWImages = false;
            ocr.Settings.PDF.Compression.ColorAndGrayImages = false;
            ocr.Settings.PDF.Compression.MRC =
                OCRData.Enums.ImageProcessing.MRCOptions.Disabled;

            // Convert the file to PDF
            OCRDK.Results.OCRResult result =
                ocr.Convert(
                    $"{strPath}..\\..\\..\\Input\\OCR.TIF.Input.tif",
                    $"{strPath}..\\..\\..\\Output\\OCR.CompressionOptions.Output.pdf");
            WriteResult.Write(result);
        }
    }
}
