using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoftwareManager.Models
{
    public class SoftwareData
    {
        [JsonPropertyName("Categories")]
        public List<SoftwareCategory> Categories { get; set; }

        [JsonPropertyName("Version")]
        public string Version { get; set; }

        public SoftwareData()
        {
            Categories = new List<SoftwareCategory>();
            Version = "1.0.0"; // 默认版本号
        }
    }
}
