using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR_Examples.Examples
{
    class SetPDFSecurity
    {
        public static void Example()
        {
            string strPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // Instantiate Object
            APOCR.Net45.OCR ocr = new APOCR.Net45.OCR();

            // Enable extra logging (logging should only be used while
            // troubleshooting) C:\ProgramData\activePDF\Logs\
            ocr.Settings.Debug = true;

            // PDF Security
            ocr.Settings.PDF.Security.UseSecurity = false;
            ocr.Settings.PDF.Security.Encryption = OCRData.Enums.PDF.EncryptionType.AES_256;
            ocr.Settings.PDF.Security.OwnerPassword = "ownerPassword";
            ocr.Settings.PDF.Security.UserPassword = "userPassword";
            ocr.Settings.PDF.Security.CanAnnotate = false;
            ocr.Settings.PDF.Security.CanAssemble = false;
            ocr.Settings.PDF.Security.CanCopy = false;
            ocr.Settings.PDF.Security.CanEdit = false;
            ocr.Settings.PDF.Security.CanFillInFormFields = false;
            ocr.Settings.PDF.Security.CanMakeAccessible = false;
            ocr.Settings.PDF.Security.CanPrint = false;
            ocr.Settings.PDF.Security.CanPrintHiResolution = false;

            // Convert the file to PDF
            OCRDK.Results.OCRResult result =
                ocr.Convert(
                    inputFile: $"{strPath}..\\..\\..\\Input\\OCR.TIF.Input.tif",
                    outputFile: $"{strPath}..\\..\\..\\Output\\OCR.SetPDFSecurity.Output.pdf");
            WriteResult.Write(result);
        }
    }
}
