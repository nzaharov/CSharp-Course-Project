using ProjectTemplate_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectTemplate_v2
{
    public static class HttpService
    {
        private static HttpClient _client;

        public static void InitializeClient()
        {

            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static async Task<double> GetProductValueAsync(string path)
        {
            SensorModel sensor = null;

            //await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            HttpResponseMessage responseMessage = await _client.GetAsync(path).ConfigureAwait(false);
        
            if (responseMessage.IsSuccessStatusCode)
            {
                sensor = await responseMessage.Content.ReadAsAsync<SensorModel>().ConfigureAwait(false);
            }
            else
            {
                throw new Exception(responseMessage.ReasonPhrase);
            }

            return sensor.Value;
        }

    }
}
