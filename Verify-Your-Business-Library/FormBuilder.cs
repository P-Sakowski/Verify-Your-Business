using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Linq;
using System.Xml.Serialization;

namespace Verify_Your_Business_Library
{
    public class FormBuilder
    {
        [Serializable]
        [XmlType(TypeName = "SearchedEntityAttribute")]
        public struct KeyValuePair<K, V>
        {
            public K Key
            { get; set; }
            public V Value
            { get; set; }
            public KeyValuePair(K k, V v) : this() { Key = k; Value = v; }
            public override string ToString()
            {
                return this.Key + ": " + this.Value;
            }
        }

        public List<KeyValuePair<string, string>> FormFieldsList = new List<KeyValuePair<string, string>>();
        public FormBuilder(JObject apiResponse)
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
                    }
                    else
                    {
                        FormFieldsList.Add(new KeyValuePair<string, string>(label, (string)element.Value));
                    }
                }
            }
        }
    }
}
