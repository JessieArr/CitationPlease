using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitationPlease.Models.GovInfo
{
    public class CollectionPackageList
    {
        public int count { get; set; }
        public string message { get; set; }
        public string nextPage { get; set; }
        public string previousPage { get; set; }
        public List<PackageInfo> packages { get; set; }
    }
}
