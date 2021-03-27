using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace bedste_boligoverblik.core.Helpers
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAsync(string url)
        {
            var httpClient = HttpClientFactory();

            var response = await httpClient.GetAsync(url);
            var result = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : string.Empty;

            return result;
        }

        public async Task<T> GetAsync<T>(string url) where T : new()
        {
            var httpClient = HttpClientFactory();

            var response = await httpClient.GetAsync(url);
            var result = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : string.Empty;

            var deserializeObject = new T();
            try
            {
                if (!string.IsNullOrEmpty(result)) deserializeObject = JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return deserializeObject;
        }

        public async Task<string> PostAsync<T>(string url, T body)
        {
            var httpClient = HttpClientFactory();

            var strPayload = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(strPayload, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);
            var result = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : string.Empty;

            return result;
        }

        public async Task<TOut> PostAsync<TIn, TOut>(string url, TIn body) where TOut : new()
        {
            var httpClient = HttpClientFactory();

            var strPayload = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(strPayload, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);
            var result = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : string.Empty;

            var deserializeObject = new TOut();

            if (!string.IsNullOrEmpty(result)) deserializeObject = JsonConvert.DeserializeObject<TOut>(result);

            return deserializeObject;
        }


        private HttpClient HttpClientFactory()
        {
            var httpClient = _httpClientFactory.CreateClient();
            return httpClient;
        }
    }
}