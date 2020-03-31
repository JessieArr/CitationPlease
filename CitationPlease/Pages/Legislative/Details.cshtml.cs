using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitationPlease.Models.GovInfo;
using CitationPlease.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CitationPlease.Legislative
{
    public class DetailsModel : PageModel
    {
        public BillPackageSummary Summary { get; set; }
        public string Contents { get; set; }
        public string PDFLink { get; set; }
        private GovInfoClient _Client;

        public DetailsModel(GovInfoClient client)
        {
            _Client = client;
        }

        public void OnGet(string id)
        {
            Summary = _Client.GetBillPackageSummary(id).Result;
            //Contents = _Client.GetPresidentialDocumentPackageDetails(id).Result;
            var packageId = Summary.packageId;
            PDFLink = $"https://www.govinfo.gov/content/pkg/{packageId}/pdf/{packageId}.pdf";
            // https://www.govinfo.gov/content/pkg/BILLS-116hr6201eh/pdf/BILLS-116hr6201eh.pdf
        }
    }
}