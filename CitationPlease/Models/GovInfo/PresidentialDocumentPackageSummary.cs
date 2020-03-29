using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitationPlease.Models.GovInfo
{
    public class PresidentialDocumentPackageSummary : PackageSummary
    {
        public JObject president { get; set; }
    }
}
