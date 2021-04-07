using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PC_Part_picker.Models;

namespace PC_Part_picker.Data
{
    public class PartContext : DbContext
    {
        public PartContext(DbContextOptions<PartContext> options)
            : base(options)
        {
        }

        public DbSet<Part> Part { get; set; }
    }
}
