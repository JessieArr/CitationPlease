using CitationPlease.Models.GovInfo.Judicial;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CitationPlease.Services
{
    public static class CourtOpinionParsingService
    {
        public static CourtOpinionDetails GetDetailsFromXML(string xmlContents)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlContents));
            var reader = XmlReader.Create(stream, new XmlReaderSettings()
            {
            });
            var output = new CourtOpinionDetails();
            var level1ElementName = "";
            var level2ElementName = "";
            var level3ElementName = "";
            CourtOpinionRelatedItem currentRelatedItem = null;
            while (reader.MoveToNextAttribute() || reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    if (reader.Depth == 3 && level1ElementName == "titleInfo" && level2ElementName == "title")
                    {
                        output.Title = reader.Value;
                    }
                    if (reader.Depth == 3 && level1ElementName == "extension" && level2ElementName == "cause")
                    {
                        output.Cause = reader.Value;
                    }
                    if (reader.Depth == 3 && level1ElementName == "extension" && level2ElementName == "caseNumber")
                    {
                        output.CaseNumber = reader.Value;
                    }
                    if (reader.Depth == 4 && level1ElementName == "relatedItem" && level2ElementName == "titleInfo"
                        && level3ElementName == "title")
                    {
                        currentRelatedItem.Title = reader.Value;
                    }
                    if (reader.Depth == 4 && level1ElementName == "relatedItem" && level2ElementName == "titleInfo"
                        && level3ElementName == "subTitle")
                    {
                        currentRelatedItem.SubTitle = reader.Value;
                    }
                    if (reader.Depth == 4 && level1ElementName == "relatedItem" && level2ElementName == "extension"
                        && level3ElementName == "dateIssued")
                    {
                        currentRelatedItem.DateIssued = DateTime.Parse(reader.Value);
                    }
                }
                if(reader.NodeType == XmlNodeType.Attribute)
                {
                    if (reader.Depth == 3 && reader.Name == "xlink:href" && level1ElementName == "relatedItem" && level2ElementName == "relatedItem")
                    {
                        currentRelatedItem.URL = reader.Value;
                    }
                }

                if (reader.Name == "relatedItem")
                {
                    if(reader.Depth == 1 && reader.NodeType != XmlNodeType.EndElement)
                    {
                        currentRelatedItem = new CourtOpinionRelatedItem();
                        output.RelatedItems.Add(currentRelatedItem);
                    }
                }

                switch (reader.Depth)
                {
                    case 1:
                        level1ElementName = reader.Name;
                        break;
                    case 2:
                        level2ElementName = reader.Name;
                        break;
                    case 3:
                        level3ElementName = reader.Name;
                        break;
                    default:
                        break;
                }                
            }
            return output;
        }
    }
}
