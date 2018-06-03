using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AXIS.Weather
{
    class ApiClient
    {
        HttpClient _client;

        //create and configure HTTP client
        public ApiClient()
        {
            _client = new HttpClient();

            _client.BaseAddress = new Uri("https://opendata-download-metobs.smhi.se/");

            _client.DefaultRequestHeaders.Accept.Clear();

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Get data from the server
        public async Task<JObject> GetDataAsync(string path)
        {
            string contentString = "";

            HttpResponseMessage response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                contentString = await response.Content.ReadAsStringAsync();
            }

            //return a JSON object
            return JObject.Parse(contentString);
        }
    }
}
