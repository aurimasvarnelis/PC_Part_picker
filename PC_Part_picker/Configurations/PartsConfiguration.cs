using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Part_picker.Models;

namespace PC_Part_picker.Configurations
{
    public class PartsConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            //builder.HasMany(p => p.Compatibilities).WithOne(c => c.Part);
        }
    }
}
