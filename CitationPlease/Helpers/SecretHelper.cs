using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CitationPlease.Helpers
{
    public class SecretHelper
    {
        private string _SecretsFilePath = "secrets.json";
        public Secrets GetSecrets()
        {
            var fileText = File.ReadAllText(_SecretsFilePath);
            return JsonConvert.DeserializeObject<Secrets>(fileText);
        }
    }
}
