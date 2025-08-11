using System.Collections.Generic;

namespace SoftwareManager.Models
{
    public class SoftwareCategory
    {
        public string Name { get; set; }
        public List<Software> Software { get; set; }

        public SoftwareCategory()
        {
            Software = new List<Software>();
        }
    }
}