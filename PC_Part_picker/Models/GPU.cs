using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Part_picker.Models
{
    public class GPU
    {
        public int Id { get; set; }
        public string Memory { get; set; }
        public string Frequency { get; set; }
        public string MemoryType { get; set; }
        public int Consumption { get; set; }
    }
}
