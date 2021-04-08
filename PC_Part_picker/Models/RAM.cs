using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Part_picker.Models
{
    public class RAM
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Frequency { get; set; }
        public int ModuleCount { get; set; }
        public string MemoryStorage { get; set; }
    }
}
