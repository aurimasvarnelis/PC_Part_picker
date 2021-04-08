using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Part_picker.Models
{
    public class CPU
    {
        public int Id { get; set; }
        public int Cores { get; set; }
        public string Frequency { get; set; }
        public string Series { get; set; }
        public int Consumption { get; set; }
    }
}
