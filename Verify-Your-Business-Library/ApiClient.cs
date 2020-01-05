using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Verify_Your_Business_Library
{
    public class ApiClient
    {
        private const string URL = "https://wl-api.mf.gov.pl/api/search/nip/";
        public string content;
        // private string urlParameters = "7382154319?date=2019-09-02";
        public ApiClient(string textSearch)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(textSearch + "?date=2019-09-02").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(responseString);
                FormBuilder helper = new FormBuilder(jObject);

                foreach (KeyValuePair<string, string> field in helper.FormFieldsList)
                {
                    content += field.Key + ": " + field.Value + "\n";
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            client.Dispose();
        }
    }
}
