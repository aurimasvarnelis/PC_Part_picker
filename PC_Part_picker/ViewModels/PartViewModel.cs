using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC_Part_picker.Models;

namespace PC_Part_picker.ViewModels
{
    public class PartViewModel
    {
        //public int Id { get; set; }
        public IEnumerable<CPU> Cpu { get; set; }
        public IEnumerable<Cooler> Cooler { get; set; }
        public IEnumerable<Motherboard> Motherboard { get; set; }
        public IEnumerable<RAM> Ram { get; set; }
        public IEnumerable<Storage> Storage { get; set; }
        public IEnumerable<GPU> Gpu { get; set; }
        public IEnumerable<PSU> Psu { get; set; }
        public IEnumerable<Case> Case { get; set; }
    }
}
