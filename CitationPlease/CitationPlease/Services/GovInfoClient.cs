using CitationPlease.Models.GovInfo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CitationPlease.Services
{
    public class GovInfoClient
    {
        private string _ApiKey;
        private HttpClient _HttpClient;
        public GovInfoClient(string apiKey)
        {
            _ApiKey = apiKey;
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
    }
}
