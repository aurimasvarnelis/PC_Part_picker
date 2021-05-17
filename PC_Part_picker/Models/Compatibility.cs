using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PC_Part_picker.Models
{
    public class Compatibility
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [BindProperty]
        public ICollection<PartCompatibility> Parts { get; set; }
    }
}
