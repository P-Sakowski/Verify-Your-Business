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

namespace Verify_Your_Business
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
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

            // Add an Accept header for JSON format.

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));



            // List data response.
            HttpResponseMessage response = client.GetAsync(search1 + "?date=2019-09-02").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                JObject jObject = JObject.Parse(responseString);

                string name = (string)jObject["result"]["subject"]["name"];
                string nip = (string)jObject["result"]["subject"]["nip"];
                string statusVat = (string)jObject["result"]["subject"]["statusVat"];
                string regon = (string)jObject["result"]["subject"]["regon"];
                string pesel = (string)jObject["result"]["subject"]["pesel"];
                string krs = (string)jObject["result"]["subject"]["krs"];
                string residenceAddress = (string)jObject["result"]["subject"]["residenceAddress"];
                string workingAddress = (string)jObject["result"]["subject"]["workingAddress"];
                string representatives = string.Join("", jObject["result"]["subject"]["representatives"]);
                string authorizedClerks = string.Join("", jObject["result"]["subject"]["authorizedClerks"]);
                string partners = string.Join("", jObject["result"]["subject"]["partners"]);
                string accountNumbers = string.Join("", jObject["result"]["subject"]["accountNumbers"]);
                string registrationLegalDate = (string)jObject["result"]["subject"]["registrationLegalDate"];
                string registrationDenialBasis = (string)jObject["result"]["subject"]["registrationDenialBasis"];
                string registrationDenialDate = (string)jObject["result"]["subject"]["registrationDenialDate"];
                string restorationBasis = (string)jObject["result"]["subject"]["restorationBasis"];
                string restorationDate = (string)jObject["result"]["subject"]["restorationDate"];
                string removalBasis = (string)jObject["result"]["subject"]["removalBasis"];
                string removalDate = (string)jObject["result"]["subject"]["removalDate"];
                
                name = "Firma (nazwa) lub imię i nazwisko: " + name;
                nip = "Numer, za pomocą którego podmiot został zidentyfikowany na potrzeby podatku, jeżeli taki numer został przyznany: " + nip;
                statusVat = "Status podatnika (wg stanu na dzień sprawdzenia): " + statusVat;
                regon = "Numer identyfikacyjny REGON, o ile został nadany: " + regon;
                pesel = "Numer PESEL, o ile podmiot posiada:" + pesel;
                krs = "Numer w Krajowym Rejestrze Sądowym, o ile został nadany: " + krs;
                residenceAddress = "Adres siedziby – w przypadku podmiotu niebędącego osobą fizyczną: " + residenceAddress;
                workingAddress = "Adres stałego miejsca prowadzenia działalności albo adres miejsca zamieszkania, w przypadku braku adresu stałego miejsca prowadzenia działalności - w odniesieniu do osoby fizycznej: " + workingAddress;
                representatives = "Imiona i nazwiska prokurentów oraz ich numery identyfikacji podatkowej lub numery PESEL: " + representatives;
                authorizedClerks = "Imiona i nazwiska osób wchodzących w skład organu uprawnionego do reprezentowania podmiotu oraz ich numery identyfikacji podatkowej lub numery PESEL: " + authorizedClerks;
                partners = "Imię i nazwisko lub firma (nazwa) wspólnika oraz jego numer identyfikacji podatkowej lub numer PESEL: " + partners;
                accountNumbers = "Numery rachunków rozliczeniowych lub imiennych rachunków w SKOK: " + accountNumbers;
                registrationLegalDate = "Data rejestracji jako podatnika VAT: " + registrationLegalDate;
                //  registrationDenialBasis = ": " + registrationDenialBasis;
                registrationDenialDate = "Data odmowy rejestracji jako podatnika VAT Podstawa prawna odmowy rejestracji: " + registrationDenialDate;
                // restorationBasis = ": " + restorationBasis;
                restorationDate = "Data przywrócenia rejestracji jako podatnika VAT Podstawa prawna przywrócenia " + restorationDate;
                removalBasis = "Data wykreślenia rejestracji jako podatnika VAT Podstawa prawna wykreślenia: " + removalBasis;
                // removalDate = ": " + removalDate;

                tbSettingText.Content = name + "\n" + nip + "\n" + statusVat + "\n" + regon + "\n" + pesel + "\n" + krs + "\n" + residenceAddress + "\n" 
                    + workingAddress + "\n" + representatives + "\n" + authorizedClerks + "\n" + partners + "\n" + accountNumbers + "\n" + registrationLegalDate + "\n"
                    + registrationDenialDate + "\n" + restorationDate + "\n" + removalBasis;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

           // tbSettingText.Content = "TODO";
        }
    }
}
