using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitationPlease.Models.GovInfo
{
    public class PresidentInfo
    {
        public string id { get; set; }
        public string party { get; set; }
        public Dictionary<string, string> names { get; set; }
    }
}
