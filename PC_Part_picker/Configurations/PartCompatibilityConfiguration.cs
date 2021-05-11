using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PC_Part_picker.Models;

namespace PC_Part_picker.Configurations
{
    public class PartCompatibilityConfiguration : IEntityTypeConfiguration<PartCompatibility>
    {
        public void Configure(EntityTypeBuilder<PartCompatibility> builder)
        {
            builder.HasOne(pc => pc.Compatibility).WithMany(c => c.Parts);
            builder.HasOne(pc => pc.Part).WithMany(p => p.Compatibilities);
        }
    }
}
