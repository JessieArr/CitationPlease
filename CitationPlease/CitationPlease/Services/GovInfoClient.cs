using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitationPlease.Services
{
    public class GovInfoClient
    {
        private string _ApiKey;
        public GovInfoClient(string apiKey)
        {
            _ApiKey = apiKey;
        }

        public List<JObject> ListCollections()
        {
            return null;
        }
    }
}
