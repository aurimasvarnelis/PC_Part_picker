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
                        Description = "AMD CPU blah bla",
                        Rating = 7.99,
                        Price = 560,
                        Manufacturer = "AMD",
                        Color = "Black",
                        Cores = 16,
                        Frequency = "3.54Mhz",
                        Series = "12",
                        Consumption = 350
                    },

                    new CPU
                    {
                        Name = "Ryzen 5500",
                        Model = "Ryzen",
                        Description = "AMD CPU blah bla",
                        Rating = 9.99,
                        Price = 850,
                        Manufacturer = "AMD",
                        Color = "Black",
                        Cores = 16,
                        Frequency = "3.54Mhz",
                        Series = "12",
                        Consumption = 350
                    },

                    new CPU
                    {
                        Name = "Ryzen 5700XT",
                        Model = "Ryzen",
                        Description = "AMD CPU blah bla",
                        Rating = 8.9,
                        Price = 1200,
                        Manufacturer = "AMD",
                        Color = "Black",
                        Cores = 16,
                        Frequency = "3.54Mhz",
                        Series = "12",
                        Consumption = 400
                    },

                    new CPU
                    {
                        Name = "Ryzen 3600X",
                        Model = "Ryzen",
                        Description = "AMD CPU blah bla",
                        Rating = 7.99,
                        Price = 560,
                        Manufacturer = "AMD",
                        Color = "Black",
                        Cores = 12,
                        Frequency = "3.54Mhz",
                        Series = "13",
                        Consumption = 290
                    }
                );
                context.Gpu.AddRange(
                    new GPU
                    {
                        Name = "GTX 1660",
                        Model = "GeForce",
                        Description = "GEFROCE POG",
                        Rating = 7.99,
                        Price = 560,
                        Manufacturer = "NVIDIA",
                        Color = "Black"
                    },

                    new GPU
                    {
                        Name = "Ryzen 3600X",
                        Model = "Ryzen",
                        Description = "AMD CPU blah bla",
                        Rating = 7.99,
                        Price = 560,
                        Manufacturer = "NVIDIA",
                        Color = "Black"
                    },

                    new GPU
                    {
                        Name = "Ryzen 3600X",
                        Model = "Ryzen",
                        Description = "AMD CPU blah bla",
                        Rating = 7.99,
                        Price = 560,
                        Manufacturer = "NVIDIA",
                        Color = "Black"
                    },

                    new GPU
                    {
                        Name = "Ryzen 3600X",
                        Model = "Ryzen",
                        Description = "AMD CPU blah bla",
                        Rating = 7.99,
                        Price = 560,
                        Manufacturer = "AMD",
                        Color = "Black"
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
                        Status = "statusas",
                        Cpu = null,
                        Cooler = null,
                        Motherboard = null,
                        RAM = null,
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