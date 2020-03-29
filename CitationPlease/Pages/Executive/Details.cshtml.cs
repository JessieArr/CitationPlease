using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitationPlease.Models.GovInfo;
using CitationPlease.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CitationPlease
{
    public class DetailsModel : PageModel
    {
        public PresidentialDocumentPackageSummary Summary { get; set; }
        public string Contents { get; set; }
        private GovInfoClient _Client;
        
        public DetailsModel(GovInfoClient client)
        {
            _Client = client;
        }

        public void OnGet(string id)
        {
            Summary = _Client.GetPresidentialDocumentPackageSummary(id).Result;
            Contents = _Client.GetPresidentialDocumentPackageDetails(id).Result;
        }
    }
}