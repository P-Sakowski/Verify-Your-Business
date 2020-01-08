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
using Verify_Your_Business_Library;


namespace Verify_Your_Business
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        ApiClient apiClient;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string textSearch = text_search.Text;
            string search2 = date_search.Text;

            apiClient = new ApiClient(textSearch);
            tbSettingText.Content += apiClient.content;
            if (tbSettingText.Content.ToString() != "")
            {
                SaveXMLButton.Visibility = Visibility.Visible;
                SavePDFButton.Visibility = Visibility.Visible;
            }
        }

        private void SaveXMLButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveXml.SaveToXml(apiClient.FormFieldsList, "SearchedResult.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SavePDFButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SavePdf.SaveToPdf(apiClient.FormFieldsList, "SearchedResult.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
