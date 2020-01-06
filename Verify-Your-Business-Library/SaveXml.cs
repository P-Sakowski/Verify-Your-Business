using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Verify_Your_Business_Library
{
    public class SaveXml
    {
        public static void saveToXml(SearchedResult obj, string filename)
        {
            string fullFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), filename);
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(fullFilename);
            serializer.Serialize(writer, obj);
            writer.Close();
        }
    }
    public class SearchedResult
    {
        public string Content { get; set; }
        public SearchedResult(string content)
        {
            this.Content = content;
        }
        public SearchedResult()
        {
            this.Content = "";
        }
    }
}

