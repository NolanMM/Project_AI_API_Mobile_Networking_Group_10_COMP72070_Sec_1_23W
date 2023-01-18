using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
class Program
{
    static void Main(string[] args)
    {
        //AI SETTINGS:
        //API KEY
        string apiKey = "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"; // sets the key to be used for the api functions
        //TEXT CHAT SETTINGS
        int token = 1000; // max characters the ai can respond with
        double creativity = 1; // the creativity of the ai's response
        var engine = "text-davinci-003"; // the engine used in OpenAi api
        int top_P = 1;
        int frequency_penalty = 0;
        int presence_penalty = 0;
        //IMAGE CREATE SETTINGS
        int n = 1; // number of images to be made
        var size = "256x256"; // size of the image to be made

        bool run = true;
        while (run == true)
        {

            //UI
            Console.WriteLine("\nUI choices:\n1. Text\n2. Images\n3. Image To Text\n4. Exit");
            var UIChoice = Console.ReadLine();

            if (UIChoice == "1") // text ai
            {
                //to ask the user to enter their prompt
                Console.WriteLine("\nEnter your prompt:");
                var prompt = Console.ReadLine();

                //call the open ai
                var response = callOpenAIText(token, prompt, engine, creativity, top_P, frequency_penalty, presence_penalty, apiKey);
                Console.WriteLine(response);
            }
            if (UIChoice == "2") // image ai
            {
                //to ask the user to enter their prompt
                Console.WriteLine("\nEnter your prompt:");
                var prompt = Console.ReadLine();

                var response = callOpenAIImage(prompt, n, size, apiKey);
                Console.WriteLine(response);
            }
            if (UIChoice == "3") // image to text
            {
                //to ask the user to enter their prompt
                Console.WriteLine("\nEnter your prompt:");
                var prompt = Console.ReadLine();

                var response = callOpenAIImageToText(prompt, apiKey);
                Console.WriteLine(response);
            }
            if (UIChoice == "4") // exit
            {
                run = false;
            }
        }

    }

    private static string callOpenAIText(int tokens, string input, string engine,
         double temperature, int topP, int frequencyPenalty, int presencePenalty, string apikey)
    {
        var openAiKey = apikey;
        var apiCall = "https://api.openai.com/v1/engines/" + engine + "/completions";
        try
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), apiCall))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + openAiKey);
                    request.Content = new StringContent("{\n  \"prompt\": \"" + input + "\",\n  \"temperature\": " +
                                                        temperature.ToString(CultureInfo.InvariantCulture) + ",\n  \"max_tokens\": " + tokens + ",\n  \"top_p\": " + topP +
                                                        ",\n  \"frequency_penalty\": " + frequencyPenalty + ",\n  \"presence_penalty\": " + presencePenalty + "\n}");
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


    private static string callOpenAIImage(string input, int number, string imagesize, string apikey)
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
    private static string callOpenAIImageToText(string input, string apikey)
    {
        var OpenAiKey = apikey;
        var imageUrl = input;
        var url = "https://images.pexels.com/photos/414612/pexels-photo-414612.jpeg";
        var apiUrl = "https://api.openai.com/v1/images/generations";
        try
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + OpenAiKey);
                var data = new
                {
                    model = "image-alpha-001",
                    prompt = $"Describe this image: {url}",
                };

                var jsonData = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = client.PostAsync(apiUrl, content).Result;
                var result = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine(result.data.text);

                return result;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }
}