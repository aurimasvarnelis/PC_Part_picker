using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Part_picker.Models
{
    public class Build
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string RatingCount { get; set; }
        public double Price { get; set; }
        public bool Publication { get; set; }
        public string Status { get; set; }
        public CPU Cpu { get; set; }
        public Cooler Cooler { get; set; }
        public Motherboard Motherboard { get; set; }
        public RAM RAM { get; set; }
        public Storage Storage { get; set; }
        public GPU Gpu { get; set; }
        public PSU Psu { get; set; }
        public Case Case { get; set; }
    }
}
