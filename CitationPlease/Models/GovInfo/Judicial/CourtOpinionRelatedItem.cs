using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitationPlease.Models.GovInfo.Judicial
{
    public class CourtOpinionRelatedItem
    {
        public string URL { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime DateIssued { get; set; }
    }
}
