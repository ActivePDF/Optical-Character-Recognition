
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OCR_Examples.Examples
{
    class SubmitViaRest
    {
        public static void Example()
        {
            Task.Run(async () =>
            {
                string inputFile = $"{AppDomain.CurrentDomain.BaseDirectory}..\\..\\..\\Input\\OCR.TIF.Input.tif";
                string outputFile = $"{AppDomain.CurrentDomain.BaseDirectory}..\\..\\..\\Output\\OCR.SubmitViaRest.Output.pdf";

                using (HttpClient client = new HttpClient())
                {
                    // Set the Access Token for authorization. The access token
                    // can be found in the ActivePDF P3Rest Administration tool
                    string accessToken = string.Empty; //<<INSERT TOKEN HERE>>

                    // Check that the access token has been added by the user
                    Trace.Assert(
                        !String.IsNullOrEmpty(accessToken),
                        "You must set the access token for REST submissions");

                    AuthenticationHeaderValue ahv =
                        new AuthenticationHeaderValue("Bearer", accessToken);
                    client.DefaultRequestHeaders.Authorization = ahv;

                    // Multipart form post
                    MultipartFormDataContent content =
                        new MultipartFormDataContent();

                    // Input file as a file stream
                    FileStream fs = File.OpenRead(inputFile);
                    StreamContent streamContent = new StreamContent(fs);
                    streamContent.Headers.Add(
                        "Content-Type",
                        "application/octet-stream");
                    streamContent.Headers.Add(
                        "Content-Disposition",
                        $"form-data; name=\"InputFile\"; filename=\"{Path.GetFileName(inputFile)}\"");
                    content.Add(
                        streamContent,
                        inputFile,
                        Path.GetFileName(inputFile));

                    // Each setting can be passed in here as a new
                    // StringContent
                    content.Add(new StringContent("0"), "OCRType");
                    content.Add(new StringContent("1"), "PictureHandling");
                    content.Add(new StringContent("4"), "PDFVersion");
                    content.Add(new StringContent("1"), "Linearize");

                    // Post the content to the endpoint (uri)
                    Uri uri =
                        new Uri("http://localhost:62625/api/OCR/Conversion");
                    HttpResponseMessage hrm =
                        await client.PostAsync(uri, content);
                    if (hrm.StatusCode == HttpStatusCode.OK)
                    {
                        // Get the resulting output of the post
                        byte[] bytes =
                            await hrm.Content.ReadAsByteArrayAsync();

                        // Specify where you want the PDF to save
                        File.WriteAllBytes(outputFile, bytes);
                        Console.WriteLine("REST submission successful.");
                    }
                    else
                    {
                        // Get the error message if something went wrong
                        string error = await hrm.Content.ReadAsStringAsync();
                        Console.WriteLine(error);
                    }
                }
            }).Wait();
        }
    }
}
