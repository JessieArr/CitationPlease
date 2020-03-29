using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitationPlease.Models.GovInfo
{
    public class PackageInfo
    {
        public string packageId { get; set; }
        public DateTime lastModified { get; set; }
        public string packageLink { get; set; }
        public string docClass { get; set; }
        public string title { get; set; }
        public string congress { get; set; }
        public DateTime dateIssued { get; set; }
        public PackageDownloadInfo download { get; set; }
        public string branch { get; set; }
        public int pages { get; set; }
        public string governmentAuthor1 { get; set; }
        public string documentType { get; set; }
        public string publisher { get; set; }
    }
}
