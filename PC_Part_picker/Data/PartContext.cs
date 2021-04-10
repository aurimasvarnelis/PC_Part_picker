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
    public class PartContext : DbContext
    {
        public PartContext(DbContextOptions<PartContext> options)
            : base(options)
        {
        }

        public DbSet<CPU> Cpu { get; set; }
        public DbSet<GPU> Gpu { get; set; }
        //public DbSet<Part> Part { get; set; }

        //public DbSet<PartModel> PartModel { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CPU>().ToTable("CPU");
            modelBuilder.Entity<GPU>().ToTable("GPU");
            modelBuilder.Entity<Part>().ToTable("Part");

        }*/


    }
}
