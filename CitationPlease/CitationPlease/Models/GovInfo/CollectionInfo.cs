using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitationPlease.Models.GovInfo
{
    public class CollectionInfo
    {
        public string collectionCode { get; set; }
        public string collectionName { get; set; }
        public int? packageCount { get; set; }
        public int? granuleCount { get; set; }
    }
}
