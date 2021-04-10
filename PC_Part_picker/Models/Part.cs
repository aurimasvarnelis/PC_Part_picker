using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Part_picker.Models
{
    public abstract class Part
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


    public class CPU : Part
    {
        public int Cores { get; set; }
        public string Frequency { get; set; }
        public string Series { get; set; }
        public int Consumption { get; set; }
    }

    public class GPU : Part
    {
        public string Memory { get; set; }
        public string Frequency { get; set; }
        public string MemoryType { get; set; }
        public int Consumption { get; set; }
    }

    /*public class RAM : Part
    {
        public string Type { get; set; }
        public string Frequency { get; set; }
        public int ModuleCount { get; set; }
        public string MemoryStorage { get; set; }
    }*/

    public class PartViewModel
    {
        //public int Id { get; set; }
        public IEnumerable<CPU> CPU { get; set; }
        public IEnumerable<GPU> GPU { get; set; }
    }


}
