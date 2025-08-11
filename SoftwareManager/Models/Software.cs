namespace SoftwareManager.Models
{
    public class Software
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Installed { get; set; }
        public string RegistryPath { get; set; }
        public string InstallPackagePath { get; set; }
        public string DownloadUrl { get; set; }
        public string IconPath { get; set; }
    }
}
