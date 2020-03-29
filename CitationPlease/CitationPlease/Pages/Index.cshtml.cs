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
        public List<PackageInfo> ThisWeeksPresidentialDocs { get; set; }
        public List<PackageInfo> TodaysPresidentialDocs { get; set; }
        public List<PackageInfo> ThisWeeksBills { get; set; }
        public List<PackageInfo> TodaysBills { get; set; }
        public List<PackageInfo> ThisWeeksCourtOpinions { get; set; }
        public List<PackageInfo> TodaysCourtOpinions { get; set; }

        public IndexModel(ILogger<IndexModel> logger, GovInfoClient client)
        {
            _logger = logger;
            _Client = client;
        }

        public void OnGet()
        {
            var lastWeek = DateTime.Now.AddDays(-7);
            var presidentialDocs = _Client.ListCollectionContents(DocumentCollections.PresidentialDocumentsID, lastWeek, 0).Result;
            var bills = _Client.ListCollectionContents(DocumentCollections.BillsID, lastWeek, 0).Result;
            var courtOpinions = _Client.ListCollectionContents(DocumentCollections.CourtOpinionsID, lastWeek, 0).Result;

            var thisWeeksDocs = presidentialDocs.packages.Where(x => x.dateIssued > DateTime.Now.AddDays(-7));
            ThisWeeksPresidentialDocs = thisWeeksDocs.OrderBy(x => x.dateIssued).ToList();
            var todaysDocs = presidentialDocs.packages.Where(x => x.dateIssued > DateTime.Now.AddDays(-1));
            TodaysPresidentialDocs = todaysDocs.ToList();

            var thisWeeksBills = bills.packages.Where(x => x.dateIssued > DateTime.Now.AddDays(-7));
            ThisWeeksBills = thisWeeksBills.OrderBy(x => x.dateIssued).ToList();
            var todaysBills = bills.packages.Where(x => x.dateIssued > DateTime.Now.AddDays(-1));
            TodaysBills = todaysBills.ToList();

            var thisWeeksCourtOpinions = courtOpinions.packages.Where(x => x.dateIssued > DateTime.Now.AddDays(-7));
            ThisWeeksCourtOpinions = thisWeeksCourtOpinions.OrderBy(x => x.dateIssued).ToList();
            var todaysCourtOpinions = courtOpinions.packages.Where(x => x.dateIssued > DateTime.Now.AddDays(-1));
            TodaysCourtOpinions = todaysCourtOpinions.ToList();
        }
    }
}
