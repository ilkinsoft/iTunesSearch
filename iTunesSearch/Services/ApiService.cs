using System;
using System.Net;
using System.Net.Http;

namespace iTunesSearch.Services
{
    public class ApiService
    {
        private static HttpClient client = null;
        private static readonly string baseApiUrl = "https://itunes.apple.com/";

        public ApiService()
        {
            if (client == null)
            {
                HttpClientHandler handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };
                client = new HttpClient(handler);
                client.BaseAddress = new Uri(baseApiUrl);
            }
        }

        public string CallApi(string keyword)
        {
            HttpResponseMessage response = client.GetAsync($"search?entity=movie&term={keyword}").Result;
            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}