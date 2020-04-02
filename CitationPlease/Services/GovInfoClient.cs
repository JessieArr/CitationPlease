using CitationPlease.Helpers;
using CitationPlease.Models.GovInfo;
using CitationPlease.Models.GovInfo.Judicial;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CitationPlease.Services
{
    public class GovInfoClient
    {
        private string _ApiKey;
        private HttpClient _HttpClient;
        public GovInfoClient(SecretHelper secretHelper)
        {
            _ApiKey = secretHelper.GetSecrets().GovInfoApiKey;
            _HttpClient = new HttpClient();
        }

        private string _CollectionsPath = "https://api.govinfo.gov/collections";
        private string _PackagesPath = "https://api.govinfo.gov/packages";
        public async Task<CollectionsResponse> ListCollections()
        {
            var url = $"{_CollectionsPath}?api_key={_ApiKey}";
            var result = await _HttpClient.GetAsync(url);
            if(result.IsSuccessStatusCode)
            {
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CollectionsResponse>(body);
            }
            throw new Exception("Error calling GovInfo API.");
        }

        public async Task<CollectionPackageList> ListCollectionContents(string collectionCode, DateTime startDate, 
            int offset, int pageSize = 100)
        {
            var formattedDate = startDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var url = $"{_CollectionsPath}/{collectionCode}/{formattedDate}?offset={offset}&pageSize={pageSize}&api_key={_ApiKey}";
            var result = await _HttpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CollectionPackageList>(body);
            }
            throw new Exception("Error calling GovInfo API.");
        }


        public async Task<PresidentialDocumentPackageSummary> GetPresidentialDocumentPackageSummary(string packageId)
        {
            var url = $"{_PackagesPath}/{packageId}/summary?api_key={_ApiKey}";
            var result = await _HttpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PresidentialDocumentPackageSummary>(body);
            }
            throw new Exception("Error calling GovInfo API.");
        }

        public async Task<string> GetPresidentialDocumentPackageDetails(string packageId)
        {
            var url = $"{_PackagesPath}/{packageId}/htm?api_key={_ApiKey}";
            var result = await _HttpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var body = await result.Content.ReadAsStringAsync();
                return body;
                //return JsonConvert.DeserializeObject<PresidentialDocumentPackageSummary>(body);
            }
            throw new Exception("Error calling GovInfo API.");
        }

        public async Task<CourtOpinionPackageSummary> GetCourtOpinionPackageSummary(string packageId)
        {
            var url = $"{_PackagesPath}/{packageId}/summary?api_key={_ApiKey}";
            var result = await _HttpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CourtOpinionPackageSummary>(body);
            }
            throw new Exception("Error calling GovInfo API.");
        }

        public async Task<CourtOpinionDetails> GetCourtOpinionDetails(string packageId)
        {
            var url = $"{_PackagesPath}/{packageId}/mods?api_key={_ApiKey}";
            var result = await _HttpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var xml = await result.Content.ReadAsStringAsync();
                return CourtOpinionParsingService.GetDetailsFromXML(xml);
            }
            throw new Exception("Error calling GovInfo API.");
        }

        public async Task<BillPackageSummary> GetBillPackageSummary(string packageId)
        {
            var url = $"{_PackagesPath}/{packageId}/summary?api_key={_ApiKey}";
            var result = await _HttpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BillPackageSummary>(body);
            }
            throw new Exception("Error calling GovInfo API.");
        }

        public async Task<string> GetBillPackageDetails(string packageId)
        {
            var url = $"{_PackagesPath}/{packageId}/xml?api_key={_ApiKey}";
            var result = await _HttpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var body = await result.Content.ReadAsStringAsync();
                var text = BillParsingService.GetTextFromXML(body);
                return text;
            }
            throw new Exception("Error calling GovInfo API.");
        }

        public async Task<Stream> DownloadPDF(string url)
        {
            var result = await _HttpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var bytes = await result.Content.ReadAsByteArrayAsync();
                var stream = await result.Content.ReadAsStreamAsync();
                return stream;
            }
            throw new Exception("Error calling GovInfo API.");
        }
    }
}
