using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitationPlease.Models.GovInfo
{
    public class CourtOpinionPackageSummary : PackageSummary
    {
        public List<JudicialParty> parties { get; set; }
        public string caseNumber { get; set; }
        public string courtCircuit { get; set; }
    }
}
