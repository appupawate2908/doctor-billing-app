using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class TestGemini
{
    private static readonly HttpClient httpClient = new HttpClient();

    public static async Task Main(string[] args)
    {
        string apiKey = "AIzaSyDwAYJPodhHmI5qgKojq-2mmO8EcfEbxoU"; // Your API Key
        string symptoms = "sore throat and fever";

        try
        {
            string apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}";

            string prompt = $"You are an ENT specialist. Based on these symptoms: '{symptoms}'
Please suggest 3-4 appropriate medicines and return ONLY a markdown table with this EXACT format:
| MedicineName | TimesPerDay | NumberOfDays |
|--------------|-------------|--------------|
| Medicine1    | 2           | 7            |";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            string jsonRequest = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            Console.WriteLine("--- Sending Request ---");
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"--- API Response ---");
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Body: {responseBody}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = JObject.Parse(responseBody);
                string rawText = jsonResponse["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();
                Console.WriteLine("\n--- Extracted Text ---");
                Console.WriteLine(rawText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n--- Exception ---");
            Console.WriteLine(ex.ToString());
        }
    }
}
