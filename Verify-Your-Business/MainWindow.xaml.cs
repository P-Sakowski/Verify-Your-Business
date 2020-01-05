using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Reflection;


namespace Verify_Your_Business
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 

    public class TaxPayerFormFields
    {
        public string name { get; }
        public string nip { get; }
        public string statusVat { get; }
        public string regon { get; }
        public string pesel { get; }
        public string krs { get; }
        public string residenceAddress { get; }
        public string workingAddress { get; }
        public string representatives { get; }
        public string authorizedClerks { get; }
        public string partners { get; }
        public string accountNumbers { get; }
        public string registrationLegalDate { get; }
        // public string registrationDenialBasis { get; }
        public string registrationDenialDate { get; }
        // public string restorationBasis { get; }
        public string restorationDate { get; }
        public string removalBasis { get; }
        // public string removalDate { get; }

        public TaxPayerFormFields()
        {
            name = "Firma (nazwa) lub imię i nazwisko";
            nip = "Numer, za pomocą którego podmiot został zidentyfikowany na potrzeby podatku, jeżeli taki numer został przyznany";
            statusVat = "Status podatnika (wg stanu na dzień sprawdzenia)";
            regon = "Numer identyfikacyjny REGON, o ile został nadany";
            pesel = "Numer PESEL, o ile podmiot posiada:";
            krs = "Numer w Krajowym Rejestrze Sądowym, o ile został nadany:";
            residenceAddress = "Adres siedziby – w przypadku podmiotu niebędącego osobą fizyczną:";
            workingAddress = "Adres stałego miejsca prowadzenia działalności albo adres miejsca zamieszkania, w przypadku braku adresu stałego miejsca prowadzenia działalności - w odniesieniu do osoby fizycznej:";
            representatives = "Imiona i nazwiska prokurentów oraz ich numery identyfikacji podatkowej lub numery PESEL:";
            authorizedClerks = "Imiona i nazwiska osób wchodzących w skład organu uprawnionego do reprezentowania podmiotu oraz ich numery identyfikacji podatkowej lub numery PESEL:";
            partners = "Imię i nazwisko lub firma (nazwa) wspólnika oraz jego numer identyfikacji podatkowej lub numer PESEL:";
            accountNumbers = "Numery rachunków rozliczeniowych lub imiennych rachunków w SKOK:";
            registrationLegalDate = "Data rejestracji jako podatnika VAT:";
            // registrationDenialBasis = ": " + registrationDenialBasis;
            registrationDenialDate = "Data odmowy rejestracji jako podatnika VAT Podstawa prawna odmowy rejestracji:";
            // restorationBasis = ": " + restorationBasis;
            restorationDate = "Data przywrócenia rejestracji jako podatnika VAT Podstawa prawna przywrócenia:";
            removalBasis = "Data wykreślenia rejestracji jako podatnika VAT Podstawa prawna wykreślenia:";
            // removalDate = ": " + removalDate;
        }
    }

    public class Helper
    {
        public List<KeyValuePair<string, string>> FormFieldsList = new List<KeyValuePair<string, string>>();

        public Helper(JObject apiResponse)
        {
            TaxPayerFormFields taxPayerFormFields = new TaxPayerFormFields();
            PropertyInfo[] properties = taxPayerFormFields.GetType().GetProperties();

            foreach (JProperty element in (JToken)apiResponse["result"]["subject"])
            {
                var matches = from val in properties where val.Name == element.Name select val;

                foreach (var match in matches)
                {
                    Type elementType = element.Value.GetType();
                    string label = (string)match.GetValue(taxPayerFormFields, null);

                    if (elementType.Name == "JArray")
                    {
                        string el = string.Join(",", element.Value);
                        FormFieldsList.Add(new KeyValuePair<string, string>(label, el));
                    } else {
                        FormFieldsList.Add(new KeyValuePair<string, string>(label, (string)element.Value));
                    }
                }
            }
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const string URL = "https://wl-api.mf.gov.pl/api/search/nip/";
        // private string urlParameters = "7382154319?date=2019-09-02";

        private void Search(object sender, RoutedEventArgs e)
        {
            // todo
            string search1 = text_search.Text;
            string search2 = date_search.Text;
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(search1 + "?date=2019-09-02").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(responseString);
                Helper helper = new Helper(jObject);

                foreach (KeyValuePair<string, string> field in helper.FormFieldsList)
                {
                     tbSettingText.Content += field.Key + ": " + field.Value + "\n";
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
