using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoftwareManager.Models
{
    public class SoftwareCategory
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        
        [JsonPropertyName("Software")]
        public List<SoftwareItem> Software { get; set; }

        public SoftwareCategory()
        {
            Software = new List<SoftwareItem>();
        }
    }
}
