using CitationPlease.Helpers;
using CitationPlease.Services;
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
            SUT = new GovInfoClient(new SecretHelper());
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

        [Fact]
        public async Task GetPresidentialDocumentPackageSummary_DoesNotThrow()
        {
            var result = await SUT.GetPresidentialDocumentPackageSummary("DCPD-202000160");
        }
    }
}
