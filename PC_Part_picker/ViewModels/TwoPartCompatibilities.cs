using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PC_Part_picker.Models;

namespace PC_Part_picker.ViewModels
{
    public class TwoPartCompatibilities
    {
        [BindProperty]
        public Compatibility Compatibility { get; set;}
        [Required]
        public string FirstPartId { get; set; }
        [Required]
        public string SecondPartId { get; set; }
        public List<Part> AllParts { get; set; }
    }
}
