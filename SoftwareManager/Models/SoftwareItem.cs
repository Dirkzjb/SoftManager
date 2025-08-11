using System.Text.Json.Serialization;

namespace SoftwareManager.Models
{
    public class SoftwareItem
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Installed")]
        public bool Installed { get; set; }

        [JsonPropertyName("RegistryPath")]
        public string RegistryPath { get; set; }

        [JsonPropertyName("InstallPackagePath")]
        public string InstallPackagePath { get; set; }

        [JsonPropertyName("DownloadUrl")]
        public string DownloadUrl { get; set; }

        [JsonPropertyName("IconPath")]
        public string Icon { get; set; }

        [JsonIgnore]
        public bool PackageExists { get; set; }
    }
}