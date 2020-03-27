using CitationPlease.Services;
using CitationPlease.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void Test()
        {

        }
    }
}
