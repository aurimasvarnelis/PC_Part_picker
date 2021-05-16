using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PC_Part_picker.Models;

namespace PC_Part_picker.Data
{
    public class PartPickerContext : DbContext
    {
        public PartPickerContext(DbContextOptions<PartPickerContext> options)
            : base(options)
        {
        }

        public DbSet<CPU> Cpu { get; set; }
        public DbSet<Cooler> Cooler { get; set; }
        public DbSet<Motherboard> Motherboard { get; set; }
        public DbSet<RAM> Ram { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<GPU> Gpu { get; set; }
        public DbSet<PSU> Psu { get; set; }
        public DbSet<Case> Case { get; set; }
        public DbSet<Build> Build { get; set; }
        public DbSet<PartCompatibility> PartCompatibilities { get; set; }
        public DbSet<Compatibility> Compatibilities { get; set; }


         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            // modelBuilder.Entity<CPU>().ToTable("CPU");
            // modelBuilder.Entity<GPU>().ToTable("GPU");
            // modelBuilder.Entity<Part>().ToTable("Part");
         }


    }
}
