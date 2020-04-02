using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitationPlease.Models.GovInfo.Judicial
{
    public class CourtOpinionDetails
    {
        public string Title { get; set; }
        public string Cause { get; set; }
        public string CaseNumber { get; set; }
        public List<CourtOpinionRelatedItem> RelatedItems { get; set; } = new List<CourtOpinionRelatedItem>();
    }
}
