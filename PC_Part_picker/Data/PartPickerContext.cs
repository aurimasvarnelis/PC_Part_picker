using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PC_Part_picker.Configurations;
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

        public DbSet<PC_Part_picker.Models.Cooler> Cooler { get; set; }

        public DbSet<PC_Part_picker.Models.Motherboard> Motherboard { get; set; }

        //public DbSet<Part> Part { get; set; }

        //public DbSet<PartModel> PartModel { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             // modelBuilder.Entity<CPU>().ToTable("CPU");
             // modelBuilder.Entity<GPU>().ToTable("GPU");
             // modelBuilder.Entity<Part>().ToTable("Part");
             modelBuilder.ApplyConfiguration(new CompatibilityConfiguration());
             modelBuilder.ApplyConfiguration(new PartsConfiguration());
             modelBuilder.ApplyConfiguration(new PartCompatibilityConfiguration());
             modelBuilder.Entity<PartCompatibility>().HasKey(pc => new {pc.PartId, pc.CompatibilityId});
         }


    }
}
