using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Part_picker.Models
{
    public class PartCompatibility
    {
        public int PartId { get; set; }
        public Part Part { get; set; }
        public int CompatibilityId { get; set; }
        public Compatibility Compatibility { get; set; }
    }
}
