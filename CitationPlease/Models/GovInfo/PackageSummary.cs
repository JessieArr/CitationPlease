using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitationPlease.Models.GovInfo
{
    public class PackageSummary
    {
        public string title { get; set; }
        public string collectionCode { get; set; }
        public string collectionName { get; set; }
        public string category { get; set; }
        public DateTime dateIssued { get; set; }
        public string detailsLink { get; set; }
        public string packageId { get; set; }
        public string governmentAuthor1 { get; set; }
        public string governmentAuthor2 { get; set; }
    }
}
