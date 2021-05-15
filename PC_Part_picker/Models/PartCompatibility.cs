using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Part_picker.Models
{
    public class PartCompatibility
    {
        [Key]
        public int Id { get; set; }
        public int CompatibilityId { get; set; }
        public Compatibility Compatibility { get; set; }
        public int? CPUId { get; set; }
        public int? CaseId { get; set; }
        public int? CoolerId { get; set; }
        public int? GPUId { get; set; }
        public int? MotherboardId { get; set; }
        public int? PSUId { get; set; }
        public int? RAMId { get; set; }
        public int? StorageId { get; set; }
        public CPU Cpu { get; set; }
        public Cooler Cooler { get; set; }
        public Motherboard Motherboard { get; set; }
        public RAM Ram { get; set; }
        public Storage Storage { get; set; }
        public GPU Gpu { get; set; }
        public PSU Psu { get; set; }
        public Case Case { get; set; }

        public Part Part
        {
            get
            {
                if (CPUId != null) return Cpu;
                if (CaseId != null) return Case;
                if (CoolerId != null) return Cooler;
                if (GPUId != null) return Gpu;
                if (MotherboardId != null) return Motherboard;
                if (PSUId != null) return Psu;
                if (RAMId != null) return Ram;
                if (StorageId != null) return Storage;

                return null;
            }
        }
    }


}
