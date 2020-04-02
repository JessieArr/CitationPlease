using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitationPlease.Models.GovInfo;
using CitationPlease.Models.GovInfo.Judicial;
using CitationPlease.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CitationPlease.Judicial
{
    public class DetailsModel : PageModel
    {
        public CourtOpinionPackageSummary Summary { get; set; }
        public CourtOpinionDetails Details { get; set; }
        public List<CourtOpinionRelatedItem> RelatedItems { get; set; }
        public string Contents { get; set; }
        public string GovInfoLink { get; set; }
        private GovInfoClient _Client;

        public DetailsModel(GovInfoClient client)
        {
            _Client = client;
        }

        public void OnGet(string id)
        {
            Summary = _Client.GetCourtOpinionPackageSummary(id).Result;
            var packageId = Summary.packageId;
            GovInfoLink = $"https://www.govinfo.gov/app/details/{packageId}/summary";
            Details = _Client.GetCourtOpinionDetails(id).Result;            
            RelatedItems = Details.RelatedItems.OrderByDescending(x => x.DateIssued).ToList();
        }
    }
}