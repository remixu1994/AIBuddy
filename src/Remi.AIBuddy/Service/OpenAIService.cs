using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Remi.AIBuddy.Service
{
    public class OpenAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenAIService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["Kimi:ApiKey"];
        }

        public async Task<string> GenerateResponseAsync(string prompt, string model = "moonshot-v1-8k", int maxTokens = 100)
        {
            var requestBody = new
            {
                model,
                messages = new[]
                {
                    new Message { Role = "system", content = "You are a helpful assistant." },
                    new Message { Role = "user", content = "Write a haiku about recursion in programming." }
                },
                temperature = 0.3
            };

            var requestContent = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsync("https://api.moonshot.cn/v1/chat/completions", requestContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"OpenAI API error: {response.StatusCode}, {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<JsonDocument>(responseContent);

            return responseContent;
        }
    }
}