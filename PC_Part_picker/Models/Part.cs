using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Part_picker.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public string Manufacturer { get; set; }
        public string Color { get; set; }


    }
}
