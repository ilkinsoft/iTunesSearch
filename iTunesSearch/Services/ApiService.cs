using iTunesSearch.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace iTunesSearch.Services
{
    public class ApiService
    {
        private static HttpClient client = null;
        private static string baseApiUrl = "https://itunes.apple.com/search?";

        public ApiService()
        {
            if (client == null)
            {
                HttpClientHandler handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };
                client = new HttpClient(handler);
            }
        }

        public string CallApi(string keyword)
        {
            client.BaseAddress = new Uri(baseApiUrl);
            HttpResponseMessage response = client.GetAsync("term=test").Result;
            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;
            return result;
        }
    }
}