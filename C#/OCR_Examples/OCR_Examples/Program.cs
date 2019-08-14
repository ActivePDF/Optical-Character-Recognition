// Copyright (c) 2019 ActivePDF, Inc.
// ActivePDF DocConverter

using System;

// Make sure to add the ActivePDF product .NET DLL(s) to your application.
// .NET DLL(s) are typically found in the products 'bin' folder.
namespace OCR_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Examples.BasicConversion.Example();
            Examples.CompressionOptions.Example();
            Examples.KeepRecognizedText.Example();
            Examples.LinearizeFile.Example();
            Examples.OCROptions.Example();
            Examples.OverwriteMethod.Example();
            Examples.RecognizedInformation.Example();
            Examples.RemoteConversion.Example();
            Examples.SetMetadata.Example();
            Examples.SetPDFSecurity.Example();
            Examples.SubmitViaRest.Example();
            Examples.Timeout.Example();
            Console.WriteLine("Press any key to exit."); 
            Console.ReadKey();
        }
    }
}
