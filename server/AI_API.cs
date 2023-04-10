using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using DocumentFormat.OpenXml.Office.Word;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using server;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server
{
    public static class AI_API
    {
        //AI SETTINGS:
        //API KEY
        static string apiKey = "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"; // sets the key to be used for the api functions
        static int token = 1000; // max characters the ai can respond with
        static double creativity = 1; // the creativity of the ai's response
        static string engine = "text-davinci-003"; // the engine used in OpenAi api
        static int top_P = 1;
        static int frequency_penalty = 0;
        static int presence_penalty = 0;

        //IMAGE CREATE SETTINGS
        static int n = 1; // number of images to be made. Must be between 1 and 10
		static string size = "256x256"; // size of the image to be made. Must be one of 256x256, 512x512, or 1024x1024
		static string response_format = "b64_json"; //The format of the image. Must be one of url or b64_json


        public static string TextToText_openAI(string input)
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
        static readonly HttpClient client = new HttpClient();

        public static async Task<string> TextToImage_PythonUvicornServer(string input)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://127.0.0.1:28000/?Prompt=" + "\"" + input + "\"");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                string respond_url_image = responseBody.Substring(2,responseBody.Length - 4);
                return respond_url_image;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return "\nException Caught!";

            }
        }
        public static byte[] getImageFromUrl(string url)
        {
            //System.Net.HttpWebRequest request = null;
            //System.Net.HttpWebResponse response = null;
            byte[] imageBytes = null;
            Uri uri = new Uri(url);
            //request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            //request.UseDefaultCredentials = true;
            //response = (System.Net.HttpWebResponse)request.GetResponse();

            using (var webClient = new WebClient())
            {
                imageBytes = webClient.DownloadData(uri);
            }

            return imageBytes;
        }
        public static string TextToImage_openAI(string input, string username)
        {
            try
            {
                // Create an HttpClient
                using (var client = new HttpClient())
                {

                    // Add the API key to the request headers
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

                    // Create the JSON payload for the request
                    var json = JsonConvert.SerializeObject(new
                    {
                        model = "image-alpha-001",
                        prompt = input,
                        n = n,
                        size = size,
                        response_format = response_format,
                        user = username
                    });
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Make the request
                    var response = client.PostAsync("https://api.openai.com/v1/images/generations", content).Result;

                    //Console.WriteLine("Site Response Status: " + response.StatusCode);
                    string responseJson = response.Content.ReadAsStringAsync().Result;
                    // One error here to commit
                    //string responseObject = JsonConvert.DeserializeObject<dynamic>(responseJson);

					// Return base64 image string
					return responseJson;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        //not working yet
        public static string ImageToText_LAVIS(string base64Image)
        {
            try
            {
                string result;

                string pythonFileName = "C:\\Users\\user\\Source\\Repos\\Project_AI_API_Mobile_Networking_Group_10_COMP72070_Sec_1_23W\\Server_LAVIS_ImageToText\\Server_LAVIS_ImageToText.py";

                result = runPythonImageToText(pythonFileName, base64Image);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        private static string runPythonImageToText(string fileName, string base64Image)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:\\Users\\user\\anaconda3\\python.exe";
            start.Arguments = string.Format("{0} {1}", fileName, base64Image);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            Process process = Process.Start(start);

            process.WaitForExit();

            string result = System.IO.File.ReadAllText("C:\\Users\\user\\Source\\Repos\\Project_AI_API_Mobile_Networking_Group_10_COMP72070_Sec_1_23W\\ImageCaptionTemp.txt"); ;

            return result;
        }
    }
}