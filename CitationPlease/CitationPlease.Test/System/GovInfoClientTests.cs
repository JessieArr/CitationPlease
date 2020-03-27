using CitationPlease.Services;
using CitationPlease.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CitationPlease.Test.System
{
    public class GovInfoClientTests
    {
        private GovInfoClient SUT;

        public GovInfoClientTests()
        {
            var secrets = SecretHelper.GetSecrets();
            SUT = new GovInfoClient(secrets.GovInfoApiKey);
        }

        [Fact]
        public async Task ListCollections_DoesNotThrow()
        {
            var result = await SUT.ListCollections();
        }

        [Fact]
        public async Task ListCollectionContents_DoesNotThrow()
        {
            var testDate = new DateTime(2018, 1, 1);
            var result = await SUT.ListCollectionContents("CPD", testDate, 0);
        }
    }
}
