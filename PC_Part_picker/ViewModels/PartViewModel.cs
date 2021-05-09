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
        public IEnumerable<CPU> CPU { get; set; }
        public IEnumerable<GPU> GPU { get; set; }
        public IEnumerable<GPU> MB { get; set; }
    }
}
