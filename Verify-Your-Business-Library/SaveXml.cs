using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Verify_Your_Business_Library
{
    public class SaveXml
    {
        public static void SaveToXml(List<FormBuilder.KeyValuePair<string, string>> obj, string filename)
        {
            string fullFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), filename);
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(fullFilename);
            serializer.Serialize(writer, obj);
            writer.Close();
        }
    }
}