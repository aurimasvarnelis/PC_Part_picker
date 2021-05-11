using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public ICollection<PartCompatibility> Compatibilities { get; set; }
    }

    public class SocketCPU
    {
        public int Id { get; set; }
        public string Socket { get; set; }
    }

    public class Dimensions
    {
        public int Id { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
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

    public class Motherboard : Part
    {
        public string ProccessorSocket { get; set; }
        public int MemorySocket { get; set; }
        public string MemoryType { get; set; }
        public string EnergyConsumption { get; set; }
        public SocketCPU Socket { get; set; }

    }

    public class RAM : Part
    {
        public string Type { get; set; }
        public string Frequency { get; set; }
        public string ModuleCount { get; set; }
        public string MemorySize { get; set; }
    }

    public class Cooler : Part
    {
        public string Purpose { get; set; }
        public string SoundLevel { get; set; }
        public string Speed { get; set; }
        public string RadiatorSize { get; set; }
        public int EnergyEfficiency { get; set; }
        public SocketCPU Socket { get; set; }
    }

    public class PSU : Part
    {
        public string Type { get; set; }
        public string Power { get; set; }
        public string SoundLevel { get; set; }
        public string Efficiency { get; set; }
        public Dimensions Dimensions { get; set; }
    }

    public class Storage : Part
    {
        public string Type { get; set; }
        public string Capacity { get; set; }
        public string Connector { get; set; }
        public string Speed { get; set; }

    }

    public class Case : Part
    {
        public string Type { get; set; }
        public string SizeFormat { get; set; }
        public Dimensions Dimensions { get; set; }
    }

    /*public class RAM : Part
    {
        public string Type { get; set; }
        public string Frequency { get; set; }
        public int ModuleCount { get; set; }
        public string MemoryStorage { get; set; }
    }*/

    

}
