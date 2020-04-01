using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CitationPlease.Services
{
    public static class BillParsingService
    {
        public static string GetTextFromXML(string xmlContents)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlContents));
            var reader = XmlReader.Create(stream, new XmlReaderSettings()
            {
                DtdProcessing = DtdProcessing.Parse
            });
            var output = "";
            while(reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Text)
                {
                    output += reader.Value + Environment.NewLine;
                }
            }
            return output;
        }
    }
}
