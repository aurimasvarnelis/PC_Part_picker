using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PC_Part_picker.Models;

namespace PC_Part_picker.ViewModels
{
    public class TwoPartCompatibilities
    { 
        public Compatibility Compatibility { get; set;}
        public string FirstPartId { get; set; }
        public string SecondPartId { get; set; }
        public List<Part> AllParts { get; set; }
    }
}
