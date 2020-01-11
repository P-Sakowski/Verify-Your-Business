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
        private const string URL = "https://wl-api.mf.gov.pl/api/search/";
        private const string NIP = "nip/";
        private const string REGON = "regon/";

        public string content;
        public List<FormBuilder.KeyValuePair<string, string>> FormFieldsList = new List<FormBuilder.KeyValuePair<string, string>>();
        // private string urlParameters = "7382154319?date=2019-09-02";
        public ApiClient(string textSearch, string type)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string typ = NIP;

            if (type == "1")
            {
                typ = REGON;
            }

            Console.WriteLine(typ);

            HttpResponseMessage response = client.GetAsync(typ + textSearch + "?date=2019-09-02").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(responseString);
                FormBuilder helper = new FormBuilder(jObject);

                foreach (FormBuilder.KeyValuePair<string, string> field in helper.FormFieldsList)
                {
                    content += field.Key + ": " + field.Value + "\n";
                }
                this.FormFieldsList = helper.FormFieldsList;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            client.Dispose();
        }
    }
}
