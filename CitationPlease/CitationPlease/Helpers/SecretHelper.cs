using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CitationPlease.Helpers
{
    public static class SecretHelper
    {
        private static string _SecretsFilePath = "secrets.json";
        public static Secrets GetSecrets()
        {
            var fileText = File.ReadAllText(_SecretsFilePath);
            return JsonConvert.DeserializeObject<Secrets>(fileText);
        }
    }
}
