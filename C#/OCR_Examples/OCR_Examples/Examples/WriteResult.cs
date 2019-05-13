
using System;

namespace OCR_Examples.Examples
{
    class WriteResult
    {   
        public static void Write(OCRDK.Results.OCRResult Result)
        {
            Console.WriteLine($"Result Origin: {Result.Origin.Class}.{Result.Origin.Function}");
            Console.WriteLine($"Result Status: {Result.OCRStatus}");
            if (!string.IsNullOrEmpty(Result.Details))
            {
                Console.WriteLine($"Result Details: {Result.Details}");
            }
            if (Result.ResultException != null)
            {
                Console.WriteLine("Exception caught during conversion.");
                Console.WriteLine($"Excpetion Details: {Result.ResultException.Message}");
                Console.WriteLine($"Exception Stack Trace: {Result.ResultException.StackTrace}");
            }
        }
    }
}
