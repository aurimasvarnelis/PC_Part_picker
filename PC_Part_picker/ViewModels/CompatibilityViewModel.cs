using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC_Part_picker.Models;

namespace PC_Part_picker.ViewModels
{
    public class CompatibilityViewModel
    {
        public Part FirstPart { get; set; }
        public Part SecondPart { get; set; }
        public Compatibility Compatibility { get; set; }

        public CompatibilityViewModel() { }
        public CompatibilityViewModel(Compatibility c)
        {
            Compatibility = c;
            FirstPart = c.Parts.ToList()[0].Part;
            SecondPart = c.Parts.ToList()[1].Part;
        }
    }
}
