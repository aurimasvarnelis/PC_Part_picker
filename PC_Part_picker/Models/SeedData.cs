using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PC_Part_picker.Data;

namespace PC_Part_picker.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PartPickerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PartPickerContext>>()))
            {
                // Look for any parts.
                if (context.Cpu.Any())
                {
                    return;   // DB has been seeded
                }

                context.Cpu.AddRange(
                    new CPU
                    {
                        Name = "Ryzen 3600X",
                        Model = "Ryzen",
                        Rating = 4.3,
                        Price = 299.00,
                        Manufacturer = "AMD",
                        Color = "Black",
                        Cores = 16,
                        Frequency = "3.54Mhz",
                        Series = "12",
                        Consumption = "40W"
                    },

                    new CPU
                    {
                        Name = "Ryzen 5500",
                        Model = "Ryzen",
                        Rating = 4.9,
                        Price = 849.99,
                        Manufacturer = "AMD",
                        Color = "Black",
                        Cores = 16,
                        Frequency = "3.54Mhz",
                        Series = "AMD Ryzen 5",
                        Consumption = "55W"
                    },

                    new CPU
                    {
                        Name = "Ryzen 5700XT",
                        Model = "Ryzen",
                        Rating = 4.9,
                        Price = 1200.99,
                        Manufacturer = "AMD",
                        Color = "Black",
                        Cores = 16,
                        Frequency = "3.54Mhz",
                        Series = "AMD Ryzen 6",
                        Consumption = "70W"
                    },

                    new CPU
                    {
                        Name = "Ryzen 3600X",
                        Model = "Ryzen",
                        Rating = 4.6,
                        Price = 250.00,
                        Manufacturer = "AMD",
                        Color = "Black",
                        Cores = 12,
                        Frequency = "3.54Mhz",
                        Series = "AMD Ryzen 5",
                        Consumption = "65W"
                    }
                );

                context.Cooler.AddRange(
                    new Cooler
                    {
                        Name = "Cooler Master Hyper 212 EVO 82.9 CFM Sleeve Bearing CPU Cooler",
                        Model = "Hyper 212 EVO",
                        Rating = 4.5,
                        Price = 120,
                        Manufacturer = "Cooler Master",
                        Color = "Black",
                        SoundLevel = "9 - 36 dB",
                        Speed = "600 - 2000 RPM",
                        RadiatorSize = "159 mm"
                    },

                    new Cooler
                    {
                        Name = "NZXT Kraken X73 73.11 CFM Liquid CPU Cooler",
                        Model = "Kraken X73",
                        Rating = 4.8,
                        Price = 120,
                        Manufacturer = "NZXT",
                        Color = "Black",
                        SoundLevel = "21 - 36 dB",
                        Speed = "500 - 2000 RPM",
                        RadiatorSize = "360 mm"
                    }
                );

                context.Motherboard.AddRange(
                    new Motherboard
                    {
                        Name = "MSI B450 TOMAHAWK MAX ATX AM4 Motherboard",
                        Model = "B450 TOMAHAWK MAX",
                        Rating = 4.6,
                        Price = 120.56,
                        Manufacturer = "MSI",
                        Color = "Titanium",
                        MemorySlots = 4,
                        MemoryType = "DDR4",
                        FormFactor = (FormFactor) 0
                    },

                    new Motherboard
                    {
                        Name = "Asus PRIME X570-PRO ATX AM4 Motherboard",
                        Model = "PRIME X570-PRO",
                        Rating = 4.4,
                        Price = 279.99,
                        Manufacturer = "Asus",
                        Color = "Gray",
                        MemorySlots = 4,
                        MemoryType = "DDR4",
                        FormFactor = (FormFactor) 0
                    }
                );

                context.Ram.AddRange(
                    new RAM
                    {
                        Name = "G.Skill Ripjaws V 16 GB (2 x 8 GB) DDR4-3600 CL16 Memory",
                        Model = "Hyper 212 EVO",
                        Rating = 4.9,
                        Price = 103.99,
                        Manufacturer = "G.Skill",
                        Color = "Black",
                        Type = "DDR4",
                        Frequency = "3600",
                        ModuleCount = "2 x 8GB",
                        MemorySize = "16GB"
                    },

                    new RAM
                    {
                        Name = "Corsair Vengeance LPX 8 GB (2 x 4 GB) DDR4-3000 CL16 Memory",
                        Model = "Corsair Vengeance LPX",
                        Rating = 4.8,
                        Price = 72.99,
                        Manufacturer = "Corsair",
                        Color = "Black / Yellow",
                        Type = "DDR4",
                        Frequency = "3000",
                        ModuleCount = "2 x 4GB",
                        MemorySize = "8GB"
                    }
                );

                context.Storage.AddRange(
                    new Storage
                    {
                        Name = "Samsung 970 Evo 1 TB M.2-2280 NVME Solid State Drive",
                        Model = "Samsung 970 Evo",
                        Rating = 4.9,
                        Price = 159.99,
                        Manufacturer = "Samsung",
                        Color = "Gray",
                        Type = "SSD",
                        Capacity = "1 TB",
                        Connector = "M.2",
                        Cache = "1024 MB"
                    },

                    new Storage
                    {
                        Name = "Seagate BarraCuda 1 TB 3.5\" 7200RPM Internal Hard Drive",
                        Model = "ST1000DM010",
                        Rating = 4.6,
                        Price = 54.99,
                        Manufacturer = "Seagate",
                        Color = "White",
                        Type = "HDD",
                        Capacity = "1 TB",
                        Connector = "SATA 6 Gb/s",
                        Cache = "64 MB"
                    }
                );

                context.Gpu.AddRange(
                    new GPU
                    {
                        Name = "EVGA GeForce RTX 3060 12 GB XC GAMING Video Card",
                        Model = "GeForce RTX 3060",
                        Rating = 7.99,
                        Price = 409.00,
                        Manufacturer = "EVGA",
                        Color = "Black",
                        Memory = "12 GB",
                        Frequency = "1320 MHz",
                        MemoryType = "GDDR6",
                        Consumption = "170 W"
                    },

                    new GPU
                    {
                        Name = "MSI GeForce GTX 1660 SUPER 6 GB GAMING X Video Card",
                        Model = "GeForce GTX 1660 SUPER",
                        Rating = 4.8,
                        Price = 499.99,
                        Manufacturer = "MSI",
                        Color = "Black",
                        Memory = "6 GB",
                        Frequency = "1530 MHz",
                        MemoryType = "GDDR6",
                        Consumption = "125 W"
                    },

                    new GPU
                    {
                        Name = "Asus GeForce RTX 3090 24 GB STRIX GAMING OC Video Card",
                        Model = "GeForce RTX 3090",
                        Rating = 5.00,
                        Price = 2199.99,
                        Manufacturer = "Asus",
                        Color = "Black",
                        Memory = "24 GB",
                        Frequency = "1400 MHz",
                        MemoryType = "GDDR6X",
                        Consumption = "350 W"
                    },

                    new GPU
                    {
                        Name = "XFX Radeon RX 580 8 GB GTR XXX Video Card",
                        Model = "RX-Radeon RX 580",
                        Rating = 4.7,
                        Price = 665.00,
                        Manufacturer = "XFX",
                        Color = "Black / Red",
                        Memory = "8 GB",
                        Frequency = "1366 MHz",
                        MemoryType = "GDDR5",
                        Consumption = "185 W"
                    }
                );

                context.Psu.AddRange(
                    new PSU
                    {
                        Name = "Corsair RM (2019) 750 W 80+ Gold Certified Fully Modular ATX Power Supply",
                        Model = "RM750 (2019)",
                        Rating = 4.9,
                        Price = 124.99,
                        Manufacturer = "Corsair",
                        Color = "Black",
                        FormFactor = (FormFactor) 0,
                        Wattage = "750 W",
                        Modular = "Full",
                        EfficiencyRating = "80+ Gold"
                    },

                    new PSU
                    {
                        Name = "EVGA BR 600 W 80+ Bronze Certified ATX Power Supply",
                        Model = "EVGA BR",
                        Rating = 4.6,
                        Price = 69.99,
                        Manufacturer = "EVGA",
                        Color = "Black",
                        FormFactor = (FormFactor) 0,
                        Wattage = "600 W",
                        Modular = "No",
                        EfficiencyRating = "80+ Bronze"
                    }
                );

                context.Case.AddRange(
                    new Case
                    {
                        Name = "Cooler Master MasterBox Q300L MicroATX Mini Tower Case",
                        Model = "MasterBox Q300L",
                        Rating = 4.2,
                        Price = 49.99,
                        Manufacturer = "Cooler Master",
                        Color = "Black",
                        Type = "MicroATX Mini Tower",
                        FormFactor = (FormFactor) 2                     
                    },

                    new Case
                    {
                        Name = "NZXT H510 ATX Mid Tower Case",
                        Model = "H510",
                        Rating = 4.6,
                        Price = 79.99,
                        Manufacturer = "NZXT",
                        Color = "White",
                        Type = "ATX Mid Tower",
                        FormFactor = (FormFactor) 2
                    }
                );

                context.Build.AddRange(
                    new Build
                    {
                        Name = "Mano buildas",
                        Rating = 9.99,
                        RatingCount = "Rating count",
                        Price = 560,
                        Publication = true,
                        Status = "published",
                        Cpu = null,
                        Cooler = null,
                        Motherboard = null,
                        Ram = null,
                        Storage = null,
                        Gpu = null,
                        Psu = null,
                        Case = null
                    }
               );
        context.SaveChanges();
            }
        }
    }
}