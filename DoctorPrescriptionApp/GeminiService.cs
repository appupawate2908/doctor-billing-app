using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DoctorPrescriptionApp
{
    public class GeminiService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<string> AskGemini(string prompt, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey) || !apiKey.StartsWith("AIza"))
            {
                return "Error: Invalid API Key format.";
            }

            string apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}";

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

            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return $"API Error: {response.StatusCode}\n{responseBody}";
                }

                var jsonResponse = JObject.Parse(responseBody);
                string rawText = jsonResponse["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();
                
                return string.IsNullOrEmpty(rawText) ? "Error: No text in API response." : rawText;
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }
    }
}