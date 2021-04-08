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
            using (var context = new PartContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PartContext>>()))
            {
                // Look for any parts.
                if (context.Part.Any())
                {
                    return;   // DB has been seeded
                }

                context.Part.AddRange(
                    new Part
                    {
                        Name = "Ryzen 3600X",
                        Model = "Ryzen",
                        Description = "AMD CPU blah bla",
                        Rating = 7.99,
                        Price = 560,
                        Manufacturer = "AMD",
                        Color = "Black"
                    },

                    new Part
                    {
                        Name = "Ryzen 3600X",
                        Model = "Ryzen",
                        Description = "AMD CPU blah bla",
                        Rating = 7.99,
                        Price = 560,
                        Manufacturer = "AMD",
                        Color = "Black"
                    },

                    new Part
                    {
                        Name = "Ryzen 3600X",
                        Model = "Ryzen",
                        Description = "AMD CPU blah bla",
                        Rating = 7.99,
                        Price = 560,
                        Manufacturer = "AMD",
                        Color = "Black"
                    },

                    new Part
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
                context.SaveChanges();
            }
        }
    }
}