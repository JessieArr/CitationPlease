using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitationPlease.Helpers;
using CitationPlease.Models.GovInfo;
using CitationPlease.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CitationPlease.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private GovInfoClient _Client;
        public List<PackageInfo> Packages { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            var secrets = SecretHelper.GetSecrets();
            _Client = new GovInfoClient(secrets.GovInfoApiKey);
        }

        public void OnGet()
        {
            var docs = _Client.ListCollectionContents("CPD", DateTime.Now.AddDays(-30), 0).Result;
            Packages = docs.packages;
        }
    }
}
