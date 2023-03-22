using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using DocumentFormat.OpenXml.Office.Word;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using server;

namespace server
{
    public static class AI_API
    {
        //AI SETTINGS:
        //API KEY
        public static string apiKey = "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"; // sets the key to be used for the api functions
        public static int token = 1000; // max characters the ai can respond with
        public static double creativity = 1; // the creativity of the ai's response
        public static string engine = "text-davinci-003"; // the engine used in OpenAi api
        public static int top_P = 1;
        public static int frequency_penalty = 0;
        public static int presence_penalty = 0;
        //IMAGE CREATE SETTINGS
        public static int n = 1; // number of images to be made
        public static string size = "256x256"; // size of the image to be made


        public static string callOpenAIText( string input)
        {
            var openAiKey = apiKey;
            var apiCall = "https://api.openai.com/v1/engines/" + engine + "/completions";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), apiCall))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + openAiKey);
                        request.Content = new StringContent("{\n  \"prompt\": \"" + input + "\",\n  \"temperature\": " +
                                                            creativity.ToString(CultureInfo.InvariantCulture) + ",\n  \"max_tokens\": " + token + ",\n  \"top_p\": " + top_P +
                                                            ",\n  \"frequency_penalty\": " + frequency_penalty + ",\n  \"presence_penalty\": " + presence_penalty + "\n}");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var response = httpClient.SendAsync(request).Result;
                        var json = response.Content.ReadAsStringAsync().Result;
                        dynamic dynObj = JsonConvert.DeserializeObject(json);
                        if (dynObj != null)
                        {
                            return dynObj.choices[0].text.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        public static string callOpenAIImage(string input, int number, string imagesize, string apikey)
        {
            var openAiKey = apikey;
            try
            {
                // Create an HttpClient
                using (var client = new HttpClient())
                {

                    // Add the API key to the request headers
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + openAiKey);

                    // Create the JSON payload for the request
                    var json = JsonConvert.SerializeObject(new
                    {
                        model = "image-alpha-001",
                        prompt = input,
                        n = number,
                        size = imagesize
                    });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Make the request
                    var response = client.PostAsync("https://api.openai.com/v1/images/generations", content).Result;
                    //Console.WriteLine("Site Response Status: " + response.StatusCode);
                    var responseJson = response.Content.ReadAsStringAsync().Result;
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseJson);

                    // Get the image data from the response
                    return responseObject.data[0].url;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        //not working yet
        public static string[] callOpenAIImageToText()
        {
            try
            {
                string[] result;

                //string imagePath = GetImagePath();
                string imagePath = @"C:\Users\user\Downloads\movie.jpg";
                string pythonFileName = "C:\\Users\\user\\Source\\Repos\\Project_AI_API_Mobile_Networking_Group_10_COMP72070_Sec_1_23W\\Server_LAVIS_ImageToText\\Server_LAVIS_ImageToText.py";

                result = runPythonImageToText(pythonFileName, imagePath);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        private static string[] runPythonImageToText(string fileName, string imagePath)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:\\Users\\user\\anaconda3\\python.exe";
            start.Arguments = string.Format("{0} {1}", fileName, imagePath);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            Process process = Process.Start(start);

            process.WaitForExit();

            string[] result = System.IO.File.ReadAllLines("C:\\Users\\user\\Source\\Repos\\Project_AI_API_Mobile_Networking_Group_10_COMP72070_Sec_1_23W\\ImageCaptionTemp.txt"); ;

            return result;
        }

        public static string GetImagePath()
        {
            
            return null;
        }
    }
}