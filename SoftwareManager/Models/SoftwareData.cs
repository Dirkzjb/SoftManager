using System.Collections.Generic;

namespace SoftwareManager.Models
{
    public class SoftwareData
    {
        public List<SoftwareCategory> Categories { get; set; }

        public SoftwareData()
        {
            Categories = new List<SoftwareCategory>();
        }
    }
}
